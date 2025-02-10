using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Empower.Utilities
{
    public static class LanguageConfigure
    {
        private readonly static List<Language> acceptedLanguages = new()
        {
            new Language{ Code="en", Title = "English", LanguageTitle = "English - EN"},
            new Language{ Code="ar", Title = "Arabic", LanguageTitle = "العربية - AR"},
            new Language{ Code="de", Title = "German", LanguageTitle = "Deutsch - DE"},
            new Language{ Code="es", Title = "Spanish", LanguageTitle = "español - ES"},
            new Language{ Code="fr", Title = "French", LanguageTitle = "Français - FR"},
            new Language{ Code="in", Title = "Hindi", LanguageTitle = "हिंदी - IN"},
            new Language{ Code="ur", Title = "Urdu", LanguageTitle = "اردو - UR"},
            new Language{ Code="zh", Title = "Chinese", LanguageTitle ="中文 (简体) - ZH"}
        };


        public static List<Language> GetLanguages()
        {
            return acceptedLanguages;
        }

        public static string GetLocalizedValue(string languageCode, string key, params object[] args)
        {
            var fileSuffix = "";
            if (acceptedLanguages.Any(x => x.Code == languageCode)) fileSuffix = $"-{languageCode}";
            string fileName = $"{typeof(LanguageConfigure).Namespace}.Files.language{fileSuffix}.xml";
            var resourceStream = typeof(LanguageConfigure).Assembly.GetManifestResourceStream(fileName); //typeof(LanguageConfigure).GetType().Assembly.GetManifestResourceStream(fileName);
            XmlDocument xml = new();
            if (resourceStream == null) return FormatWithOptionalArgs($"[{key}]", args);
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                xml.Load(resourceStream);
            }
            var keyValue = xml.SelectSingleNode($"//localizationDictionary/texts/text[@name='{key}']")?.InnerText;
            if (string.IsNullOrEmpty(keyValue)) return FormatWithOptionalArgs($"[{key}]", args);
            return FormatWithOptionalArgs(keyValue, args);
        }

        private static string FormatWithOptionalArgs(string format, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return format;
            }
            else
            {
                return string.Format(format, args);
            }
        }
    }

    public sealed class Language
    {
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string LanguageTitle { get; set; } = string.Empty;
    }



}
