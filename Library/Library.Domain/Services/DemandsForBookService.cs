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
    public class DemandsForBookService : ServiceBase<DemandsForBook>, IDemandsForBookService
    {
        private readonly IDemandsForBookRepository _demandsRepository;

        public DemandsForBookService(IDemandsForBookRepository demandRepository)
            : base(demandRepository)
        {
            _demandsRepository = demandRepository;
        }
    }
}
