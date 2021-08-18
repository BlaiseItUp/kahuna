using System;
using System.Collections.Generic;

namespace Kahuna.MVC.Data
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int ClientId { get; set; }
        public int Soid { get; set; }
        public DateTime? Date { get; set; }

        public virtual ServiceOrder So { get; set; }
    }
}
