using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PegarAnexosViewModel
    {
        public Guid IdAnexo { get; set; }
        public DateTime DataHoraAnexo { get; set; }
        public string NomeArquivo { get; set; }
        public string CaminhoArquivo { get; set; }
    }
}
