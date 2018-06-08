namespace Hris.Database.Entities.Common
{
    public class MDFunctionLanguage
    {
        public int? FunctionId { get; set; }
        public int? LanguageId { get; set; }
        public string Name { get; set; }

        public MDFunction Function { get; set; }
        public MDLanguage Language { get; set; }
    }
}
