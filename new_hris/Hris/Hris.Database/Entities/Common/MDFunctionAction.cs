namespace Hris.Database.Entities.Common
{
    public class MDFunctionAction
    {
        public int? FunctionId { get; set; }
        public int? ActionId { get; set; }

        public MDFunction Function { get; set; }
        public MDAction Action { get; set; }
    }
}
