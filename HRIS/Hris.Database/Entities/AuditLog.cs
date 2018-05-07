using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Hris.Database.Enums;

namespace Hris.Database.Entities
{
    public class AuditLog: Base
    {
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string IpAddress { get; set; }
        [MaxLength(100)]
        public string Client { get; set; }
        [MaxLength(500)]
        public string Device { get; set; }
        [MaxLength(100)]
        public string Service { get; set; }
        [MaxLength(100)]
        public string Action { get; set; }
        public int? Duration { get; set; }
        [MaxLength(1000)]
        public string Parameter { get; set; }
        [MaxLength(5000)]
        public string Response { get; set; }
        public AuditLogType LogType { get; set; }
        [MaxLength(1000)]
        public string Message { get; set; }
    }
}
