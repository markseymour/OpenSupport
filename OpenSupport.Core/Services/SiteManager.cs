using OpenSupport.Core.Models;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace OpenSupport.Core.Services
{
    public static class SiteManager
    {
        private const string SettingsFileName = "Settings.txt";

        static SiteManager()
        {
            var directory = FileManager.SiteDirectory;
            if (directory.Exists) return;
            directory.Create();
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

        public static SiteSettingsRecord LoadSite()
        {
            var serializer = new JavaScriptSerializer();

            var path = Path.Combine(FileManager.SiteDirectory.FullName, SettingsFileName);
            if (File.Exists(path))
            {
                var fileContent = File.ReadAllText(path);
                var config = serializer.Deserialize(fileContent, typeof(SiteSettingsRecord));
                return config as SiteSettingsRecord;
            }

            return null;
        }

        public static bool IsSiteSetup()
        {
            return FileManager.SiteDirectory.Exists && FileManager.SiteDirectory.GetDirectories().Select(siteFolder => Path.Combine(siteFolder.FullName, SettingsFileName)).Any(File.Exists);
        }
    }
}