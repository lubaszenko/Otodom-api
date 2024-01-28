using System;
using System.Collections.Generic;

namespace DTO
{
    public partial class Zdjecie
    {
        public int IdZdjecia { get; set; }
        public string? ZdjecieData { get; set; }
        public int NieruchomoscIdNieruchomosci { get; set; }
    }
}
