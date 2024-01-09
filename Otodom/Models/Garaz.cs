using System;
using System.Collections.Generic;

namespace Otodom.Models
{
    public partial class Garaz
    {
        public int IdGarazu { get; set; }
        public decimal PowierzchniaGarazu { get; set; }
        public int NieruchomoscIdNieruchomosci { get; set; }
        public int WykonczenieGrazuIdWykonczenieGarazu { get; set; }

        public virtual Nieruchomosc NieruchomoscIdNieruchomosciNavigation { get; set; } = null!;
        public virtual WykonczenieGrazu WykonczenieGrazuIdWykonczenieGarazuNavigation { get; set; } = null!;
    }
}
