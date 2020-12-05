using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leega.Application.ViewModels
{
    public class LoginMySql
    {
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
