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
    public class ListaPacientes
    {
        public List<Paciente> Paciente { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }

    }
}
