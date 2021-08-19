using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kahuna.MVC.Data
{
    public partial class Client
    {
        public Client()
        {
            ServiceOrder = new HashSet<ServiceOrder>();
        }

        public int ClientId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string Cfname { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string Clname { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string CriminalRecord { get; set; }
        public string Military { get; set; }

        public virtual ICollection<ServiceOrder> ServiceOrder { get; set; }
    }
}
