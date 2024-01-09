using System;
using System.Collections.Generic;

namespace Otodom.Models
{
    public partial class RodzajZabudowy
    {
        public int IdRodzajZabudowy { get; set; }
        public string RodzajZabudowy1 { get; set; } = null!;

        public virtual Nieruchomosc? Nieruchomosc { get; set; }
    }
}
