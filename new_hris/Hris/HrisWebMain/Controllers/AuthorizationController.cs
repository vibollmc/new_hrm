using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hris.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hris.Web.Main.Controllers
{
  public class AuthorizationController : Controller
  {
    private readonly IConfiguration _configuration;

    public AuthorizationController(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Index([FromBody] LoginModel login)
    {
      IActionResult response = Unauthorized();
      var user = Authenticate(login);

      if (user == null) return response;

      var token = BuildToken(user);

      response = Ok(new ResponseResult<string>(token));

      return response;
    }

    private string BuildToken(UserModel user)
    {
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var claims = new[] {
        new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.GivenName, user.Name),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.Username)
      };

      var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
        _configuration["Jwt:Issuer"],
        claims,
        expires: DateTime.Now.AddHours(8),
        signingCredentials: creds);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private UserModel Authenticate(LoginModel login)
    {
      UserModel user = null;

      //TO DO: Verify account login
      if (login.Username == "mario" && login.Password == "secret")
      {
        user = new UserModel {Id = 1, Username = "mario", Name = "Mario Rossi", Email = "mario.rossi@domain.com"};
      }

      return user;
    }
  }
}
