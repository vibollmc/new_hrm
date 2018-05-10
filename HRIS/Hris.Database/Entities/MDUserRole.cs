using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hris.Database.Entities
{
    public class MDUserRole
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }

        public MDUser User { get; set; }
        public MDRole Role { get; set; }
    }
}
