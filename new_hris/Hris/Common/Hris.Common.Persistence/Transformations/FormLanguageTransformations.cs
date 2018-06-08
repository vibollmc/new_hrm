using System;
using System.Collections.Generic;
using System.Text;
using Hris.Common.Business.Domains;
using Hris.Database.Entities;
using Hris.Database.Entities.Common;

namespace Hris.Common.Persistence.Transformations
{
    public static class FormLanguageTransformations
    {
        public static MDFormLanguage Transform(this FormLanguage formLanguage)
        {
            return formLanguage == null
                ? null
                : new MDFormLanguage
                {
                    Id = formLanguage.Id,
                    FunctionId =  formLanguage.FunctionId,
                    FunctionKey = formLanguage.FunctionKey,
                    Key = formLanguage.Key,
                    LanguageId = formLanguage.LanguageId,
                    Value = formLanguage.Value
                };
        }

        public static FormLanguage Transform(this MDFormLanguage formLanguage)
        {
            return formLanguage == null
                ? null
                : new FormLanguage(formLanguage.Id, formLanguage.FunctionId, formLanguage.FunctionKey,
                    formLanguage.LanguageId, formLanguage.Key, formLanguage.Value);
        }

        public static void UpdateValue(this MDFormLanguage formLanguage, FormLanguage value)
        {
            if (value == null) return;
            if (formLanguage == null) formLanguage = new MDFormLanguage {Id = value.Id};

            formLanguage.FunctionId = value.FunctionId;
            formLanguage.FunctionKey = value.FunctionKey;
            formLanguage.Key = value.Key;
            formLanguage.LanguageId = value.LanguageId;
            formLanguage.Value = value.Value;
        }
    }
}
