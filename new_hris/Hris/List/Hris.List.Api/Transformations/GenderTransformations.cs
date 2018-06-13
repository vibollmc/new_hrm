using System;
using System.Collections.Generic;
using System.Text;
using Hris.List.Business.Domains;
using Hris.Shared.Gender;

namespace Hris.List.Api.Transformations
{
    public static class GenderTransformations
    {
        public static GenderModel Transform(this Gender gender)
        {
            return gender == null
                ? null
                : new GenderModel
                {
                    Id = gender.Id,
                    Status = gender.Status.Transform(),
                    Name = gender.Name,
                    NameEn = gender.NameEn,
                    DeletedAt = gender.DeletedAt,
                    CreatedBy = gender.CreatedBy,
                    DeletedBy = gender.DeletedBy,
                    UpdatedBy = gender.UpdatedBy,
                    UpdatedAt = gender.UpdatedAt,
                    CreatedAt = gender.CreatedAt
                };
        }

        public static Gender Transform(this GenderModel gender)
        {
            return gender == null
                ? null
                : new Gender(gender.Id, gender.Name, gender.NameEn, gender.Status.Transform(), gender.CreatedAt, gender.CreatedBy,
                    gender.UpdatedAt, gender.UpdatedBy, gender.DeletedAt, gender.DeletedBy);
        }
    }
}
