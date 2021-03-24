using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MyLibraryProject.Localization
{
    public static class MyLibraryProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MyLibraryProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MyLibraryProjectLocalizationConfigurer).GetAssembly(),
                        "MyLibraryProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
