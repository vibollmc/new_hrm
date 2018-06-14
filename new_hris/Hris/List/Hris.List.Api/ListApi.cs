using AutoMapper;
using Hris.List.Business.Services.Interfaces;

namespace Hris.List.Api
{
    public partial class ListApi : IListApi
    {
        private readonly IGenderService _genderService;
        private readonly IMapper _mapper;

        public ListApi(IGenderService genderService, IMapper mapper)
        {
            _genderService = genderService;
            _mapper = mapper;
        }
    }
}
