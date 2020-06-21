using KolokwiumProbne.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumProbne.Services
{
    public interface ICukierniaDbService
    {       
        public List<ZamowienieResponse> PobierzZamowienia(string nazwisko);
        public ZamowienieResponse DodajZamowienie(int idKlienta, DodanieZamowieniaRequest request);
    }
}
