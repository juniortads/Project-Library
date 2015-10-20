using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Infra.Data.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infra.Data.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {

    }
}
