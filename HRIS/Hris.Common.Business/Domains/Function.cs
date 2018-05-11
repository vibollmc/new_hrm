using System;
using System.Collections.Generic;
using System.Text;
using Hris.Common.Business.Enums;

namespace Hris.Common.Business.Domains
{
    public class Function
    {
        public Function(int? id, string name, Module module, string key, string icon, int orderIndex, Status status)
        {
            Id = id;
            Name = name;
            Module = module;
            Key = key;
            Icon = icon;
            OrderIndex = orderIndex;
            Status = status;
        }

        public int? Id { get; }
        public string Name { get; }
        public Module Module { get; }
        public string Key { get; }
        public string Icon { get; }
        public int OrderIndex { get; }
        public Status Status { get; }
    }
}
