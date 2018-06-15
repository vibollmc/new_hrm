using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.Shared.Enum;
using Hris.Shared.District;

namespace Hris.List.Api
{
    public partial interface IListApi
    {

        /// <summary>
        /// Save District
        /// </summary>
        /// <param name="district"></param>
        /// <returns></returns>
        Task<int?> SaveDistrict(DistrictModel district);

        /// <summary>
        /// Select District
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DistrictModel>> SelectDistrict();

        /// <summary>
        /// Select District
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<DistrictModel>> SelectDistrict(Status status);

        /// <summary>
        /// Toggle District status
        /// </summary>
        /// <param name="district"></param>
        /// <returns></returns>
        Task<int?> ToggleDistrictStatus(DistrictModel district);

        /// <summary>
        /// Delete District
        /// </summary>
        /// <param name="district"></param>
        /// <returns></returns>
        Task<int?> DeleteDistrict(DistrictModel district);

    }
}
