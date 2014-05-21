using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Art.WebService
{
    public class ArtApiConfig
    {
        public static readonly ArtApiConfig Instance = new ArtApiConfig();

        private string _smsContent;
        public string SmsContent
        {
            get
            {
                if (string.IsNullOrEmpty(_smsContent))
                {
                    _smsContent = ConfigurationManager.AppSettings["SmsContent"];
                }
                return _smsContent;
            }
        }
    }
}