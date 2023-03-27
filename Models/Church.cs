using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstMVC.Models
{
    public class Church
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Όνομα Ενορίας")]
        public string Name { get; set; }
    }
}