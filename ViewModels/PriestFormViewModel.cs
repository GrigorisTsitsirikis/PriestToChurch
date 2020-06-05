using MyFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstMVC.ViewModels
{
    public class PriestFormViewModel
    {
        public Priest Priest{ get; set; }

        public List<Church> Churches { get; set; }

    }
}