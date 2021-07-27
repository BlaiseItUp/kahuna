using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kahuna.MVC.Data
{
    public partial class Employee
    {
        public Employee()
        {
            SalesOrderLine = new HashSet<SalesOrderLine>();
        }

        [Key]
        [Column("EmpID")]
        public int EmpId { get; set; }
        [Required]
        [Column("EFName")]
        [StringLength(50)]
        public string Efname { get; set; }
        [Required]
        [Column("ELName")]
        [StringLength(50)]
        public string Elname { get; set; }
        public int Salary { get; set; }
        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        [InverseProperty("Emp")]
        public virtual ICollection<SalesOrderLine> SalesOrderLine { get; set; }
    }
}
