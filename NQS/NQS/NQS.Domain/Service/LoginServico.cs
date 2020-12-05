using AutoMapper;
using Leega.Domain.Utils;
using Leega.Entity;
using Leega.Entity.Entity;
using Leega.Entity.Enums;
using Leega.Entity.UnitofWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Leega.Entity.Repositories.Interfaces;
using Leega.Domain.Domain;
using Google.Apis.Auth;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace Leega.Domain.Service
{
    public class LoginServico<Tv, Te> : GenericServiceAsync<Tv, Te>
                                                where Tv : UsuarioViewModel
                                                where Te : Usuario
    {
        //private readonly EnvioDeEmailService _envioEmailService;
        private readonly PessoaService<PessoaViewModel, Pessoa> _pessoaService;
        private readonly TokenService _tokenService;
        //private readonly IRepository<Convite> _conviteRepository;
        IUsuarioRepository _usuarioRepository;
        IOrganizacaoPessoaRepository _organizacaoPessoaRepository;
        IPessoaRepository _pessoaRepository;
        IRepository<RecuperarSenha> _recuperarSenhaRepository;
        //IConviteHistoricoRepository _conviteHistoricoRepository;

        //DI must be implemented specific service as well beside GenericAsyncService constructor
        public LoginServico(PessoaService<PessoaViewModel, Pessoa> pessoaService,
                            IUnitOfWork unitOfWork, IMapper mapper,
                            TokenService tokenService,
                            //EnvioDeEmailService envioEmailService,
                            IUsuarioRepository usuarioRepository, IOrganizacaoPessoaRepository organizacaoPessoaRepository,  IPessoaRepository pessoaRepository, IRepository<RecuperarSenha> recuperarSenhaRepository )
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;

            if (_usuarioRepository == null)
                _usuarioRepository = usuarioRepository;

            _tokenService = tokenService;
            //_envioEmailService = envioEmailService;
            _pessoaService = pessoaService;
            _organizacaoPessoaRepository = organizacaoPessoaRepository;
            //_conviteRepository = conviteRepository;
            _pessoaRepository = pessoaRepository;
            _recuperarSenhaRepository = recuperarSenhaRepository;
            //_conviteHistoricoRepository = conviteHistoricoRepository;
        }

        //add here any custom service method or override genericasync service method
        //...
        public async Task<Usuario> VerificaLoginSenha(Login login)
        {
            try
            {
                var usuario = _usuarioRepository.PegarUsuarioLogin(x => x.Login == login.Usuario);

                if (usuario != null)
                {
                    string hashGerado = CriptoHashSha256.GetSha256Hash(login.Senha);
                    if (hashGerado == usuario.Senha)
                    {
                        return usuario;
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Usuario> VerificaLoginGoogle(UsuarioSocialViewModel login)
        {
            return await Task.Run(() =>
            {
                var usuario = _usuarioRepository.PegarUsuarioLogin(x => x.Login == login.Email && x.ContaGoogle);

                if (usuario != null)
                {
                    return usuario;
                }

                return null;
            });
        }

        //public async Task<bool> AssociarContaGoogle(AssociaContaGoogleViewModel modelo)
        //{
        //    var conviteHistorico = await _conviteHistoricoRepository.PegarConvitesHistoricoComConvite(x => x.Id == modelo.IdConviteHistorico);
        //    var usuario = _usuarioRepository.PegarUsuarioLogin(x => x.Login == conviteHistorico.Convite.Email);

        //    try
        //    {
        //        if (conviteHistorico != null)
        //        {
        //            conviteHistorico.Convite.PessoaCriada = usuario.Organizacoes.FirstOrDefault(x => x.IdOrganizacao == conviteHistorico.IdOrganizacao)?.Pessoa;
        //            conviteHistorico.Convite.Status = ConviteStatusEnum.Inativo;
        //        }

        //        if (usuario == null)
        //        {
        //            return false;
        //        }

        //        ValidationSettings validation = new ValidationSettings()
        //        {
        //            ForceGoogleCertRefresh = true,
        //            Audience = null,
        //            IssuedAtClockTolerance = TimeSpan.FromMinutes(5),
        //            ExpirationTimeClockTolerance = TimeSpan.FromMinutes(5)
        //        };

        //        var resposta = await GoogleJsonWebSignature.ValidateAsync(modelo.UsuarioSocial.IdToken, validation);

        //        if (resposta == null || resposta.Email != usuario.Login)
        //        {
        //            return false;
        //        }

        //        var pessoa = await _pessoaRepository.GetPorIdComUsuario(conviteHistorico.Convite.PessoaCriada.Id, conviteHistorico.IdOrganizacao);
        //        pessoa.Nome = resposta.Name;
        //        pessoa.Foto = resposta.Picture;

        //        _pessoaRepository.Update(pessoa);
        //        _pessoaRepository.Save();

        //        await AdicionaNaOrganizacaoDoConvite(conviteHistorico.IdOrganizacao, usuario, conviteHistorico.ResponsavelCriacao, conviteHistorico.Convite.IdPessoaCriada);

        //        _conviteHistoricoRepository.Update(conviteHistorico);
        //        _conviteHistoricoRepository.Save();
        //        return true;
        //    }
        //    catch (Exception error)
        //    {
        //        return false;
        //    }
        //}

        public async Task<InserirSenhaResultadoViewModel> InserirSenha(InserirSenhaViewModel modelo)
        {
            //var conviteHistorico = await _unitOfWork.GetRepositoryAsync<ConviteHistorico>().GetOne(x => x.Id == modelo.IdConviteHistorico);

            //var usuario = _usuarioRepository.PegarUsuarioLogin(x => x.Login == conviteHistorico.Convite.Email);

            var recuperarSenha = new RecuperarSenha();

            //recuperarSenha.DataSolicitacao = DateTime.Now;
            //recuperarSenha.DataExpiracao = await _tokenService.CalculaExpiracao();
            //recuperarSenha.Ativo = true;
            //recuperarSenha.Token = await _tokenService.GerarToken();
            //recuperarSenha.Pessoa = usuario.Organizacoes.FirstOrDefault(x => x.IdOrganizacao == conviteHistorico.IdOrganizacao)?.Pessoa;

            await _unitOfWork.GetRepositoryAsync<RecuperarSenha>().Insert(recuperarSenha);

            await _unitOfWork.SaveAsync();

            // Inativa a requisição corrente, no entanto, marca o usuário gerado a partir dessa requisição
            //if (conviteHistorico != null)
            //{
            //    conviteHistorico.Convite.PessoaCriada = usuario.Organizacoes.FirstOrDefault(x => x.IdOrganizacao == conviteHistorico.IdOrganizacao)?.Pessoa;
            //    conviteHistorico.Convite.Status = ConviteStatusEnum.Inativo;
            //}

            var Senha = await _unitOfWork.GetRepositoryAsync<RecuperarSenha>().GetOne(x => x.Pessoa.Email == recuperarSenha.Pessoa.Email &&
                                                                                      x.Token == recuperarSenha.Token);

            modelo.IdRecuperarSenha = Senha.Id;

            //await AdicionaNaOrganizacaoDoConvite(conviteHistorico.IdOrganizacao, usuario, conviteHistorico.ResponsavelCriacao, conviteHistorico.Convite.IdPessoaCriada);

            return await TrocarSenha(modelo.IdRecuperarSenha, modelo.NovaSenha);
        }

        private async Task AdicionaNaOrganizacaoDoConvite(Guid idOrganizacao, Usuario usuario, Guid responsavelCriacao, Guid idPessoaCriada)
        {
            try
            {
                var usuarioOrganizacaoExistente = await _organizacaoPessoaRepository.BuscarPorOrganizacao(idOrganizacao, usuario.Login);

                if (usuarioOrganizacaoExistente == null)
                {
                    var usuarioOrganizacao = new OrganizacaoUsuario();
                    usuarioOrganizacao.IdOrganizacao = idOrganizacao;
                    usuarioOrganizacao.IdUsuario = usuario.Id;
                    usuarioOrganizacao.IdPessoa = idPessoaCriada;
                    usuarioOrganizacao.UsuarioPlataforma = true;
                    usuarioOrganizacao.Ativo = true;
                    usuarioOrganizacao.DataCriacao = DateTime.Now;
                    usuarioOrganizacao.ResponsavelCriacao = responsavelCriacao;
                    _organizacaoPessoaRepository.Add(usuarioOrganizacao);
                    _organizacaoPessoaRepository.Save();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>> RecuperarSenha(RecebeEmailViewModel email)
        {
            var pessoa = _pessoaRepository.GetSingleOrDefault(x => x.Email == email.Email && x.Status);
            var usuarioPessoa = _usuarioRepository.GetSingleOrDefault(x => x.Login == email.Email && x.Ativo);

            RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>();

            if (pessoa == null)
            {
                ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                {
                    Cabecalho = "E-mail inválido",
                    MensagemCurta = "E-mail inválido",
                    Detalhes = "Este e-mail já está sendo utilizado.",
                    StatusCode = StatusCodes.Status400BadRequest
                };

                retornoController.ExibicaoMensagem = exibicaoMensagem;
                return retornoController;
            }

            if (usuarioPessoa != null && usuarioPessoa.Senha == null)
            {
                //var ultimoConvite = _conviteRepository.Find(x => x.Email == pessoa.Email).OrderByDescending(x => x.DataCriacao).FirstOrDefault();
                //var convite = await _pessoaService.CriarConvite(pessoa, pessoa.Id, ultimoConvite.IdOrganizacao);
                //var linkConvite = await _envioEmailService.GerarLink(convite.ConvitesHistorico.FirstOrDefault().Id,
                //                                        convite.ConvitesHistorico.FirstOrDefault().Token, "registro-pessoa");

                //var envioConvite = await _envioEmailService.EnvioConvite(convite, linkConvite);
                ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                {
                    Cabecalho = "E-mail não ativado",
                    MensagemCurta = "Processo de Ativação de Cadastro em andamento",
                    Detalhes = "Este e-mail não foi ativado por um convite",
                    StatusCode = StatusCodes.Status200OK
                };

                retornoController.ExibicaoMensagem = exibicaoMensagem;
                return retornoController;
            }

            //criar resetarPassword
            var recuperarSenha = await CriarRegRecuperarSenha(pessoa);

            if (recuperarSenha == null)
            {
                ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                {
                    Cabecalho = "Erro ao criar registro Recuperar Senha",
                    MensagemCurta = "Erro ao criar registro Recuperar Senha",
                    Detalhes = "Não foi possível criar registro para Recuperar Senha.",
                    StatusCode = StatusCodes.Status204NoContent
                };

                retornoController.ExibicaoMensagem = exibicaoMensagem;
                return retornoController;
            }

            //pegar link do convite
            //var linkRecuperarSenha = await _envioEmailService.GerarLink(recuperarSenha.Id,
            //                                            recuperarSenha.Token, "recupera-senha");

            ////emailService
            //var envioRecuperarSenha = await _envioEmailService.EnvioRecuperarSenha(recuperarSenha, linkRecuperarSenha);

            //if (envioRecuperarSenha.Resposta == false)
            //{
                //ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                //{
                //    Cabecalho = "Erro ao enviar convite",
                //    MensagemCurta = "Erro ao enviar convite",
                //    Detalhes = envioRecuperarSenha.Mensagem,
                //    StatusCode = StatusCodes.Status500InternalServerError
                //};

                retornoController.ExibicaoMensagem = new ExibicaoMensagemViewModel();//exibicaoMensagem;

            //    recuperarSenha.NotificacaoFoiEnviada = envioRecuperarSenha.Resposta;
            //    recuperarSenha.MensagemResultadoNotificacao = envioRecuperarSenha.Mensagem;

            //return retornoController;
            //}

            //recuperarSenha.NotificacaoFoiEnviada = envioRecuperarSenha.Resposta;
            //recuperarSenha.MensagemResultadoNotificacao = envioRecuperarSenha.Mensagem;

            await _unitOfWork.SaveAsync();

            retornoController.Objeto = recuperarSenha.Id;

            return retornoController;
        }

        public async Task<RecuperarSenha> CriarRegRecuperarSenha(Pessoa pessoa)
        {
            RecuperarSenha recuperarSenha = new RecuperarSenha
            {
                DataSolicitacao = DateTime.Now,
                DataExpiracao = await _tokenService.CalculaExpiracao(),
                Ativo = true,
                Token = await _tokenService.GerarToken(),
                NotificacaoFoiEnviada = false,
                Pessoa = pessoa
            };

            try
            {
                await _unitOfWork.GetRepositoryAsync<RecuperarSenha>().Insert(recuperarSenha);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                //throw new Exception();
                return null;
            }

            return recuperarSenha;
        }

        public async Task<InserirSenhaResultadoViewModel> TrocarSenha(Guid idRecuperarSenha, string novaSenha)
        {
            var senha = _recuperarSenhaRepository.GetSingleOrDefault(x => x.Id == idRecuperarSenha);

            InserirSenhaResultadoViewModel inserirSenhaResultado = new InserirSenhaResultadoViewModel();

            if (senha == null)
            {
                ExibicaoMensagemViewModel exibicaoMensagemErro = new ExibicaoMensagemViewModel()
                {
                    Cabecalho = "Recuperação de senha não está válida.",
                    MensagemCurta = "Recuperação de senha não está válida.",
                    Detalhes = "A solicitação de senha não foi encontrada.",
                    StatusCode = StatusCodes.Status204NoContent
                };

                inserirSenhaResultado.Resultado = false;
                inserirSenhaResultado.ExibicaoMensagem = exibicaoMensagemErro;

                return inserirSenhaResultado;
            }

            if (!senha.Ativo)
            {
                ExibicaoMensagemViewModel exibicaoMensagemErro = new ExibicaoMensagemViewModel()
                {
                    Cabecalho = "Recuperação de senha não está válida.",
                    MensagemCurta = "Recuperação de senha não está válida.",
                    Detalhes = "A solicitação de senha não está ativa.",
                    StatusCode = StatusCodes.Status400BadRequest
                };

                inserirSenhaResultado.Resultado = false;
                inserirSenhaResultado.ExibicaoMensagem = exibicaoMensagemErro;

                return inserirSenhaResultado;
            }

            if (senha.DataExpiracao < DateTime.Now)
            {
                ExibicaoMensagemViewModel exibicaoMensagemErro = new ExibicaoMensagemViewModel()
                {
                    Cabecalho = "Recuperação de senha expirada.",
                    MensagemCurta = "Recuperação de senha expirada.",
                    Detalhes = "A solicitação de senha está expirada.",
                    StatusCode = StatusCodes.Status404NotFound
                };

                inserirSenhaResultado.Resultado = false;
                inserirSenhaResultado.ExibicaoMensagem = exibicaoMensagemErro;

                return inserirSenhaResultado;
            }

            var usuario = _usuarioRepository.GetSingleOrDefault(x => x.Login == senha.Pessoa.Email);

            usuario.Senha = CriptoHashSha256.GetSha256Hash(novaSenha);

            senha.Ativo = false;

            _usuarioRepository.Update(usuario);
            _recuperarSenhaRepository.Update(senha);
            _usuarioRepository.Save();
            _recuperarSenhaRepository.Save();

            ExibicaoMensagemViewModel exibicaoMensagemSucesso = new ExibicaoMensagemViewModel()
            {
                Cabecalho = "Alteração de senha concluida",
                MensagemCurta = "Alteração de senha concluída",
                Detalhes = "Sua nova senha foi inserida com sucesso.",
                StatusCode = StatusCodes.Status200OK
            };

            inserirSenhaResultado.Resultado = true;
            inserirSenhaResultado.ExibicaoMensagem = exibicaoMensagemSucesso;

            return inserirSenhaResultado;
        }

        public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, InserirSenhaResultadoViewModel>> ValidarRestaurarSenha(SenhasHashsViewModel senhasHashs)
        {
            RetornoControllerViewModel<ExibicaoMensagemViewModel, InserirSenhaResultadoViewModel> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, InserirSenhaResultadoViewModel>();

            if (senhasHashs.Senha != senhasHashs.ConfirmarSenha)
            {
                ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                {
                    Cabecalho = "Solicitação inválida",
                    MensagemCurta = "Solicitação inválida",
                    Detalhes = "Senha e Confirmação de Senha não estão iguais.",
                    StatusCode = StatusCodes.Status400BadRequest
                };

                retornoController.ExibicaoMensagem = exibicaoMensagem;

                return retornoController;
            }

            if (string.IsNullOrEmpty(senhasHashs.IdRecuperarSenhaHash) || string.IsNullOrEmpty(senhasHashs.TokenHash))
            {
                ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                {
                    Cabecalho = "Solicitação inválida",
                    MensagemCurta = "Solicitação inválida",
                    Detalhes = "Acesse a página de login e solicte a criação de um novo usuário.",
                    StatusCode = StatusCodes.Status404NotFound
                };

                retornoController.ExibicaoMensagem = exibicaoMensagem;

                return retornoController;
            }

            try
            {
                var idRecuperarSenhaHashStr = Base64.Decode(senhasHashs.IdRecuperarSenhaHash, true);
                var tokenStr = Base64.Decode(senhasHashs.TokenHash, true);

                Guid idRecuperarSenha;

                if (!Guid.TryParse(idRecuperarSenhaHashStr, out idRecuperarSenha))
                {
                    ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                    {
                        Cabecalho = "Solicitação inválida",
                        MensagemCurta = "Solicitação inválida",
                        Detalhes = "Acesse a página de login e solicte a criação de um novo usuário.",
                        StatusCode = StatusCodes.Status400BadRequest
                    };

                    retornoController.ExibicaoMensagem = exibicaoMensagem;

                    return retornoController;
                }

                var recuperarSenha = await _unitOfWork.GetRepositoryAsync<RecuperarSenha>().GetOne(x => x.Id == idRecuperarSenha && x.Token == tokenStr);

                if (recuperarSenha == null)
                {
                    ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                    {
                        Cabecalho = "Solicitação inválida",
                        MensagemCurta = "Solicitação inválida",
                        Detalhes = "Acesse a página de login e solicte a criação de um novo usuário.",
                        StatusCode = StatusCodes.Status204NoContent
                    };
                    retornoController.ExibicaoMensagem = exibicaoMensagem;

                    return retornoController;
                }

                var usuario = _usuarioRepository.GetSingleOrDefault(x => x.Login == recuperarSenha.Pessoa.Email);
                if (usuario == null || string.IsNullOrEmpty(usuario.Senha))
                {
                    ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                    {
                        Cabecalho = "Solicitação inválida",
                        MensagemCurta = "Solicitação inválida",
                        Detalhes = "Não foi cadastrada uma senha inicial.",
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                    retornoController.ExibicaoMensagem = exibicaoMensagem;

                    return retornoController;
                }

                if (recuperarSenha.Ativo == false || recuperarSenha.DataExpiracao < DateTime.Now)
                {
                    ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                    {
                        Cabecalho = "Solicitação inválida",
                        MensagemCurta = "Solicitação inválida",
                        Detalhes = "Acesse a página de login e solicte a criação de um novo usuário.",
                        StatusCode = StatusCodes.Status404NotFound
                    };
                    retornoController.ExibicaoMensagem = exibicaoMensagem;

                    return retornoController;
                }

                retornoController.Objeto = await TrocarSenha(recuperarSenha.Id, senhasHashs.Senha);

                return retornoController;
            }
            catch (Exception e)
            {
                ExibicaoMensagemViewModel exibicaoMensagem = new ExibicaoMensagemViewModel
                {
                    Cabecalho = "Ocorreu um erro",
                    MensagemCurta = "Ocorreu um erro",
                    Detalhes = e.Message,
                    StatusCode = StatusCodes.Status400BadRequest
                };

                retornoController.ExibicaoMensagem = exibicaoMensagem;

                return retornoController;
            }
        }
    }
}
