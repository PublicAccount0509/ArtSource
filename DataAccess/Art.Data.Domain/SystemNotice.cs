using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class SystemNotice : BaseEntity
    {
        [MaxLength(500)]
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsSuccessful { get; set; }
        public int AdminUserId { get; set; }
        public DateTime FADateTime { get; set; }

        [ForeignKey("AdminUserId")]
        public virtual AdminUser AdminUser { get; set; }
    }
}
