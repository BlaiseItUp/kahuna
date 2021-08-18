using System;
using System.Collections.Generic;

namespace Kahuna.MVC.Data
{
    public partial class ServiceHistory
    {
        public int Shid { get; set; }
        public int Soid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ModifyingUser { get; set; }

        public virtual ServiceOrder So { get; set; }
    }
}
