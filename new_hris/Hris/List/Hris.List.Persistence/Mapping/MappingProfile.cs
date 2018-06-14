using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Hris.Database.Entities.List;
using Hris.Database.Enums;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;

namespace Hris.List.Persistence.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Gender, MDGender>();
            //CreateMap<MDGender, Gender>();

            //CreateMap<Status, MDStatus>();
            CreateMap<MDStatus, Status>()
                .ConvertUsing(value => value == MDStatus.Active ? Status.Active : Status.Inactive);
        }
    }
}
