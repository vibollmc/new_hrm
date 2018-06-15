using Hris.Shared.Enum;

namespace Hris.Shared.Country
{
    public class CountryModel : BaseModel
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public Status Status { get; set; }
    }
}
