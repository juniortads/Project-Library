using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class DemandsForBook : Identifier
    {
        public Book Book { get; set; }

        public Student Student { get; set; }

        public DateTime DateRequest { get; set; }

        public TypeStateDemands TypeStateDemands { get; set; }

    }
}
