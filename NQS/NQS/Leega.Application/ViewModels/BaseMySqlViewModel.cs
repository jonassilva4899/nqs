using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Application.ViewModels
{
    public abstract class BaseMySqlViewModel
    {
        public BaseMySqlViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
    }
}
