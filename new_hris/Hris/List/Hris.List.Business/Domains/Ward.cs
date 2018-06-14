using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.List.Business.Domains
{
    public class Ward : Base
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public int? DistrictId { get; set; }
    }
}
