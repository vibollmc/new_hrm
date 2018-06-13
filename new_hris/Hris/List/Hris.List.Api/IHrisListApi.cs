using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.Shared.Enum;
using Hris.Shared.Gender;

namespace Hris.List.Api
{
    public interface IHrisListApi
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
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<GenderModel>> SelectGender(Status? status);

        /// <summary>
        /// Toggle gender status
        /// </summary>
        /// <param name="genderId"></param>
        /// <returns></returns>
        Task<int?> ToggleGenderStatus(int? genderId);

        /// <summary>
        /// Delete gender
        /// </summary>
        /// <param name="genderId"></param>
        /// <returns></returns>
        Task<int?> DeleteGender(int? genderId);
        #endregion gender
    }
}
