using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class ResetPasswordModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}