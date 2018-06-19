using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Api;
using Hris.Shared;
using Hris.Shared.Enum;
using Hris.Shared.Province;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Web.Main.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class ProvinceController : BaseController
  {
    private readonly IListApi _listApi;

    public ProvinceController(IListApi listApi)
    {
      _listApi = listApi;
    }

    [HttpGet("{status?}")]
    public async Task<ResponseResult<IEnumerable<ProvinceModel>>> Get(Status? status)
    {
      return await GetListProvince(status);
    }

    private async Task<ResponseResult<IEnumerable<ProvinceModel>>> GetListProvince()
    {
      return await GetListProvince(null);
    }

    private async Task<ResponseResult<IEnumerable<ProvinceModel>>> GetListProvince(Status? status)
    {
      IEnumerable<ProvinceModel> provinces;
      if (status != null)
        provinces = await _listApi.SelectProvince(status.Value);
      else
        provinces = await _listApi.SelectProvince();
      return new ResponseResult<IEnumerable<ProvinceModel>>(provinces);
    }

    [HttpPost]
    public async Task<ResponseResult<IEnumerable<ProvinceModel>>> Post([FromBody] ProvinceModel province)
    {
      if (province.Id.HasValue && province.Id.Value > 0) province.UpdatedBy = CurrentUser;
      else province.CreatedBy = CurrentUser;

      var provinceId = await _listApi.SaveProvince(province);

      if (provinceId > 0) return await GetListProvince();

      return new ResponseResult<IEnumerable<ProvinceModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<IEnumerable<ProvinceModel>>> Delete([FromBody] ProvinceModel province)
    {
      province.DeletedBy = CurrentUser;
      var provinceId = await _listApi.DeleteProvince(province);

      if (provinceId > 0) return await GetListProvince();

      return new ResponseResult<IEnumerable<ProvinceModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<bool>> Status([FromBody] ProvinceModel province)
    {
      province.UpdatedBy = CurrentUser;
      var provinceId = await _listApi.ToggleProvinceStatus(province);

      return provinceId > 0
        ? new ResponseResult<bool>(true, ResultCode.Success, null)
        : new ResponseResult<bool>(false, ResultCode.Error, null);
    }
  }
}
