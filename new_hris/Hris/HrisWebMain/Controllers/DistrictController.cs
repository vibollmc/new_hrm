using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Api;
using Hris.Shared;
using Hris.Shared.Enum;
using Hris.Shared.District;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Web.Main.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class DistrictController : BaseController
  {
    private readonly IListApi _listApi;

    public DistrictController(IListApi listApi)
    {
      _listApi = listApi;
    }

    [HttpGet("{status?}")]
    public async Task<ResponseResult<IEnumerable<DistrictModel>>> Get(Status? status)
    {
      return await GetListDistrict(status);
    }

    private async Task<ResponseResult<IEnumerable<DistrictModel>>> GetListDistrict()
    {
      return await GetListDistrict(null);
    }

    private async Task<ResponseResult<IEnumerable<DistrictModel>>> GetListDistrict(Status? status)
    {
      IEnumerable<DistrictModel> districts;
      if (status != null)
        districts = await _listApi.SelectDistrict(status.Value);
      else
        districts = await _listApi.SelectDistrict();
      return new ResponseResult<IEnumerable<DistrictModel>>(districts);
    }

    [HttpPost]
    public async Task<ResponseResult<IEnumerable<DistrictModel>>> Post([FromBody] DistrictModel district)
    {
      if (district.Id.HasValue && district.Id.Value > 0) district.UpdatedBy = CurrentUser;
      else district.CreatedBy = CurrentUser;

      var districtId = await _listApi.SaveDistrict(district);

      if (districtId > 0) return await GetListDistrict();

      return new ResponseResult<IEnumerable<DistrictModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<IEnumerable<DistrictModel>>> Delete([FromBody] DistrictModel district)
    {
      district.DeletedBy = CurrentUser;
      var districtId = await _listApi.DeleteDistrict(district);

      if (districtId > 0) return await GetListDistrict();

      return new ResponseResult<IEnumerable<DistrictModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<bool>> Status([FromBody] DistrictModel district)
    {
      district.UpdatedBy = CurrentUser;
      var districtId = await _listApi.ToggleDistrictStatus(district);

      return districtId > 0
        ? new ResponseResult<bool>(true, ResultCode.Success, null)
        : new ResponseResult<bool>(false, ResultCode.Error, null);
    }
  }
}
