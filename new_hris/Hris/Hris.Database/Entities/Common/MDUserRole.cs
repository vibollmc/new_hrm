namespace Hris.Database.Entities.Common
{
    public class MDUserRole
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }

        public MDUser User { get; set; }
        public MDRole Role { get; set; }
    }
}
