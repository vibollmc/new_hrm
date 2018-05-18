using System;
using System.Collections.Generic;
using System.Text;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Domains
{
    public class Base
    {
        public Base(int? id, DateTime? createdAt, DateTime? updatedAt, Status status)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Status = status;
        }

        public int? Id { get; }
        public DateTime? CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
        public Status Status { get; }
    }
}
