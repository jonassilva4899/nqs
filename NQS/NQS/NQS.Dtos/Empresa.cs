using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Dtos
{
    public class Empresa
    {
        public Guid id { get; set; }
        public string cnpj { get; set; }
        public string razaosocial { get; set; }
        public string cnae { get; set; }
        public string ie { get; set; }
        public string endereco { get; set; }
        public int? numero { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string logo { get; set; }
        public string corprincipal { get; set; }
        public string corsecundaria { get; set; }
        public string corsuporte { get; set; }
    }
}
