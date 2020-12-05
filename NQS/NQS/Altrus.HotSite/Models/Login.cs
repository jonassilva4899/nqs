using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leega.UI.Models
{
    public class Login
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email inválido")]
        public string Usuario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public string returnUrl { get; set; }
    }
}
