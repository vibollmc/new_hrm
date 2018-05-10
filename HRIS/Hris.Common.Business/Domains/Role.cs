using System;
using System.Collections.Generic;
using System.Text;
using Hris.Common.Business.Enums;

namespace Hris.Common.Business.Domains
{
    public class Role
    {
        public Role(int? id, string name, Status status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public int? Id { get; }
        public string Name { get; }
        public Status Status { get; }
    }
}
