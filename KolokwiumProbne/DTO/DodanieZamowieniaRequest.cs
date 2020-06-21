using KolokwiumProbne.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumProbne.DTO
{
    public class DodanieZamowieniaRequest
    {
        [Required]
        public int IdKlienta { get; set; }
        [Required]
        public DateTime DataPrzyjecia { get; set; }

        public String Uwagi { get; set; }
        public List<WyrobCukierniczyRequest> Wyroby {get; set;}

    }
}
