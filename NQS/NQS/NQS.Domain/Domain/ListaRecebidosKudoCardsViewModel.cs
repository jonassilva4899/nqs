using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class ListaRecebidosKudoCardsViewModel
    {
        public string MensagemBoxKudoCard { get; set; }
        public string NomeOrganizacao { get; set; }
        public string MensagemKudoCard { get; set; }
        public string Remetente { get; set; }
        public TipoKudoCardEnum TipoKudoCard { get; set; }

    }

    public class ListaTodosKudoCardsPessoaViewModel
    {
        public List<ListaEnviadosKudoCardsViewModel> Enviados { get; set; } = new List<ListaEnviadosKudoCardsViewModel>();
        public List<ListaRecebidosKudoCardsViewModel> Recebidos { get; set; } = new List<ListaRecebidosKudoCardsViewModel>();
    }


    public class ListaEnviadosKudoCardsViewModel
    {
        public string MensagemBoxKudoCard { get; set; }
        public string MensagemKudoCard { get; set; }
        public string NomeOrganizacao { get; set; }
        public string Destinatario { get; set; }
        public TipoKudoCardEnum TipoKudoCard { get; set; }
    }
}
