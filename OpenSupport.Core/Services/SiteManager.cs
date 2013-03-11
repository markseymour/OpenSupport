using OpenSupport.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace OpenSupport.Core.Services
{
    public static class SiteManager
    {
        private const string SettingsFileName = "Settings.txt";
        private static IEnumerable<SiteSettingsRecord> _allSites;

        static SiteManager()
        {
            var directory = FileManager.SiteDirectory;
            if (directory.Exists) return;
            directory.Create();
        }

        public static SiteSettingsRecord CurrentSite()
        {
            return LoadSite();
        }

        public static void SaveSite(SiteSettingsRecord settings)
        {
            var name = settings.SiteName ?? "Default";
            var path = Path.Combine(FileManager.SiteDirectory.FullName, name);
            Directory.CreateDirectory(path);
            var serializer = new JavaScriptSerializer();
            var content = serializer.Serialize(settings);
            var file = Path.Combine(path, SettingsFileName);
            File.WriteAllText(file, content);
        }

        public static SiteSettingsRecord LoadSite(string site = "Default")
        {
            return GetAllSites()
                .Where(x => x.SiteName.ToLowerInvariant() == site.ToLowerInvariant())
                .SingleOrDefault();
        }

        public static IEnumerable<SiteSettingsRecord> GetAllSites()
        {
            var serializer = new JavaScriptSerializer();

            foreach (var site in FileManager.SiteDirectory.GetDirectories())
            {
                var path = Path.Combine(site.FullName, SettingsFileName);
                if (!File.Exists(path))
                    continue;

                var fileContent = File.ReadAllText(path);
                var config = serializer.Deserialize(fileContent, typeof(SiteSettingsRecord));
                yield return (config as SiteSettingsRecord);
            }

        }

        public static bool IsSiteSetup()
        {
            return FileManager.SiteDirectory.Exists && FileManager.SiteDirectory.GetDirectories().Select(siteFolder => Path.Combine(siteFolder.FullName, SettingsFileName)).Any(File.Exists);
        }
    }
}