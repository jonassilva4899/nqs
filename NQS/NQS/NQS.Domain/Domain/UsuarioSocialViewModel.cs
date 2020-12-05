using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain.Domain
{
    public class UsuarioSocialViewModel
    {
        public string IdToken { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Provider { get; set; }
    }
}
