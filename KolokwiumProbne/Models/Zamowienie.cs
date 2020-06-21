using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumProbne.Models
{
    public class Zamowienie
    {
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }

        public DateTime DataRealizacji { get; set; }
        public String Uwagi { get; set; }
        public int IdKlient { get; set; }
        public virtual Klient Klient { get; set; }
        public int IdPracownik { get; set; }
        public virtual Pracownik Pracownik { get; set; }
        public virtual ICollection<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobyCukiernicze { get; set; }
    }
}
