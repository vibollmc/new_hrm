namespace Hris.Database.Entities.Common
{
    public class MDRoleFunction
    {
        public int? RoleId { get; set; }
        public int? FunctionId { get; set; }
        
        public MDRole Role { get; set; }
        public MDFunction Function { get; set; }
    }
}
