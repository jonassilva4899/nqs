using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Leega.Domain.Utils;
using Leega.Entity;
using Leega.Entity.Entity;
using Leega.Entity.Repositories;
using Leega.Entity.UnitofWork;

namespace Leega.Domain.Service
{

    public class UsuarioServico<Tv, Te> : GenericServiceAsync<Tv, Te>
                                                where Tv : UsuarioViewModel
                                                where Te : Usuario
    {
        private readonly PessoaRepository _pessoaRepository;

        public UsuarioServico(IUnitOfWork unitOfWork, IMapper mapper, PessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }

        public async Task<List<PessoasAtivasViewModel>> ListarUsuariosAtivos(Guid idOrganizacao)
        {
            var pessoasAtivas = _pessoaRepository.PegarTodasPessoas(idOrganizacao);

            List<PessoasAtivasViewModel> pessoas = new List<PessoasAtivasViewModel>();
            foreach (var elem in pessoasAtivas)
            {
                var pessoa = new PessoasAtivasViewModel();
                pessoa.Id = elem.Id;
                pessoa.Nome = elem.Nome;
                pessoa.Email = elem.Email;
                pessoa.Status = elem.Status;

                pessoas.Add(pessoa);
            }
            return pessoas;
        }
    }
}
