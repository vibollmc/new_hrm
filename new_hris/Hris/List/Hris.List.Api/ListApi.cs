using System;
using AutoMapper;

namespace Hris.List.Api
{
    public partial class ListApi : IListApi
    {
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public ListApi(IMapper mapper, IServiceProvider serviceProvider)
        {
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }
    }
}
