using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Common
{ 
    public class ActAttribute : Attribute
    {
        private string _feature;
        public ActAttribute(string feature)
        {
            _feature = feature;
        }

        public string Feature
        {
            get
            {
                return _feature;
            }
        }
    }
}