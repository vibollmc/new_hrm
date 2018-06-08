using System;
using System.Collections.Generic;
using System.Text;
using Hris.Database.Entities.List;
using Hris.List.Business.Domains;

namespace Hris.List.Persistence.Transformations
{
    public static class GenderTransformations
    {
        public static MDGender Transform(this Gender gender)
        {
            return gender == null
                ? null
                : new MDGender
                {
                    Id = gender.Id,
                    Status = gender.Status.Transform(),
                    Name = gender.Name,
                    NameEn = gender.NameEn
                };
        }

        public static Gender Transform(this MDGender gender)
        {
            return gender == null
                ? null
                : new Gender(gender.Id, gender.Name, gender.NameEn, gender.Status.Transform(), gender.CreatedAt, gender.CreatedBy,
                    gender.UpdatedAt, gender.UpdatedBy, gender.DeletedAt, gender.DeletedBy);
        }

        public static void UpdateValue(this MDGender gender, Gender value)
        {
            if (value == null) return;
            if (gender == null) gender = new MDGender {Id = value.Id};

            gender.Name = value.Name;
            gender.NameEn = value.NameEn;
            gender.Status = value.Status.Transform();
        }
    }
}
