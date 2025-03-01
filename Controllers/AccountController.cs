namespace Shoes_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("Register/{lan:alpha}")]
        public async Task<IActionResult> Register(RegisterDTO Model, string lan)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));
            }

            var existUserName = await userManager.FindByNameAsync(Model.UserName);
            if (existUserName != null)
            {
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("UserNameAlreadyExists", lan)));
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

            var user = new ApplicationUser
            {
                UserName = Model.UserName,
                Email = Model.Email,
                verificationCode = new Random().Next(1000, 9999).ToString(),
                IsApprove = false
            };

            var result = await userManager.CreateAsync(user, Model.Password);

            if (result.Succeeded)
                return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("RegistrationSuccess", lan), user));
            

            return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("RegistrationFailed", lan)));
        }


    }
}
