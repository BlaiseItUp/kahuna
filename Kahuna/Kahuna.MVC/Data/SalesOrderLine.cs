using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kahuna.MVC.Data
{
    [Table("Sales_Order_Line")]
    public partial class SalesOrderLine
    {
        [Key]
        [Column("EmpID")]
        public int EmpId { get; set; }
        [Key]
        [Column("SOID")]
        public int Soid { get; set; }
        [Key]
        [Column("ServID")]
        public int ServId { get; set; }
        public int Hours { get; set; }

        [ForeignKey(nameof(EmpId))]
        [InverseProperty(nameof(Employee.SalesOrderLine))]
        public virtual Employee Emp { get; set; }
        [ForeignKey(nameof(ServId))]
        [InverseProperty(nameof(Service.SalesOrderLine))]
        public virtual Service Serv { get; set; }
        [ForeignKey(nameof(Soid))]
        [InverseProperty(nameof(SalesOrderHistory.SalesOrderLine))]
        public virtual SalesOrderHistory So { get; set; }
        [ForeignKey(nameof(Soid))]
        [InverseProperty(nameof(ServiceOrder.SalesOrderLine))]
        public virtual ServiceOrder SoNavigation { get; set; }
    }
}
