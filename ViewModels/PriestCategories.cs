using MyFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstMVC.ViewModels
{
    public class PriestCategories
    {

        [Display(Name = "Ιεροκήρυκες")]
        public List<Priest> Ierokyrikes { get; set; }

        [Display(Name ="Εφημέριοι")]
        public List<Priest> Efimerioi { get; set; }

        [Display(Name = "Εποχιακοί")]
        public List<Priest> Epoxiakoi { get; set; }

        [Display(Name = "Εκκλησίες")]
        public List<Church> AssignedChurches { get; set; }

        [Display(Name = "Διαθέσιμοι Ιερείς")]
        public List<Priest> AllAvailablePriests { get; set; }

        [Display(Name = "Ημερομηνία ανάθεσης")]
        public DateTime? DatePicker { get; set; }
    }
}