using Leega.DataMySql.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Repositories.Interfaces
{
    public interface IEquipamentoMySqlRepository
    {
        void Adicionar(EquipamentoMySql obj);
    }
}
