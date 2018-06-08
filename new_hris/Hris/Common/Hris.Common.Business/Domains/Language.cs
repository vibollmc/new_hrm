using Hris.Common.Business.Enums;

namespace Hris.Common.Business.Domains
{
    public class Language
    {
        public Language(int? id, string code, string name, bool isDefault, Status status)
        {
            Id = id;
            Code = code;
            Name = name;
            IsDefault = isDefault;
            Status = status;
        }

        public int? Id { get; }
        public string Code { get; }
        public string Name { get; }
        public bool IsDefault { get; }
        public Status Status { get; }
    }
}
