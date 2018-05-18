namespace Hris.Database.Entities.Common
{
    public class MDActionLanguage
    {
        public int? ActionId { get; set; }
        public int? LanguageId { get; set; }
        public string Name { get; set; }

        public MDAction Action { get; set; }
        public MDLanguage Language { get; set; }
    }
}
