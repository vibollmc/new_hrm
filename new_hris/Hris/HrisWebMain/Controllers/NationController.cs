using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Api;
using Hris.Shared;
using Hris.Shared.Enum;
using Hris.Shared.Nation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Web.Main.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class NationController : BaseController
  {
    private readonly IListApi _listApi;

    public NationController(IListApi listApi)
    {
      _listApi = listApi;
    }

    [HttpGet("{status?}")]
    public async Task<ResponseResult<IEnumerable<NationModel>>> Get(Status? status)
    {
      return await GetListNation(status);
    }

    private async Task<ResponseResult<IEnumerable<NationModel>>> GetListNation()
    {
      return await GetListNation(null);
    }

    private async Task<ResponseResult<IEnumerable<NationModel>>> GetListNation(Status? status)
    {
      IEnumerable<NationModel> nations;
      if (status != null)
        nations = await _listApi.SelectNation(status.Value);
      else
        nations = await _listApi.SelectNation();
      return new ResponseResult<IEnumerable<NationModel>>(nations);
    }

    [HttpPost]
    public async Task<ResponseResult<IEnumerable<NationModel>>> Post([FromBody] NationModel nation)
    {
      if (nation.Id.HasValue && nation.Id.Value > 0) nation.UpdatedBy = CurrentUser;
      else nation.CreatedBy = CurrentUser;

      var nationId = await _listApi.SaveNation(nation);

      if (nationId > 0) return await GetListNation();

      return new ResponseResult<IEnumerable<NationModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<IEnumerable<NationModel>>> Delete([FromBody] NationModel nation)
    {
      nation.DeletedBy = CurrentUser;
      var nationId = await _listApi.DeleteNation(nation);

      if (nationId > 0) return await GetListNation();

      return new ResponseResult<IEnumerable<NationModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<bool>> Status([FromBody] NationModel nation)
    {
      nation.UpdatedBy = CurrentUser;
      var nationId = await _listApi.ToggleNationStatus(nation);

      return nationId > 0
        ? new ResponseResult<bool>(true, ResultCode.Success, null)
        : new ResponseResult<bool>(false, ResultCode.Error, null);
    }
  }
}
