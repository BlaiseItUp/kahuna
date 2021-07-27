using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kahuna.MVC.Data
{
    [Table("Service_Order")]
    public partial class ServiceOrder
    {
        public ServiceOrder()
        {
            Payment = new HashSet<Payment>();
            SalesOrderLine = new HashSet<SalesOrderLine>();
            ServiceHistory = new HashSet<ServiceHistory>();
        }

        [Key]
        [Column("SOID")]
        public int Soid { get; set; }
        [Column("ClientID")]
        public int? ClientId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DatePlaced { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCaseOpened { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCaseClosed { get; set; }
        [StringLength(50)]
        public string Override { get; set; }
        [StringLength(50)]
        public string Decline { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ServiceOrder")]
        public virtual Client Client { get; set; }
        [InverseProperty("So")]
        public virtual ICollection<Payment> Payment { get; set; }
        [InverseProperty("SoNavigation")]
        public virtual ICollection<SalesOrderLine> SalesOrderLine { get; set; }
        [InverseProperty("So")]
        public virtual ICollection<ServiceHistory> ServiceHistory { get; set; }
    }
}
