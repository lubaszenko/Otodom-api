using System;
using System.Collections.Generic;

namespace Otodom.Models
{
    public partial class TypOgrzewanium
    {
        public int IdTypOgrzewania { get; set; }
        public string TypOgrzewania { get; set; } = null!;

        public virtual Nieruchomosc? Nieruchomosc { get; set; }
    }
}
