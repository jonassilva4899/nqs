using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Leega.Dtos
{
    public class ChangePassword
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "Email inválido")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        public string userName { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        public string currentPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        public string newPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("newPassword", ErrorMessage = "Senha e confirmação são diferentes")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        public string confirm { get; set; }
    }
}
