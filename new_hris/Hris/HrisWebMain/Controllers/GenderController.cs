using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hris.List.Api;
using Hris.Shared;
using Hris.Shared.Gender;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Web.Main.Controllers
{
  public class GenderController : Controller
  {
    private readonly IHrisListApi _hrisListApi;

    public GenderController(IHrisListApi hrisListApi)
    {
      _hrisListApi = hrisListApi;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
      return await GetListGender();
    }

    private async Task<JsonResult> GetListGender()
    {
      var genders = await _hrisListApi.SelectGender(null);

      return Json(new ResponseResult<IEnumerable<GenderViewModel>>(genders));
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] GenderViewModel gender)
    {
      var genderId = await _hrisListApi.SaveGender(gender);

      if (genderId > 0) return await GetListGender();

      return Json(new ResponseResult<bool>(false, ResultCode.Error, null));
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] GenderViewModel gender)
    {
      var genderId = await _hrisListApi.DeleteGender(gender.Id);

      if (genderId > 0) return await GetListGender();

      return Json(new ResponseResult<bool>(false, ResultCode.Error, null));
    }

    [HttpPost]
    public async Task<IActionResult> Status([FromBody] GenderViewModel gender)
    {
      var genderId = await _hrisListApi.ToggleGenderStatus(gender.Id);

      if (genderId > 0) return await GetListGender();

      return Json(new ResponseResult<bool>(false, ResultCode.Error, null));
    }
  }
}
