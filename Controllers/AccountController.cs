using System.Threading.Tasks;

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

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO Model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse(false,"Invalid Request Data"));

            var existUserName = await userManager.FindByNameAsync(Model.UserName);
            if(existUserName != null)
                return BadRequest(new ApiResponse(false, "UserName is already taken"));

            var user = new ApplicationUser();
            user.UserName = Model.UserName;
            user.Email = Model.Email;
            user.vervicationCode = new Random().Next(1000, 9999).ToString();
            user.IsApprove = false;

            var result = await userManager.CreateAsync(user, Model.Password);

            if (result.Succeeded)
                return Ok(new ApiResponse(true, "User registered successfully.", user));

            return BadRequest(new ApiResponse(false , "User registration failed."));
        }
    }
}
