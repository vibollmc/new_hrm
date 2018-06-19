using Hris.Shared.Enum;

namespace Hris.Shared.Province
{
    public class ProvinceModel : BaseModel
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public Status Status { get; set; }
    }
}
