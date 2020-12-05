using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Leega.Entity;
using Leega.Entity.Entity;

namespace Leega.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Create automap mapping profiles
        /// </summary>
        public MappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<NotificacaoUsuario, NotificacaoUsuarioViewModel>();
            CreateMap<NotificacaoUsuarioViewModel, NotificacaoUsuario>();
            CreateMap<ConfiguracaoViewModel, Configuracao>();
            CreateMap<Configuracao, ConfiguracaoViewModel>();
            CreateMap<PessoaViewModel, Pessoa>();
            CreateMap<Pessoa, PessoaViewModel>();
            CreateMap<RecuperarSenhaViewModel, RecuperarSenha>();
            CreateMap<RecuperarSenha, RecuperarSenhaViewModel>();
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<PessoaClienteViewModel, PessoaCliente>();
            CreateMap<PessoaCliente, PessoaClienteViewModel>();
            CreateMap<PersonalMappingTituloViewModel, PersonalMappingTitulo>();
            CreateMap<PersonalMappingTitulo, PersonalMappingTituloViewModel>();
            CreateMap<PersonalMappingItemViewModel, PersonalMappingItem>();
            CreateMap<PersonalMappingItem, PersonalMappingItemViewModel>();
            CreateMap<PessoaHabilidadeViewModel, PessoaHabilidade>();
            CreateMap<PessoaHabilidade, PessoaHabilidadeViewModel>();
            CreateMap<OrganizacaoEntityViewModel, Organizacao>();
            CreateMap<Organizacao, OrganizacaoEntityViewModel>();
            CreateMap<OrganizacaoPessoaViewModel, OrganizacaoUsuario>();
            CreateMap<OrganizacaoUsuario, OrganizacaoPessoaViewModel>();
            CreateMap<GrupoViewModel, Grupo>();
            CreateMap<Grupo, GrupoViewModel>();
            CreateMap<Guid, int>();
            CreateMap<int, Guid>();
        }

    }





}
