using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.Shared.Enum;
using Hris.Shared.Province;

namespace Hris.List.Api
{
    public partial interface IListApi
    {

        /// <summary>
        /// Save Province
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        Task<int?> SaveProvince(ProvinceModel province);

        /// <summary>
        /// Select Province
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProvinceModel>> SelectProvince();

        /// <summary>
        /// Select Province
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<ProvinceModel>> SelectProvince(Status status);

        /// <summary>
        /// Toggle Province status
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        Task<int?> ToggleProvinceStatus(ProvinceModel province);

        /// <summary>
        /// Delete Province
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        Task<int?> DeleteProvince(ProvinceModel province);

    }
}
