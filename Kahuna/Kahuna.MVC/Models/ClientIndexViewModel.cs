using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Kahuna.MVC.Models
{
    public class ClientIndexViewModel
    {
        [DisplayName("First Name")]
        public string Cfname { get; set; }
        [DisplayName("Last Name")]
        public string Clname { get; set; }
        public ICollection<Data.ServiceOrder> ServiceOrder { get; set; }
    }
}
