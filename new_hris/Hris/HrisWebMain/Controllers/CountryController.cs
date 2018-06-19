using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Api;
using Hris.Shared;
using Hris.Shared.Enum;
using Hris.Shared.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Web.Main.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class CountryController : BaseController
  {
    private readonly IListApi _listApi;

    public CountryController(IListApi listApi)
    {
      _listApi = listApi;
    }

    [HttpGet("{status?}")]
    public async Task<ResponseResult<IEnumerable<CountryModel>>> Get(Status? status)
    {
      return await GetListCountry(status);
    }

    private async Task<ResponseResult<IEnumerable<CountryModel>>> GetListCountry()
    {
      return await GetListCountry(null);
    }

    private async Task<ResponseResult<IEnumerable<CountryModel>>> GetListCountry(Status? status)
    {
      IEnumerable<CountryModel> countrys;
      if (status != null)
        countrys = await _listApi.SelectCountry(status.Value);
      else
        countrys = await _listApi.SelectCountry();
      return new ResponseResult<IEnumerable<CountryModel>>(countrys);
    }

    [HttpPost]
    public async Task<ResponseResult<IEnumerable<CountryModel>>> Post([FromBody] CountryModel country)
    {
      if (country.Id.HasValue && country.Id.Value > 0) country.UpdatedBy = CurrentUser;
      else country.CreatedBy = CurrentUser;

      var countryId = await _listApi.SaveCountry(country);

      if (countryId > 0) return await GetListCountry();

      return new ResponseResult<IEnumerable<CountryModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<IEnumerable<CountryModel>>> Delete([FromBody] CountryModel country)
    {
      country.DeletedBy = CurrentUser;
      var countryId = await _listApi.DeleteCountry(country);

      if (countryId > 0) return await GetListCountry();

      return new ResponseResult<IEnumerable<CountryModel>>(null, ResultCode.Error, null);
    }

    [HttpPost("[action]")]
    public async Task<ResponseResult<bool>> Status([FromBody] CountryModel country)
    {
      country.UpdatedBy = CurrentUser;
      var countryId = await _listApi.ToggleCountryStatus(country);

      return countryId > 0
        ? new ResponseResult<bool>(true, ResultCode.Success, null)
        : new ResponseResult<bool>(false, ResultCode.Error, null);
    }
  }
}
