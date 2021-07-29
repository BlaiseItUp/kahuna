using System;
using System.Collections.Generic;

namespace Kahuna.MVC.data
{
    public partial class SalesOrderHistory
    {
        public int HistId { get; set; }
        public int Soid { get; set; }
        public int EmpId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ServiceOrder So { get; set; }
    }
}
