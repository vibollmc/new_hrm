using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Api;
using Hris.Shared;
using Hris.Shared.Enum;
using Hris.Shared.Ward;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Web.Main.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class WardController : BaseController
  {
    private readonly IListApi _listApi;

    public WardController(IListApi listApi)
    {
      _listApi = listApi;
    }

    [HttpGet("{status?}")]
    public async Task<ResponseResult<IEnumerable<WardModel>>> Get(Status? status)
    {
      return await GetListWard(status);
    }

    private async Task<ResponseResult<IEnumerable<WardModel>>> GetListWard()
    {
      return await GetListWard(null);
    }

    private async Task<ResponseResult<IEnumerable<WardModel>>> GetListWard(Status? status)
    {
      IEnumerable<WardModel> wards;
      if (status != null)
        wards = await _listApi.SelectWard(status.Value);
      else
        wards = await _listApi.SelectWard();
      return new ResponseResult<IEnumerable<WardModel>>(wards);
    }

    [HttpPost]
    public async Task<ResponseResult<IEnumerable<WardModel>>> Post([FromBody] WardModel ward)
    {
      if (ward.Id.HasValue && ward.Id.Value > 0) ward.UpdatedBy = CurrentUser;
      else ward.CreatedBy = CurrentUser;

      var wardId = await _listApi.SaveWard(ward);

      if (wardId > 0) return await GetListWard();

      return new ResponseResult<IEnumerable<WardModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<IEnumerable<WardModel>>> Delete([FromBody] WardModel ward)
    {
      ward.DeletedBy = CurrentUser;
      var wardId = await _listApi.DeleteWard(ward);

      if (wardId > 0) return await GetListWard();

      return new ResponseResult<IEnumerable<WardModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<bool>> Status([FromBody] WardModel ward)
    {
      ward.UpdatedBy = CurrentUser;
      var wardId = await _listApi.ToggleWardStatus(ward);

      return wardId > 0
        ? new ResponseResult<bool>(true, ResultCode.Success, null)
        : new ResponseResult<bool>(false, ResultCode.Error, null);
    }
  }
}
