using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.Shared.Enum;
using Hris.Shared.Gender;

namespace Hris.List.Api
{
    public partial interface IListApi
    {
        /// <summary>
        /// Save Gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        Task<int?> SaveGender(GenderModel gender);

        /// <summary>
        /// Select Gender
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GenderModel>> SelectGender();

        /// <summary>
        /// Select Gender
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<GenderModel>> SelectGender(Status status);

        /// <summary>
        /// Toggle gender status
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        Task<int?> ToggleGenderStatus(GenderModel gender);

        /// <summary>
        /// Delete gender
        /// </summary>
        /// <returns></returns>
        Task<int?> DeleteGender(GenderModel gender);
    }
}
