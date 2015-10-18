using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Book : Identifier
    {
        public string Name { get; set; }
    }
}
