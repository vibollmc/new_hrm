using System;
using System.Collections.Generic;
using System.Text;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Domains
{
    public class Gender : Base
    {
        public Gender(int? id, string name, string nameEn, Status status, DateTime? createdAt,
            DateTime? updateAt) : base(id, createdAt, updateAt, status)
        {
            Name = name;
            NameEn = nameEn;
        }

        public string Name { get; }
        public string NameEn { get; set; }
    }
}
