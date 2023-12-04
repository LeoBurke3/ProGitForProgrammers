using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System.Profile;

namespace ProGitForProgrammersProject2
{
    internal class Software_Asset
    {
        public string name { get; set; }
        public string version { get; set; }
        public string manufacturer { get; set; }

        public void autoSoftAsset()
        {
            Software_Asset software = new Software_Asset();
            software.version = System.Environment.OSVersion.Version.ToString();
            software.name = AnalyticsInfo.VersionInfo.ProductName.ToString();
            

        }
    }
}
