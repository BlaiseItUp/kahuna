using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kahuna.MVC.Data
{
    [Table("Sales_Order_History")]
    public partial class SalesOrderHistory
    {
        public SalesOrderHistory()
        {
            SalesOrderLine = new HashSet<SalesOrderLine>();
        }

        [Key]
        [Column("HistID")]
        public int HistId { get; set; }
        [Column("SOID")]
        public int Soid { get; set; }
        [Column("EmpID")]
        public int EmpId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }

        [InverseProperty("So")]
        public virtual ICollection<SalesOrderLine> SalesOrderLine { get; set; }
    }
}
