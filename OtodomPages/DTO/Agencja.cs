using System;
using System.Collections.Generic;

namespace DTO
{
    public partial class Agencja
    {
        public int IdAgencji { get; set; }
        public string NazwaAgencji { get; set; } = null!;
        public decimal NrTelefonuAgencji { get; set; }
        public string Email { get; set; } = null!;
        public decimal Nip { get; set; }
    }
}
