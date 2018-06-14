using System;
using System.Collections.Generic;
using System.Text;
using Hris.Database.Enums;

namespace Hris.Database.Entities.List
{
    public class MDDistrict : Base
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public MDStatus Status { get; set; }
        public int? ProvinceId { get; set; }
    }
}
