using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infra.Data.Ef.Mappings
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        internal StudentMap()
        {
            HasKey(o => o.Id);
        }
    }
}
