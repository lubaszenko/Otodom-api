using System;
using System.Collections.Generic;

namespace Otodom.Models
{
    public partial class RodzajOkna
    {
        public int IdRodzajOkna { get; set; }
        public string RodzajOkna1 { get; set; } = null!;

        public virtual Nieruchomosc? Nieruchomosc { get; set; }
    }
}
