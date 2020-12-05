using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Dtos
{
    public class Ong
    {
        public int id { get; set; }
        public string cnpj { get; set; }
        public bool ativo { get; set; }
        public string razaosocial { get; set; }
        public string nomefantasia { get; set; }
        public string objetivo { get; set; }
        public string celular { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string site { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string pais { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }
        public string observacao { get; set; }
        public string im { get; set; }
        public string ie { get; set; }
        public Nullable<DateTime> datacriacao { get; set; }
        public string banco { get; set; }
        public string agencia { get; set; }
        public string digitoagencia { get; set; }
        public string conta { get; set; }
        public string digitoconta { get; set; }
    }
}
