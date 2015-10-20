using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interface
{
    [ServiceContract]
    public interface IStudentAppService : IAppServiceBase<Student>
    {
        [OperationContract]
        bool Authenticate(string mail, string password);
        [OperationContract]
        Student SearchByMail(string mail);
    }
}
