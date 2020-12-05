using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class InfoReviewViewModel
    {
        public int QuantidadeReviews { get; set; }
        public DateTime? ProximaReview { get; set; }
        public DateTime? UltimaReview { get; set; }
        public bool ReviewConfigurada { get; set; }
    }
}
