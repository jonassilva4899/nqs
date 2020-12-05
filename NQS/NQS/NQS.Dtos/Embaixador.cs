using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Dtos
{
    public class Embaixador
    {
        public bool embaixador { get; set; }
        [MaxLength(500)]
        public string experiencia { get; set; }
        [MaxLength(500)]
        public string motivacao { get; set; }
    }
}
