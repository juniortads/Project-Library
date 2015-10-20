using Library.Application.Interface;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public class StudentAppService : AppServiceBase<Student>, IStudentAppService
    {
        private readonly IStudentService _studentService;

        public StudentAppService(IStudentService studentService)
            : base(studentService)
        {
            _studentService = studentService;
        }

        public bool Authenticate(string mail, string password)
        {
            return _studentService.CheckPermission(mail, password);
        }

        public Student SearchByMail(string mail)
        {
            return _studentService.GetByMail(mail);
        }
    }
}
