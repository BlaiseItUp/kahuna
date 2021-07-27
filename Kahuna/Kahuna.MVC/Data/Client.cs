using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kahuna.MVC.Data
{
    public partial class Client
    {
        public Client()
        {
            ServiceOrder = new HashSet<ServiceOrder>();
        }

        [Key]
        [Column("ClientID")]
        public int ClientId { get; set; }
        [Required]
        [Column("CFName")]
        [StringLength(50)]
        public string Cfname { get; set; }
        [Required]
        [Column("CLName")]
        [StringLength(50)]
        public string Clname { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }
        [Required]
        [Column("Address(...)")]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(5)]
        public string ZipCode { get; set; }
        [StringLength(50)]
        public string CriminalRecord { get; set; }
        [StringLength(50)]
        public string Military { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<ServiceOrder> ServiceOrder { get; set; }
    }
}
