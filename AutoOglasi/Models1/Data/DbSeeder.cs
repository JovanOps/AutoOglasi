using AutoOglasi.Models;
using System.Linq;

namespace AutoOglasi.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (db.Automobili.Any()) return;

            db.Automobili.AddRange(
                new Automobil
                {
                    Marka = "Volkswagen",
                    Model = "Golf 7",
                    Godiste = 2016,
                    ZapreminaMotora = 1600,
                    Snaga = 110,
                    Gorivo = Gorivo.Dizel,
                    Karoserija = Karoserija.Hatchback,
                    Cena = 11500,
                    Kontakt = "065/123-456",
                    Opis = "Prvi vlasnik, servisna knjiga."
                },
                new Automobil
                {
                    Marka = "Toyota",
                    Model = "Corolla",
                    Godiste = 2019,
                    ZapreminaMotora = 1800,
                    Snaga = 122,
                    Gorivo = Gorivo.Hibrid,
                    Karoserija = Karoserija.Sedan,
                    Cena = 15500,
                    Kontakt = "email@primer.com",
                    Opis = "Hibrid, gradska potrošnja odlična."
                }
            );
            db.SaveChanges();
        }
    }
}
