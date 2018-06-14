using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.Shared.Enum;
using Hris.Shared.Gender;
using Hris.Shared.Nation;

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
        #endregion gender

        #region Nation

        /// <summary>
        /// Save Nation
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        Task<int?> Save(NationModel nation);

        /// <summary>
        /// Select Nation
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<NationModel>> Select();

        /// <summary>
        /// Select Nation
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<NationModel>> Select(Status status);

        /// <summary>
        /// Toggle Nation status
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        Task<int?> ToggleStatus(NationModel nation);

        /// <summary>
        /// Delete Nation
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        Task<int?> Delete(NationModel nation);

        #endregion
    }
}
