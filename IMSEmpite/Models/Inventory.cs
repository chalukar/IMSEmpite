using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMSEmpite.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Item Name")]
        public string ItemName { get; set; }

        [Required]
        [Display(Name ="Quantity")]
        public double Qty { get; set; }
    }
}
