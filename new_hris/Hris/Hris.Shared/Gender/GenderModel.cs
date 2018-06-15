using Hris.Shared.Enum;

namespace Hris.Shared.Gender
{
    public class GenderModel : BaseModel
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public Status Status { get; set; }
    }
}
