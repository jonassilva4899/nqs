using Leega.Application.Interfaces;
using Leega.Application.ViewModels;
using Leega.DataMySql.Entity;
using Leega.DataMySql.Repositories.Interfaces;
using Leega.Util;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Application.Services
{
    public class PacienteMySqlService : BaseMySqlService, IPacienteMySqlService
    {
        private readonly IPacienteMySqlRepository _PacienteMySqlRepository;
        private IConfiguration _config;

        public PacienteMySqlService(IConfiguration config,
          IPacienteMySqlRepository pacienteMySqlRepository)
        {
            _config = config;
            _PacienteMySqlRepository = pacienteMySqlRepository;            
        }


        public void Adicionar(PacienteMySql obj)
        {
            //obj.Senha = string.IsNullOrWhiteSpace(obj.Senha) ? Guid.NewGuid().ToString().Substring(0, 5) : obj.Senha;

            _PacienteMySqlRepository.Adicionar(obj);
        }
     
    }
}
