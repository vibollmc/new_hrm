using System;
using System.Collections.Generic;
using System.Text;
using Hris.Shared.Enum;

namespace Hris.Shared.Gender
{
    public class GenderViewModel : BaseModel
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public Status Status { get; set; }
    }
}
