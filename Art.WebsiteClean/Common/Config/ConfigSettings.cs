using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Common.Config
{
    public sealed class ConfigSettings
    {
        public static readonly ConfigSettings Instance = new ConfigSettings();

        private ConfigSettings() { }

        public string UploadedFileFolder
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["UploadedFileFolder"];
            }
        } 
    }
}