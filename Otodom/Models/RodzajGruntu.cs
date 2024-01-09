using System;
using System.Collections.Generic;

namespace Otodom.Models
{
    public partial class RodzajGruntu
    {
        public int IdRodzajGruntu { get; set; }
        public string RodzajGruntu1 { get; set; } = null!;

        public virtual Dzialka? Dzialka { get; set; }
    }
}
