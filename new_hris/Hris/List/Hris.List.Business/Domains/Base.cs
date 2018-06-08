using System;
using System.Collections.Generic;
using System.Text;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Domains
{
    public class Base
    {
        public Base(int? id, Status status, DateTime? createdAt, string createdBy, DateTime? updatedAt, string updatedBy, DateTime? deletedAt, string deletedBy)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Status = status;
            DeletedAt = deletedAt;
            CreatedBy = createdBy;
            UpdatedBy = updatedBy;
            DeletedBy = deletedBy;
        }

        public int? Id { get; }
        public DateTime? CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
        public DateTime? DeletedAt { get; }
        public string CreatedBy { get; }
        public string UpdatedBy { get; }
        public string DeletedBy { get; }
        public Status Status { get; }
    }
}
