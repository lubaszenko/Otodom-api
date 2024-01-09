using System;
using System.Collections.Generic;

namespace Otodom.Models
{
    public partial class StanWykonanium
    {
        public int IdStanWykonania { get; set; }
        public string StanWykonania { get; set; } = null!;

        public virtual Nieruchomosc? Nieruchomosc { get; set; }
    }
}
