using AutoMapper;
using Leega.Entity;
using Leega.Entity.Repositories.Interfaces;
using Leega.Entity.UnitofWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Domain.Service
{
    public class ClienteService<Tv, Te> : GenericServiceAsync<Tv, Te>
                                                where Tv : ClienteViewModel
                                                where Te : Cliente
    {
        IClienteRepository _clienteRepository;

        public ClienteService(IUnitOfWork unitOfWork, IMapper mapper,
                              IClienteRepository clienteRepository)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;

            if (_clienteRepository == null)
                _clienteRepository = clienteRepository;
        }

        public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>> Criar(Tv cliente)
        {
            cliente.DataCriacao = DateTime.Now;
            cliente.DataEdicao = DateTime.Now;

            Guid id = await Add(cliente);

            RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>();
            retornoController.Objeto = id;

            return retornoController;
        }

        public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, List<Guid>>> AdicionarCliente(ClienteAdicionarViewModel clienteAdicionar, Guid idOrganizacao)
        {
            RetornoControllerViewModel<ExibicaoMensagemViewModel, List<Guid>> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, List<Guid>>();

            var pessoa = await _unitOfWork.GetRepositoryAsync<Pessoa>().GetOne(x =>
                x.Id == clienteAdicionar.IdPessoa &&
                x.Organizacoes.Any(y => y.IdOrganizacao == idOrganizacao && y.IdPessoa == x.Id));


            if (pessoa == null)
            {
                ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                {
                    Cabecalho = "Pessoa inválida",
                    MensagemCurta = "Pessoa inválida",
                    Detalhes = "Pessoa não foi encontrada.",
                    StatusCode = StatusCodes.Status400BadRequest
                };

                retornoController.ExibicaoMensagem = exibicaoMensagem;
                return retornoController;
            }

            Cliente cliente = new Cliente()
            {
                Nome = clienteAdicionar.Nome,
                DataCriacao = DateTime.Now,
                DataEdicao = DateTime.Now,
                IdOrganizacao = idOrganizacao
            };

            var existeCliente = await _unitOfWork.GetRepositoryAsync<Cliente>().GetOne(x => x.Id == clienteAdicionar.IdCliente && x.IdOrganizacao == idOrganizacao);
            if (existeCliente == null)
            {
                await _unitOfWork.GetRepositoryAsync<Cliente>().Insert(cliente);

                PessoaCliente pessoaCliente = new PessoaCliente()
                {
                    Cliente = cliente,
                    Pessoa = pessoa,
                    DataInicio = clienteAdicionar.DataInicio,
                    DataFim = clienteAdicionar.DataFim,
                    Status = true,
                    DataCriacao = DateTime.Now,
                    DataEdicao = DateTime.Now,
                    IdOrganizacao = idOrganizacao
                };
                await _unitOfWork.GetRepositoryAsync<PessoaCliente>().Insert(pessoaCliente);
            }
            else
            {
                var existeRelacao = await _unitOfWork.GetRepositoryAsync<PessoaCliente>()
                    .GetOne(x => x.IdPessoa == clienteAdicionar.IdPessoa &&
                                 x.IdCliente == existeCliente.Id &&
                                 x.IdOrganizacao == idOrganizacao);
                if (existeRelacao == null)
                {
                    PessoaCliente pessoaCliente = new PessoaCliente()
                    {
                        Cliente = existeCliente,
                        Pessoa = pessoa,
                        DataInicio = clienteAdicionar.DataInicio,
                        DataFim = clienteAdicionar.DataFim,
                        Status = true,
                        DataCriacao = DateTime.Now,
                        DataEdicao = DateTime.Now,
                        IdOrganizacao = idOrganizacao
                    };
                    await _unitOfWork.GetRepositoryAsync<PessoaCliente>().Insert(pessoaCliente);
                    await _unitOfWork.SaveAsync();
                }
                else
                {
                    return null;
                }
            }
            await _unitOfWork.SaveAsync();
            retornoController.Objeto = new List<Guid>() { { pessoa.Id }, { cliente.Id } };
            return retornoController;
        }

        public async Task<IEnumerable<ClientesComboBoxViewModel>> PegarClientesComboBox(Guid idOrganizacao)
        {
            var clientesComboBox = _clienteRepository.PegarTodosClientes(idOrganizacao)
                .Select(x => new ClientesComboBoxViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome
                })
                .OrderBy(x => x.Nome)
                .ToList();

            return clientesComboBox;
        }

        public async Task<Guid> EditarCliente(PessoaClienteViewModel clienteEditar)
        {
            var cliente = await _unitOfWork.GetRepositoryAsync<PessoaCliente>()
                .GetOne(x => x.IdCliente == clienteEditar.IdCliente
                             && x.IdPessoa == clienteEditar.IdPessoa
                             && x.IdOrganizacao == clienteEditar.IdOrganizacao);

            cliente.DataInicio = clienteEditar.DataInicio;
            cliente.DataFim = clienteEditar.DataFim;
            cliente.DataEdicao = DateTime.Now;
            cliente.ResponsavelEdicao = clienteEditar.ResponsavelEdicao;
            cliente.IdOrganizacao = clienteEditar.IdOrganizacao;

            await _unitOfWork.GetRepositoryAsync<PessoaCliente>().Update(cliente.IdPessoa, cliente);
            await _unitOfWork.SaveAsync();

            return cliente.IdCliente;
        }
    }
}
