using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Leega.Util;


namespace Leega.Dtos
{
    public class Medico
    {
        public int Id { get; set; }
        public string Crm { get; set; }
        public string Nome { get; set; }
    }
}
