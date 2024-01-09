using System;
using System.Collections.Generic;

namespace Otodom.Models
{
    public partial class Nieruchomosc
    {
        public Nieruchomosc()
        {
            Garazs = new HashSet<Garaz>();
            Ogloszenies = new HashSet<Ogloszenie>();
        }

        public int IdNieruchomosci { get; set; }
        public string Wojewodztwo { get; set; } = null!;
        public string Miasto { get; set; } = null!;
        public decimal KodPocztowy { get; set; }
        public string Ulica { get; set; } = null!;
        public decimal NrDomu { get; set; }
        public decimal PowierzchniaDomu { get; set; }
        public decimal LiczbaPieter { get; set; }
        public decimal RokBudowy { get; set; }
        public int RodzajZabudowyIdRodzajZabudowy { get; set; }
        public int RodzajOknaIdRodzajOkna { get; set; }
        public int StanWykonaniaIdStanWykonania { get; set; }
        public int TypOgrzewaniaIdTypOgrzewania { get; set; }
        public int? DzialkaIdDzialki { get; set; }

        public virtual Dzialka? DzialkaIdDzialkiNavigation { get; set; }
        public virtual RodzajOkna RodzajOknaIdRodzajOknaNavigation { get; set; } = null!;
        public virtual RodzajZabudowy RodzajZabudowyIdRodzajZabudowyNavigation { get; set; } = null!;
        public virtual StanWykonanium StanWykonaniaIdStanWykonaniaNavigation { get; set; } = null!;
        public virtual TypOgrzewanium TypOgrzewaniaIdTypOgrzewaniaNavigation { get; set; } = null!;
        public virtual Dzialka? Dzialka { get; set; }
        public virtual ICollection<Garaz> Garazs { get; set; }
        public virtual ICollection<Ogloszenie> Ogloszenies { get; set; }
    }
}
