using KolokwiumProbne.DTO;
using KolokwiumProbne.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumProbne.Services
{
    public class EfCukierniaDbService : ICukierniaDbService
    {
        private readonly CukierniaDbContext _context;

        public EfCukierniaDbService(CukierniaDbContext context)
        {
            _context = context;
        }

        public List<ZamowienieResponse> PobierzZamowienia(string nazwisko)
        {
            var wszystkieZamowienia = new List<ZamowienieResponse>();

            var klienci = 
            nazwisko == null ?
            _context.Klienci.ToArray() :           
            _context.Klienci.Where(k => k.Nazwisko.Equals(nazwisko)).ToArray();

            var zamowienie_wyroby = _context.Zamowienie_WyrobyCukiernicze.ToArray();
            var wyrobyCukiernicze = _context.WyrobyCukiernicze.ToArray();

            for (int i = 0; i < klienci.Length; i++)
            {

                var klient = klienci[i];
                var zamowienia = _context.Zamowienia.Where(z => z.IdKlient == klient.IdKlient).ToArray();

                for (int j = 0; j < zamowienia.Length; j++)
                {
                    var zamowienie = zamowienia[j];
                    var zamowienia_wyroby =
                       _context.Zamowienie_WyrobyCukiernicze
                       .Where(zw => zw.IdZamowienia == zamowienie.IdZamowienia).ToArray();

                    var zamowienieResponse = new ZamowienieResponse();
                    zamowienieResponse.IdZamowienia = zamowienie.IdZamowienia;
                    zamowienieResponse.DataPrzyjecia = zamowienie.DataPrzyjecia;
                    zamowienieResponse.DataRealizacji = zamowienie.DataRealizacji;
                    zamowienieResponse.Uwagi = zamowienie.Uwagi;

                    zamowienieResponse.Zamowienie_Wyroby = new List<Zamowienie_WyrobResponse>();

                    for (int k = 0; k < zamowienia_wyroby.Length; k++)
                    {
                        var zamowienie_wyrobResponse = new Zamowienie_WyrobResponse();
                        var nazwaWyrobu = _context.WyrobyCukiernicze.Find(zamowienia_wyroby[k].IdWyrobuCukierniczego).Nazwa;
                        zamowienie_wyrobResponse.NazwaWyrobu = nazwaWyrobu;
                        zamowienie_wyrobResponse.Ilosc = zamowienia_wyroby[k].Ilosc;

                        zamowienieResponse.Zamowienie_Wyroby.Add(zamowienie_wyrobResponse);
                    }
                    wszystkieZamowienia.Add(zamowienieResponse);

                }

            }

            return wszystkieZamowienia;
        }

        public ZamowienieResponse DodajZamowienie(int idKlienta, DodanieZamowieniaRequest request)
        {

            Zamowienie zamowienie = new Zamowienie();

            zamowienie.IdKlient = idKlienta;
            zamowienie.IdPracownik = 1;
            zamowienie.DataPrzyjecia = request.DataPrzyjecia;
            zamowienie.Uwagi = request.Uwagi;

            _context.Zamowienia.Add(zamowienie);

            for (int i=0; i<request.Wyroby.ToArray().Length; i++) {
                _context.Zamowienie_WyrobyCukiernicze
                    .Add(new Zamowienie_WyrobCukierniczy { 
                    });
            }

            return null;

        }
    }
}
