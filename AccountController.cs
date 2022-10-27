using jiankao2.Requests;
using jiankao2.Responses;
using jiankao2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Text;

namespace jiankao2.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        //private readonly IAuthorizationService _authorizationService;
        public AccountController(UserManager<IdentityUser> userManager, IConfiguration configuration, IAuthorizationService authorizationService)
        {
           // _authorizationService = authorizationService;
            _userManager = userManager;
            _configuration = configuration;

        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            
            var result = await _userManager.CreateAsync(new IdentityUser
            {
                UserName = request.UserName
            }, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest("失败！");
            }
            return Ok(new TokenResponse
            {

            });
        }

        [HttpPost("Login")]
      
        public async Task<IActionResult> Login(LoginRequest request)
        {
           
            var existingUser = await _userManager.FindByNameAsync(request.UserName); //查询用户
            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, request.Password);//检查密码是否匹配
            if (!isCorrect)
            {
                return BadRequest("用户名或密码错误！");
            }
            var secretKey = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]);
            return Ok(UserService.GenerateJwtToken(existingUser, secretKey));
        }
       
    }

}

