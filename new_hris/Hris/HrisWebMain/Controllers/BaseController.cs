using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Web.Main.Controllers
{
  public class BaseController : Controller
  {
    protected string CurrentUser => HttpContext.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

    protected string RemoteIpAddress => HttpContext.Connection.RemoteIpAddress.ToString();
  }
}
