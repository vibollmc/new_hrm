using Hris.Common.Business.Domains;
using Hris.Database.Entities;
using Hris.Database.Entities.Common;

namespace Hris.Common.Persistence.Transformations
{
    public static class LanguageTransformations
    {
        public static MDLanguage Transform(this Language language)
        {
            return language == null
                ? null
                : new MDLanguage
                {
                    Id = language.Id,
                    Code = language.Code,
                    Name = language.Name,
                    IsDefault = language.IsDefault,
                    Status = language.Status.Transform()
                };
        }

        public static Language Transform(this MDLanguage language)
        {
            return language == null
                ? null
                : new Language(language.Id, language.Code, language.Name, language.IsDefault,
                    language.Status.Transform());
        }

        public static void UpdateValue(this MDLanguage language, Language value)
        {
            if (value == null) return;
            if (language == null)
                language = new MDLanguage {Id = value.Id};
            
            language.Code = value.Code;
            language.Name = value.Name;
            language.IsDefault = value.IsDefault;
            language.Status = value.Status.Transform();
        }
    }
}
