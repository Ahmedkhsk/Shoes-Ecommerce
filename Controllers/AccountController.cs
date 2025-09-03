namespace Shoes_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configure;
        private readonly string imagePath;
        private readonly EmailSenderHelper _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager , IConfiguration configure,
            IWebHostEnvironment webHostEnvironment, EmailSenderHelper emailSender)
        {
            this.userManager = userManager;
            this.configure = configure;
            imagePath = Path.Combine(webHostEnvironment.WebRootPath, FileSetting.ImagesPathUser.TrimStart('/'));
            _emailSender = emailSender;
        }
            
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO Model, string lan = "en")
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));
            }

            try
            {
               
                var existEmail = await userManager.FindByEmailAsync(Model.Email);
                if (existEmail != null)
                {
                    return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("EmailAlreadyExists", lan)));
                }
            }
            catch (InvalidOperationException)
            {
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("EmailAlreadyExists", lan)));
            }
            var image = "default.png";
            var user = new ApplicationUser
            {
                Name = Model.Name,
                UserName = Model.Name+Guid.NewGuid(),
                Email = Model.Email,
                ImageUrl = image,
                verificationCode = new Random().Next(1000, 9999).ToString(),
                IsApprove = false
            };

            var result = await userManager.CreateAsync(user, Model.Password);

            if (result.Succeeded)
            {
                await _emailSender.SendEmailAsync(
                       user.Email,
                       "Verification Code",
                       $"Your OTP is: <b>{user.verificationCode}</b>"
                   );
                return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("RegistrationSuccess", lan), Model));
            }
                
            

            return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("RegistrationFailed", lan)));
        }


        [HttpPost("VerificationEmail")]
        public async Task<IActionResult> verificationCode(VerificationEmailDTO Model,string lan = "en")
        {
            var UserExist = await userManager.FindByEmailAsync(Model.Email);

            if (UserExist != null)
                if(UserExist.verificationCode == Model.VerificationCode)
                {
                    UserExist.IsApprove = true;
                    UserExist.verificationCode = null;
                    await userManager.UpdateAsync(UserExist);
                    return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("VerificationSuccess", lan)));
                }                               
                else
                    return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("VerificationFailed", lan)));
            else
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("UserNotFound", lan)));
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> forgotPassword([FromBody] string email , string lan = "en")
        {
            var userExist = await userManager.FindByEmailAsync(email);
            if(userExist != null)
            {
                userExist.verificationCode = new Random().Next(1000, 9999).ToString();
                userExist.IsApprove = false;
                await userManager.UpdateAsync(userExist);
                await _emailSender.SendEmailAsync(email, "Verification Code", $"Your OTP is: <b>{userExist.verificationCode}</b>");
                return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("OTPSend", lan)));
            }

            return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("UserNotFound", lan)));
        }
        
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(changePassDTO Model, string lan = "en")
        {
            var userExist = await userManager.FindByEmailAsync(Model.Email);

            if (userExist != null)
            {
                if (Model.newPassword == Model.confirmPassword)
                {              
                        var resetToken = await userManager.GeneratePasswordResetTokenAsync(userExist);
                        var result = await userManager.ResetPasswordAsync(userExist, resetToken, Model.newPassword);

                        if (result.Succeeded)
                        {
                            userExist.IsApprove = true;
                            userExist.verificationCode = null;

                            await userManager.UpdateAsync(userExist);

                            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ChangePassSuccess", lan)));
                        }
                        else
                        {
                        var errorResult = result.Errors.Select(e => e.Description);
                            var errors = string.Join(", ", errorResult);
                            return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("PassFailed", lan) + ": " + errors));
                        }                    
                }
                else            
                    return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("PassMismatch", lan)));               
            }
            else            
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("UserNotFound", lan)));           
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO Model,string lan = "en")
        {
            var userExist = await userManager.FindByEmailAsync(Model.Email);
            if(userExist != null)
            {
                var CheckPass = await userManager.CheckPasswordAsync(userExist, Model.password);
                if (CheckPass)
                {
                    await userManager.UpdateAsync(userExist);

                    List<Claim> Claims = new List<Claim>();
                    Claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    Claims.Add(new Claim(ClaimTypes.NameIdentifier,userExist.Id));

                    var userRole = await userManager.GetRolesAsync(userExist);
                    
                    foreach (var item in userRole)
                        Claims.Add(new Claim(ClaimTypes.Role, item));
                    var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configure["JWT:SecritKey"]));
                    SigningCredentials signingCredentials = new SigningCredentials(signKey,SecurityAlgorithms.HmacSha256);
                    JwtSecurityToken mytoken = new JwtSecurityToken(
                        issuer: configure["JWT:IssuerIP"],
                        audience: configure["JWT:AudienceIP"],
                        expires: DateTime.Now.AddHours(1),
                        claims: Claims,
                        signingCredentials: signingCredentials
                        );
                    var token = new JwtSecurityTokenHandler().WriteToken(mytoken);
                    return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("LoginSuccess", lan), token));
                }
                else
                    return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("LoginFailed", lan)));
            }

            return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("LoginFailed", lan)));
        }

        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> updateProfile(updateUserDTO updateUserDTO,string lan = "en")
        {
            var user = await userManager.FindByIdAsync(updateUserDTO.userId);
            if (user != null)
            {
                user.Name = updateUserDTO.userName;
                
                var image = "default.png";
                if (user.ImageUrl != image)
                {
                    var oldImage = user.ImageUrl;
                    var newImage = await Images.SaveImage(updateUserDTO.imageName,imagePath);
                    user.ImageUrl = newImage;
                    Images.DeleteImage(oldImage,imagePath);
                }
                else
                {
                    var cover = await Images.SaveImage(updateUserDTO.imageName, imagePath);
                    user.ImageUrl = cover;        
                }

                userDTO userDTO = new userDTO();

                userDTO.userName = user.Name;
                userDTO.email = user.Email;
                userDTO.imageName = user.ImageUrl;

                await userManager.UpdateAsync(user);
                return Ok(new ApiResponse(true,LocalizationHelper.GetLocalizedMessage("ProfileUpdated", lan), userDTO));
            }
            return BadRequest(new ApiResponse(false,LocalizationHelper.GetLocalizedMessage("UpdateFailed", lan)));
        }

        [HttpDelete("DeleteProfile/{userId}")]
        public async Task<IActionResult> deleteProfile(string userId, string lan = "en")
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var image = user.ImageUrl;
                Images.DeleteImage(image, imagePath);
                await userManager.DeleteAsync(user);
                return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("UserDeleted", lan)));
            }
            return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("UserNotFound", lan)));
        }

        [HttpGet("GetUser")]
        public IActionResult getUser(string userId,string lan= "en")
        {
            var user = userManager.Users.FirstOrDefault(f => f.Id == userId);
            
            userDTO userDTO = new userDTO();
            
            userDTO.userName = user.Name;
            userDTO.email = user.Email;
            userDTO.imageName = user.ImageUrl;

            if (user != null)
            {
                return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("UserRetrived",lan), userDTO));
            }
            return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("UserNotFound", lan)));
        }
    }
}
