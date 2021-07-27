using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kahuna.MVC.Data
{
    public partial class Payment
    {
        [Key]
        [Column("PaymentID")]
        public int PaymentId { get; set; }
        [Column("ClientID")]
        public int ClientId { get; set; }
        [Column("SOID")]
        public int Soid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(Soid))]
        [InverseProperty(nameof(ServiceOrder.Payment))]
        public virtual ServiceOrder So { get; set; }
    }
}
