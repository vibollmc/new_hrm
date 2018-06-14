using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hris.List.Api.Transformations;
using Hris.List.Business.Services.Interfaces;
using Hris.Shared.Enum;
using Hris.Shared.Gender;

namespace Hris.List.Api
{
    public partial class ListApi : IListApi
    {
        private readonly IGenderService _genderService;

        public ListApi(IGenderService genderService)
        {
            _genderService = genderService;
        }
    }
}
