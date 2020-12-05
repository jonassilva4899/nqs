using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using Leega.Entity;
using Leega.Entity.UnitofWork;

namespace Leega.Domain.Service
{

    public class AccountService<Tv, Te> : ServicoGenerico<Tv, Te>
                                        where Tv : AccountViewModel
                                        where Te : Account
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }

        //add here any custom service method or override generic service method
        public bool DoNothing()
        {
            return true;
        }
    }

}
