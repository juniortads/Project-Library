using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class StudentService : ServiceBase<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
            : base(studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public bool CheckPermission(string mail, string password)
        {
            if(_studentRepository.GetAll().Where(o => o.Email.Equals(mail) &&
                                                   o.PassWord.Equals(password)).Count() > 0)
            {
                return true;
            }
            return false;
        }
        public Student GetByMail(string mail)
        {
            return _studentRepository.GetAll().Where(o => o.Email.Equals(mail)).FirstOrDefault();
        }
    }
}
