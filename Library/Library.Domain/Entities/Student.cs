using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Student : Identifier
    {
        public string Name { get; set; }
        public DateTime Age { get; set; }
    }
}
