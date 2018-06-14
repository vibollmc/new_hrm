using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Hris.Common.Business.Services.Implementations;

namespace Hris.Common.Api
{
    public partial class CommonApi: ICommonApi
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public CommonApi(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
    }
}
