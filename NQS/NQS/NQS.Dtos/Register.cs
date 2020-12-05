using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Leega.Dtos
{
    public class Register
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "Email inválido")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        public string username { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Senha e confirmação são diferentes")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        public string confirm { get; set; }

        [Required(ErrorMessage = "Você não aceitou os termos de uso")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Você não aceitou os termos de uso")]
        public bool termo { get; set; }

    }
}
