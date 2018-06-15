using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.Shared.Enum;
using Hris.Shared.Education;

namespace Hris.List.Api
{
    public partial interface IListApi
    {

        /// <summary>
        /// Save Education
        /// </summary>
        /// <param name="education"></param>
        /// <returns></returns>
        Task<int?> SaveEducation(EducationModel education);

        /// <summary>
        /// Select Education
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EducationModel>> SelectEducation();

        /// <summary>
        /// Select Education
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<EducationModel>> SelectEducation(Status status);

        /// <summary>
        /// Toggle Education status
        /// </summary>
        /// <param name="education"></param>
        /// <returns></returns>
        Task<int?> ToggleEducationStatus(EducationModel education);

        /// <summary>
        /// Delete Education
        /// </summary>
        /// <param name="education"></param>
        /// <returns></returns>
        Task<int?> DeleteEducation(EducationModel education);

    }
}
