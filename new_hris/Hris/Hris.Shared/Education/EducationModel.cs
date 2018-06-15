using Hris.Shared.Enum;

namespace Hris.Shared.Education
{
    public class EducationModel : BaseModel
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public Status Status { get; set; }
    }
}
