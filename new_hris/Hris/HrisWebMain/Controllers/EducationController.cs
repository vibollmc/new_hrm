using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Api;
using Hris.Shared;
using Hris.Shared.Education;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Web.Main.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class EducationController : BaseController
  {
    private readonly IListApi _listApi;

    public EducationController(IListApi listApi)
    {
      _listApi = listApi;
    }

    [HttpGet]
    public async Task<ResponseResult<IEnumerable<EducationModel>>> Get()
    {
      return await GetListEducation();
    }

    private async Task<ResponseResult<IEnumerable<EducationModel>>> GetListEducation()
    {
      var educations = await _listApi.SelectEducation();

      return new ResponseResult<IEnumerable<EducationModel>>(educations);
    }

    [HttpPost]
    public async Task<ResponseResult<IEnumerable<EducationModel>>> Post([FromBody] EducationModel education)
    {
      if (education.Id.HasValue && education.Id.Value > 0) education.UpdatedBy = CurrentUser;
      else education.CreatedBy = CurrentUser;

      var educationId = await _listApi.SaveEducation(education);

      if (educationId > 0) return await GetListEducation();

      return new ResponseResult<IEnumerable<EducationModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<IEnumerable<EducationModel>>> Delete([FromBody] EducationModel education)
    {
      education.DeletedBy = CurrentUser;
      var educationId = await _listApi.DeleteEducation(education);

      if (educationId > 0) return await GetListEducation();

      return new ResponseResult<IEnumerable<EducationModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<bool>> Status([FromBody] EducationModel education)
    {
      education.UpdatedBy = CurrentUser;
      var educationId = await _listApi.ToggleEducationStatus(education);

      return educationId > 0
        ? new ResponseResult<bool>(true, ResultCode.Success, null)
        : new ResponseResult<bool>(false, ResultCode.Error, null);
    }
  }
}
