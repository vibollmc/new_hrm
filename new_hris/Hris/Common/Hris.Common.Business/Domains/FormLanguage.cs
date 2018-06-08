using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.Common.Business.Domains
{
    public class FormLanguage
    {
        public FormLanguage(int? id, int? functionId, string functionKey, int? languageId, string key, string value)
        {
            Id = id;
            FunctionId = functionId;
            FunctionKey = functionKey;
            LanguageId = languageId;
            Key = key;
            Value = value;
        }

        public int? Id { get; }
        public int? FunctionId { get; }
        public string FunctionKey { get; }
        public int? LanguageId { get; }
        public string Key { get; }
        public string Value { get; }
    }
}
