using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumProbne.DTO
{
    public class ZamowienieResponse
    {
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }

        public DateTime DataRealizacji { get; set; }
        public string Uwagi { get; set; }
        public IList<Zamowienie_WyrobResponse> Zamowienie_Wyroby { get; set; }

    }
}
