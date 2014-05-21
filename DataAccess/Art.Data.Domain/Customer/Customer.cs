using Art.Data.Common;
using Art.WebService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class Customer : BaseEntity
    {
        [Required]
        public string NickName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public Genders Gender { get; set; }

        public DeviceType DeviceType { get; set; }

        public string AvatarPath { get; set; }

        public int? DefaultAddressId { get; set; }

        public virtual Address DefaultAddress { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
