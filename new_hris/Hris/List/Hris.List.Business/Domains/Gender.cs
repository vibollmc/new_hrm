using System;
using System.Collections.Generic;
using System.Text;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Domains
{
    public class Gender : Base
    {
        public Gender(int? id, string name, string nameEn, Status status, DateTime? createdAt, string createdBy,
            DateTime? updateAt, string updateBy, DateTime? deletedAt, string deletedBy) : base(id, status, createdAt, createdBy, updateAt, updateBy, deletedAt, deletedBy)
        {
            Name = name;
            NameEn = nameEn;
        }

        public string Name { get; }
        public string NameEn { get; set; }
    }
}
