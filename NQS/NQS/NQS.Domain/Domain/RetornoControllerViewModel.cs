using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class RetornoControllerViewModel<ExibicaoMensagemViewModel, TObjeto>
    {
        public ExibicaoMensagemViewModel ExibicaoMensagem { get; set; }
        public TObjeto Objeto { get; set; }
    }
}
