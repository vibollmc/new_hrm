using Hris.Common.Business.Domains;
using Hris.Database.Entities;

namespace Hris.Common.Persistence.Transformations
{
    public static class RoleTransformations
    {
        public static MDRole Transform(this Role role)
        {
            return role == null
                ? null
                : new MDRole
                {
                    Id = role.Id,
                    Name = role.Name,
                    Status = role.Status.Transform()
                };
        }

        public static Role Transform(this MDRole role)
        {
            return role == null ? null : new Role(role.Id, role.Name, role.Status.Transform());
        }

        public static void UpdateValue(this MDRole role, Role value)
        {
            if (value == null) return;
            if (role == null) role = new MDRole {Id = value.Id};

            role.Name = value.Name;
            role.Status = value.Status.Transform();
        }
    }
}
