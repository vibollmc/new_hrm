using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.Shared.Enum;
using Hris.Shared.Gender;

namespace Hris.List.Api
{
    public interface IListApi
    {
        #region gender
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
        #endregion gender
    }
}
