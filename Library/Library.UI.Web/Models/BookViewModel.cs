using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.UI.Web.Models
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            this.Books = new List<Domain.Entities.Book>();
        }
        public List<Library.Domain.Entities.Book> Books { get; set; }
    }
}