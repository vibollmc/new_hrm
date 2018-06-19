using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Api;
using Hris.Shared;
using Hris.Shared.Enum;
using Hris.Shared.Gender;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Web.Main.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class GenderController : BaseController
  {
    private readonly IListApi _listApi;

    public GenderController(IListApi listApi)
    {
      _listApi = listApi;
    }

    [HttpGet("{status?}")]
    public async Task<ResponseResult<IEnumerable<GenderModel>>> Get(Status? status)
    {
      return await GetListGender(status);
    }

    private async Task<ResponseResult<IEnumerable<GenderModel>>> GetListGender()
    {
      return await GetListGender(null);
    }

    private async Task<ResponseResult<IEnumerable<GenderModel>>> GetListGender(Status? status)
    {
      IEnumerable<GenderModel> genders;
      if (status != null)
        genders = await _listApi.SelectGender(status.Value);
      else
        genders = await _listApi.SelectGender();
      return new ResponseResult<IEnumerable<GenderModel>>(genders);
    }

    [HttpPost]
    public async Task<ResponseResult<IEnumerable<GenderModel>>> Post([FromBody] GenderModel gender)
    {
      if (gender.Id.HasValue && gender.Id.Value > 0) gender.UpdatedBy = CurrentUser;
      else gender.CreatedBy = CurrentUser;

      var genderId = await _listApi.SaveGender(gender);

      if (genderId > 0) return await GetListGender();

      return new ResponseResult<IEnumerable<GenderModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<IEnumerable<GenderModel>>> Delete([FromBody] GenderModel gender)
    {
      gender.DeletedBy = CurrentUser;
      var genderId = await _listApi.DeleteGender(gender);

      if (genderId > 0) return await GetListGender();

      return new ResponseResult<IEnumerable<GenderModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<bool>> Status([FromBody] GenderModel gender)
    {
      gender.UpdatedBy = CurrentUser;
      var genderId = await _listApi.ToggleGenderStatus(gender);

      return genderId > 0
        ? new ResponseResult<bool>(true, ResultCode.Success, null)
        : new ResponseResult<bool>(false, ResultCode.Error, null);
    }
  }
}
