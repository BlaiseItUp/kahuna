using System;
using System.Collections.Generic;

namespace Kahuna.MVC.Data
{
    public partial class SalesOrderLine
    {
        public int EmpId { get; set; }
        public int Soid { get; set; }
        public int ServId { get; set; }
        public int Hours { get; set; }

        public virtual Employee Emp { get; set; }
        public virtual Service Serv { get; set; }
        public virtual ServiceOrder So { get; set; }
    }
}
