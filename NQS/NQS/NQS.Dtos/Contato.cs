using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Dtos
{
    public class Contato
    {
        public int id { get; set; }
        public int pessoaid { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
    }
}
