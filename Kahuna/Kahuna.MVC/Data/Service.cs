using System;
using System.Collections.Generic;

namespace Kahuna.MVC.data
{
    public partial class Service
    {
        public Service()
        {
            SalesOrderLine = new HashSet<SalesOrderLine>();
        }

        public int ServId { get; set; }
        public string ServName { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }

        public virtual ICollection<SalesOrderLine> SalesOrderLine { get; set; }
    }
}
