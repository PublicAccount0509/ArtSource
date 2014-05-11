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
        public string LoginName { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime? Birthday { get; set; }

        public int? DefaultAddressId { get; set; }

        public Address DefaultAddress { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
