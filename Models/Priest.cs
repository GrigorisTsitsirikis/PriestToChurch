
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;




namespace MyFirstMVC.Models
{
    
    public class Priest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "To επώνυμο του ιερέα είναι υποχρεωτικό.")]
        [StringLength(30)]
        [Display(Name = "Επώνυμο")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="To όνομα του ιερέα είναι υποχρεωτικό.")]
        [StringLength(30)]
        [Display(Name="Όνομα")]
        public string Name { get; set; }

        [Phone(ErrorMessage = "Ο αριθμός τηλεφώνου πρέπει να έχει μόνο αριθμούς.")]
        [StringLength(30)]
        [Display(Name = "Αριθμός Τηλεφώνου")]
        public string PhoneNumber { get; set; }

       
        [Display(Name = "Ενορία")]
        public Church Church { get; set; }


        [Display(Name = "Εφημέριος")]
        public bool IsEfimerios { get; set; }

        [Display(Name = "Εφημέριος Εποχιακός")]
        public bool IsEpoxiakos { get; set; }

        [Display(Name = "Ιεροκήρυκας")]
        public bool IsIerokirikas { get; set; }

        /// <summary>
        /// temporary addition of availability.
        /// </summary>
        [Display(Name = "Διαθέσιμος")]
        public bool  Available{ get; set; }

    }
}