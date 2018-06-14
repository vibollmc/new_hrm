﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Services.Interfaces
{
    public interface IGenderService
    {
        /// <summary>
        /// Save Gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        Task<int?> Save(Gender gender);

        /// <summary>
        /// Select Gender
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Gender>> Select();

        /// <summary>
        /// Select gender
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<Gender>> Select(Status status);

        /// <summary>
        /// Toggle gender status
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        Task<int?> ToggleStatus(Gender gender);

        /// <summary>
        /// Delete gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        Task<int?> Delete(Gender gender);
    }
}
