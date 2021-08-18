using System;
using System.Collections.Generic;

namespace Kahuna.MVC.Data
{
    public partial class Employee
    {
        public Employee()
        {
            SalesOrderLine = new HashSet<SalesOrderLine>();
        }

        public int EmpId { get; set; }
        public string Efname { get; set; }
        public string Elname { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }

        public virtual ICollection<SalesOrderLine> SalesOrderLine { get; set; }
    }
}
