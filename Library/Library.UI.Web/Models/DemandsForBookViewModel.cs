using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.UI.Web.Models
{
    public class DemandsForBookViewModel
    {
        public DemandsForBookViewModel()
        {
            this.DemandsForBooks = new List<DemandsForBook>();
        }

        public List<DemandsForBook> DemandsForBooks { get; set; }
        public DemandsForBook DemandsForBook { get; set; }
    }
}