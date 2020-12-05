using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class RecebeEmailViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
