using System;
using System.Collections.Generic;
using System.Text;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Domains
{
    public class Base
    {
        public int? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public Status Status { get; set; }
    }
}
