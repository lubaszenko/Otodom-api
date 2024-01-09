using System;
using System.Collections.Generic;

namespace Otodom.Models
{
    public partial class WykonczenieGrazu
    {
        public int IdWykonczenieGarazu { get; set; }
        public string WykonczenieGarazu { get; set; } = null!;

        public virtual Garaz? Garaz { get; set; }
    }
}
