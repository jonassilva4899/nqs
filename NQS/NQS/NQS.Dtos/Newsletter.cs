using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Dtos
{
    public class Newsletter
    {
        public Newsletter()
        {
            result = new Result();
        }

        [Required]
        [StringLength(160)]
        public string nome { get; set; }
        [Required]
        [StringLength(256)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public Result result { get; set; }
    }
}
