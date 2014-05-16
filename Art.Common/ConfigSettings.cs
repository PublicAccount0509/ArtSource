using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Art.Common
{
    public sealed class ConfigSettings
    {
        public const int MINWIDTH_UPLOADEDARTWORKIMAGE = 600;
        public const int MINHEIGHT_UPLOADEDARTWORKIMAGE = 420;


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