using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Leega.Dtos
{
    public class PasswordReset
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "Email inválido")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")] 
        public string userName { get; set; }
        public string token { get; set; }
        
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        public string newPassword { get; set; }
        
        [DataType(DataType.Password)]
        [Compare("newPassword", ErrorMessage = "Senha e confirmação são diferentes")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        public string confirm { get; set; }
    }
}
