using Hris.Common.Business.Enums;

namespace Hris.Common.Business.Domains
{
    public class Action
    {
        public Action(int? id, string key, string icon, string name, string eventAction, int order, Status status)
        {
            Id = id;
            Key = key;
            Icon = icon;
            Name = name;
            Event = eventAction;
            Order = order;
            Status = status;
        }
        public int? Id { get; }
        public string Key { get; }
        public string Icon { get; }
        public string Name { get; }
        public string Event { get; }
        public int Order { get; }
        public Status Status { get; }
    }
}
