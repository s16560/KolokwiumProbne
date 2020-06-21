using KolokwiumProbne.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumProbne.Models
{
    public class CukierniaDbContext : DbContext
    {
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<WyrobCukierniczy> WyrobyCukiernicze { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobyCukiernicze { get; set; }


        public CukierniaDbContext() { }

        public CukierniaDbContext(DbContextOptions options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new KlientConfiguration());
            modelBuilder.ApplyConfiguration(new PracownikConfiguration());
            modelBuilder.ApplyConfiguration(new WyrobCukierniczyConfiguration());
            modelBuilder.ApplyConfiguration(new ZamowienieConfiguration());
            modelBuilder.ApplyConfiguration(new Zamowienie_WyrobCukierniczyConfiguration());
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            //klienci
            List<Klient> klienci = new List<Klient>();
            klienci.Add(new Klient { IdKlient = 1, Imie = "Jan", Nazwisko = "Kowalski"});
            klienci.Add(new Klient { IdKlient = 2, Imie = "Marian", Nazwisko = "Jankowski" });
            klienci.Add(new Klient { IdKlient = 3, Imie = "Stefan", Nazwisko = "Janiak" });
            klienci.Add(new Klient { IdKlient = 4, Imie = "Anna", Nazwisko = "Malewska" });
            klienci.Add(new Klient { IdKlient = 5, Imie = "Barbara", Nazwisko = "Szyszko" });

            modelBuilder.Entity<Klient>().HasData(klienci);

            //pracownicy
            List<Pracownik> pracownicy = new List<Pracownik>();
            pracownicy.Add(new Pracownik { IdPracownik = 1, Imie = "Kazimierz", Nazwisko = "Janiak" });
            pracownicy.Add(new Pracownik { IdPracownik = 2, Imie = "Jan", Nazwisko = "Kania" });
            pracownicy.Add(new Pracownik { IdPracownik = 3, Imie = "Juliusz", Nazwisko = "Michalak" });
            pracownicy.Add(new Pracownik { IdPracownik = 4, Imie = "Kazimiera", Nazwisko = "Witkowska" });

            modelBuilder.Entity<Pracownik>().HasData(pracownicy);

            //wyroby cukiernicze
            List<WyrobCukierniczy> wyrobyCukiernicze = new List<WyrobCukierniczy>();
            wyrobyCukiernicze.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 1, Nazwa = "Eklerka", CenaZaSzt = 5, Typ = "Ciastko"});
            wyrobyCukiernicze.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 2, Nazwa = "Donut", CenaZaSzt = 3, Typ = "Ciastko" });
            wyrobyCukiernicze.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 3, Nazwa = "Batonik kokosowy", CenaZaSzt = 4, Typ = "Baton" });
            wyrobyCukiernicze.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 4, Nazwa = "Lizak serce", CenaZaSzt = 7, Typ = "Lizak" });
           
            modelBuilder.Entity<WyrobCukierniczy>().HasData(wyrobyCukiernicze);

            //zamówienia
            List<Zamowienie> zamowienia = new List<Zamowienie>();
            zamowienia.Add(new Zamowienie { IdZamowienia = 1, DataPrzyjecia = new DateTime(2020, 7, 11), DataRealizacji = new DateTime(2020, 8, 11), Uwagi = "brak", IdKlient = 1, IdPracownik = 2 });
            zamowienia.Add(new Zamowienie { IdZamowienia = 2, DataPrzyjecia = new DateTime(2020, 7, 10), DataRealizacji = new DateTime(2020, 7, 10), Uwagi = "na dziś!", IdKlient = 3, IdPracownik = 2 });
            zamowienia.Add(new Zamowienie { IdZamowienia = 3, DataPrzyjecia = new DateTime(2020, 7, 9), DataRealizacji = new DateTime(2020, 7, 15), Uwagi = "nerwowy klient!", IdKlient = 2, IdPracownik = 1 });
            zamowienia.Add(new Zamowienie { IdZamowienia = 4, DataPrzyjecia = new DateTime(2020, 7, 6), DataRealizacji = new DateTime(2020, 8, 2), Uwagi = "brak", IdKlient = 1, IdPracownik = 4 });

            modelBuilder.Entity<Zamowienie>().HasData(zamowienia);

            //zamowienia_wyrobyCukiernicze
            List<Zamowienie_WyrobCukierniczy> zamowienia_wyrobyCukiernicze = new List<Zamowienie_WyrobCukierniczy>();
            zamowienia_wyrobyCukiernicze.Add(new Zamowienie_WyrobCukierniczy { IdWyrobuCukierniczego = 2, IdZamowienia = 3, Ilosc = 2, Uwagi = "uwaga1" });
            zamowienia_wyrobyCukiernicze.Add(new Zamowienie_WyrobCukierniczy { IdWyrobuCukierniczego = 4, IdZamowienia = 2, Ilosc = 2, Uwagi = "uwaga2" });
            zamowienia_wyrobyCukiernicze.Add(new Zamowienie_WyrobCukierniczy { IdWyrobuCukierniczego = 3, IdZamowienia = 1, Ilosc = 2, Uwagi = "uwaga3" });
            zamowienia_wyrobyCukiernicze.Add(new Zamowienie_WyrobCukierniczy { IdWyrobuCukierniczego = 3, IdZamowienia = 4, Ilosc = 2, Uwagi = "uwaga4" });
            zamowienia_wyrobyCukiernicze.Add(new Zamowienie_WyrobCukierniczy { IdWyrobuCukierniczego = 1, IdZamowienia = 4, Ilosc = 3, Uwagi = "uwaga5" });

            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>().HasData(zamowienia_wyrobyCukiernicze);
        }
    }
}
