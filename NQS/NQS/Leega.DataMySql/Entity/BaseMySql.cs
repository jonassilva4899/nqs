using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public abstract class BaseMySql
    {
        public BaseMySql()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
    }
}
