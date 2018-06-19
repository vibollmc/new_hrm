using Hris.Shared.Enum;

namespace Hris.Shared.District
{
    public class DistrictModel : BaseModel
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public int? ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceNameEn { get; set; }
        public Status Status { get; set; }
    }
}
