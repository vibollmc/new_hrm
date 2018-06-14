using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hris.Database.Entities
{
    public class Base
    {
        public Base()
        {
            CreatedAt = DateTime.UtcNow;
        }
        [Key]
        public int? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        [MaxLength(20)]
        public string CreatedBy { get; set; }
        [MaxLength(20)]
        public string UpdatedBy { get; set; }
        [MaxLength(20)]
        public string DeletedBy { get; set; }
    }
}
