using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Leega.Dtos
{
    public class ForgotPassword
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "Email inválido")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        public string username { get; set; }
    }
}
