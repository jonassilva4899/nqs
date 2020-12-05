using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain.Domain
{
    public class ListaGenericaViewModel
    {
        public ListaGenericaViewModel(string name, Type type)
        {
            this.FieldName = name;
            this.FieldType = type;
        }
        public string FieldName;

        public Type FieldType;
    }
}

