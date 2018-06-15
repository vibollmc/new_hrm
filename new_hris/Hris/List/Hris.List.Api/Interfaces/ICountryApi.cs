using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.Shared.Enum;
using Hris.Shared.Country;

namespace Hris.List.Api
{
    public partial interface IListApi
    {

        /// <summary>
        /// Save Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        Task<int?> SaveCountry(CountryModel country);

        /// <summary>
        /// Select Country
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CountryModel>> SelectCountry();

        /// <summary>
        /// Select Country
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<CountryModel>> SelectCountry(Status status);

        /// <summary>
        /// Toggle Country status
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        Task<int?> ToggleCountryStatus(CountryModel country);

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        Task<int?> DeleteCountry(CountryModel country);

    }
}
