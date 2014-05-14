using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Art.Common
{
    public sealed class ConfigSettings
    {
        public static readonly ConfigSettings Instance = new ConfigSettings();

        private ConfigSettings() { }

        public string FileUploadPath
        {
            get
            {
                return ConfigurationManager.AppSettings["FileUploadPath"];
            }
        }
    }
}