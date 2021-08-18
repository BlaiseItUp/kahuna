using System;
using System.Collections.Generic;

namespace Kahuna.MVC.Data
{
    public partial class ServiceOrder
    {
        public ServiceOrder()
        {
            Payment = new HashSet<Payment>();
            SalesOrderHistory = new HashSet<SalesOrderHistory>();
            SalesOrderLine = new HashSet<SalesOrderLine>();
            ServiceHistory = new HashSet<ServiceHistory>();
        }

        public int Soid { get; set; }
        public int? ClientId { get; set; }
        public DateTime? DatePlaced { get; set; }
        public DateTime? DateCaseOpened { get; set; }
        public DateTime? DateCaseClosed { get; set; }
        public string Override { get; set; }
        public string Decline { get; set; }
        public string Description { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<SalesOrderHistory> SalesOrderHistory { get; set; }
        public virtual ICollection<SalesOrderLine> SalesOrderLine { get; set; }
        public virtual ICollection<ServiceHistory> ServiceHistory { get; set; }
    }
}
