using AutoMapper;
using Forum.Data;
using Forum.Entities;
using Forum.Helper;
using Forum.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace Forum.Controllers
{
    [Route("api/[controller]")]

    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<ApplicationUser> userManager,
            IMapper mapper, 
            ApplicationDbContext appDbContext,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _signInManager = signInManager;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new
                {
                    modelStatus = 0,
                    modelError = ModelState.Keys.Select(k => ModelState[k].Errors[0].ErrorMessage).FirstOrDefault()
                });
            }

            var userIdentity = _mapper.Map<ApplicationUser>(model);
            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(new
                {
                    modelStatus = 1,
                    modelError = result.Errors.FirstOrDefault().Description
                });
            }

            return new CreatedResult("api/[controller]", new { message = "Account Created" });
        }


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new
                {
                    modelStatus = 0,
                    modelError = ModelState.Keys.Select(k => ModelState[k].Errors[0].ErrorMessage).FirstOrDefault()
                });
            }

            var userIdentity = _mapper.Map<ApplicationUser>(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.Remember, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                return new OkObjectResult(new { message = "Login successful." });
            }
            else
            {
                return new UnauthorizedResult();
            }
        }

        [Route("logout")]
        [HttpPost]
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
