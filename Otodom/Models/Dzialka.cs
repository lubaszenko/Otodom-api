using System;
using System.Collections.Generic;

namespace Otodom.Models
{
    public partial class Dzialka
    {
        public int IdDzialki { get; set; }
        public decimal PowierzchniaDzialki { get; set; }
        public int RodzajGruntuIdRodzajGruntu { get; set; }
        public int NieruchomoscIdNieruchomosci { get; set; }

        public virtual Nieruchomosc NieruchomoscIdNieruchomosciNavigation { get; set; } = null!;
        public virtual RodzajGruntu RodzajGruntuIdRodzajGruntuNavigation { get; set; } = null!;
        public virtual Nieruchomosc? Nieruchomosc { get; set; }
    }
}
