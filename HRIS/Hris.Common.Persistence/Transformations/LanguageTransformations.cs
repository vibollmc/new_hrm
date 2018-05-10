using Hris.Database.Entities;
using Hris.Database.Enums;

namespace Hris.Common.Persistence.Transformations
{
    public static class LanguageTransformations
    {
        public static Language Transform(this Business.Domains.Language language)
        {
            return new Language
            {
                Id = language.Id,
                Code = language.Code,
                Name = language.Name,
                IsDefault = language.IsDefault,
                Status = language.Status.Parse<Status, Business.Enums.Status>()
            };
        }

        public static Business.Domains.Language Transform(this Language language)
        {
            return new Business.Domains.Language(language.Id, language.Code, language.Name, language.IsDefault,
                language.Status.Parse<Business.Enums.Status, Status>());
        }
    }
}
