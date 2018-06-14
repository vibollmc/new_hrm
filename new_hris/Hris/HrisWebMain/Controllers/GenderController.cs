using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Api;
using Hris.Shared;
using Hris.Shared.Gender;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Web.Main.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class GenderController : BaseController
  {
    private readonly IListApi _hrisListApi;

    public GenderController(IListApi hrisListApi)
    {
      _hrisListApi = hrisListApi;
    }

    [HttpGet]
    public async Task<ResponseResult<IEnumerable<GenderModel>>> Get()
    {
      return await GetListGender();
    }

    private async Task<ResponseResult<IEnumerable<GenderModel>>> GetListGender()
    {
      var genders = await _hrisListApi.SelectGender(null);

      return new ResponseResult<IEnumerable<GenderModel>>(genders);
    }

    [HttpPost]
    public async Task<ResponseResult<IEnumerable<GenderModel>>> Post([FromBody] GenderModel gender)
    {
      if (gender.Id.HasValue && gender.Id.Value > 0) gender.UpdatedBy = CurrentUser;
      else gender.CreatedBy = CurrentUser;

      var genderId = await _hrisListApi.SaveGender(gender);

      if (genderId > 0) return await GetListGender();

      return new ResponseResult<IEnumerable<GenderModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<IEnumerable<GenderModel>>> Delete([FromBody] GenderModel gender)
    {
      var genderId = await _hrisListApi.DeleteGender(gender.Id);

      if (genderId > 0) return await GetListGender();

      return new ResponseResult<IEnumerable<GenderModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<bool>> Status([FromBody] GenderModel gender)
    {
      var genderId = await _hrisListApi.ToggleGenderStatus(gender.Id);

      return genderId > 0
        ? new ResponseResult<bool>(true, ResultCode.Success, null)
        : new ResponseResult<bool>(false, ResultCode.Error, null);
    }
  }
}
