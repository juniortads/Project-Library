using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.Services
{
    public interface IStudentService : IServiceBase<Student>
    {
        bool CheckPermission(string mail, string password);

        Student GetByMail(string mail);
    }
}
