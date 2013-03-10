using System;
using System.IO;

namespace OpenSupport.Core.Services
{
    public static class FileManager
    {
        public static DirectoryInfo DataDirectory
        {
            get
            {
                var appDataPath = (string)AppDomain.CurrentDomain.GetData("DataDirectory") ??
                    AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                return new DirectoryInfo(appDataPath);
            }
        }

        public static DirectoryInfo SiteDirectory
        {
            get { return GetDirectory("Site"); }
        }

        public static DirectoryInfo GetDirectory(string relativePath)
        {
            string path = Path.Combine(DataDirectory.FullName, relativePath);
            return new DirectoryInfo(path);
        }

    }
}