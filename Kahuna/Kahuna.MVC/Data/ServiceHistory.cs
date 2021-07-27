using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kahuna.MVC.Data
{
    [Table("Service_History")]
    public partial class ServiceHistory
    {
        [Key]
        [Column("SHID")]
        public int Shid { get; set; }
        [Column("SOID")]
        public int Soid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        public int ModifyingUser { get; set; }

        [ForeignKey(nameof(Soid))]
        [InverseProperty(nameof(ServiceOrder.ServiceHistory))]
        public virtual ServiceOrder So { get; set; }
    }
}
