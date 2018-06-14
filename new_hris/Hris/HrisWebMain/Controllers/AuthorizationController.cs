using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hris.Common.Api;
using Hris.Shared;
using Hris.Shared.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hris.Web.Main.Controllers
{
  public class AuthorizationController : Controller
  {
    private readonly IConfiguration _configuration;
    private readonly ICommonApi _commonApi;

    public AuthorizationController(IConfiguration configuration, ICommonApi commonApi)
    {
      _configuration = configuration;
      _commonApi = commonApi;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Index([FromBody] LoginModel login)
    {
      IActionResult response = Unauthorized();

      var user = await Authenticate(login);

      if (user == null) return response;

      var token = BuildToken(user);

      response = Ok(new ResponseResult<string>(data: token));

      return response;
    }

    private string BuildToken(UserModel user)
    {
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var claims = new[] {
        new Claim(ClaimTypes.Sid, user.Id.ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Username),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Name, user.Fullname)
      };

      var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
        _configuration["Jwt:Issuer"],
        claims,
        expires: DateTime.Now.AddHours(8),
        signingCredentials: creds);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<UserModel> Authenticate(LoginModel login)
    {
      return await _commonApi.GetUser(login.Username, login.Password);
    }
  }
}
