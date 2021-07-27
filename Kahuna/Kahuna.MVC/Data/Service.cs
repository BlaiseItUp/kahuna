using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kahuna.MVC.Data
{
    public partial class Service
    {
        public Service()
        {
            SalesOrderLine = new HashSet<SalesOrderLine>();
        }

        [Key]
        [Column("ServID")]
        public int ServId { get; set; }
        [Required]
        [StringLength(50)]
        public string ServName { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int? Discount { get; set; }

        [InverseProperty("Serv")]
        public virtual ICollection<SalesOrderLine> SalesOrderLine { get; set; }
    }
}
