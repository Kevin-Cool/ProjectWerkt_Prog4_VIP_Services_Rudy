using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VIP_Services_Rudy_2020.BusinessLayer;
using VIP_Services_Rudy_2020.BusinessLayer.Models;
using VIP_Services_Rudy_2020.DataLayer.Repositories;

namespace VIP_Services_Rudy_2020.DataLayer
{
    class DataInitializer
    {
        private Context _ctx;
        private KlantRepository _klantRepo;
        private LimousineRepository _limoRepo;
        private LocatieRepository _locaRepo;
        private StaffelkortingRepository _staffelRepo;
        public DataInitializer(Context ctx)
        {
            _ctx = ctx;

            _klantRepo = new KlantRepository(ctx);
            _limoRepo = new LimousineRepository(ctx);
            _locaRepo = new LocatieRepository(ctx);
            _staffelRepo = new StaffelkortingRepository(ctx);

        }


        public void AddDataToDatabase()
        {
            if (_ctx.Database.EnsureDeleted())
            {
                _ctx.Database.EnsureCreated();
                #region Klanten
                _klantRepo.Add(new Klant("Van Hie Gilbert",KlantTypes.particulier, "Vismarkt 1 - Leuven"));
                _klantRepo.Add(new Klant("De Pesser Jean, particulier", KlantTypes.other, "Stationstraat 7 - Vilvoorde"));
                _klantRepo.Add(new Klant("Persé Philemon", KlantTypes.vip, "Markt 12 - Mechelen"));
                _klantRepo.Add(new Klant("Dock Jomme", KlantTypes.particulier, "Markt 16 - Mechelen"));
                _klantRepo.Add(new Klant("Gaia", KlantTypes.organisatie, " slachthuisstraat 1 - Sint Niklaas", "BE0123456789"));
                _klantRepo.Add(new Klant("Thienpondt Paul", KlantTypes.vip, " Stationstraat 165b - Antwerpen"));
                _klantRepo.Add(new Klant("De Radiomannen", KlantTypes.concertpromotor, "Reyerslaan 111 - Brussel", "BE0987654321"));
                _klantRepo.Add(new Klant("Vegas", KlantTypes.huwelijksplanner, "Feeststraat 68 - Boom", "BE0069001234"));
                _klantRepo.Add(new Klant("De feestmadammen", KlantTypes.evenementenbureau, " Dorpstraat 78 - Deinze", "BE0101020203"));
                _klantRepo.Add(new Klant("CDENV", KlantTypes.organisatie, "Vlasmarkt 3 - Gent", "BE0111155555"));
                _klantRepo.Add(new Klant("Walker Johnny", KlantTypes.vip, " Schotlandstraat 12 - Ieper")); ;
                _klantRepo.Add(new Klant("Roadies", KlantTypes.concertpromotor, "Molenstraat 66 - Maldegem", "BE88887777"));
                _klantRepo.Add(new Klant("First Date", KlantTypes.huwelijksplanner, "Wolvengracht 56 - Gent", "BE6660000666"));
                _klantRepo.Add(new Klant("Hotel Romantiek", KlantTypes.huwelijksplanner, " Tirolstraat 23 - Zele", "BE4443332221"));
                _klantRepo.Add(new Klant("Partytime", KlantTypes.evenementenbureau, "Beekstraat 45 - Zomergem", "BE9990009999")) ;
                _klantRepo.Add(new Klant("Het Witte Paard", KlantTypes.huwelijksplanner, "Vluchtweg 18 - Lievegem", "BE8765432019"));
                _klantRepo.Add(new Klant("Puys Mireille", KlantTypes.particulier, " Dijk 18 - Oostende"));
                _klantRepo.Add(new Klant("De Visvijver", KlantTypes.organisatie, " Snoekstraat 2356 - Kluisbergen", "BE1231234567"));
                _klantRepo.Add(new Klant("VZW 70 +", KlantTypes.organisatie, "Kouter 78 - Gent", "BE7070707080"));
                _klantRepo.Add(new Klant("De Vucht Thierry", KlantTypes.vip, " Senaatstraat 1 - Brussel"));
                _klantRepo.Add(new Klant("Decibel", KlantTypes.concertpromotor, " Paterstraat 8 - Kortrijk", "BE9996663330"));
                _klantRepo.Add(new Klant("De Planckaerts", KlantTypes.huwelijksplanner, " Keistraat 9 - Oudenaarde", " BE1897654231"));
                _klantRepo.Add(new Klant("U80", KlantTypes.evenementenbureau, " Leopoldlaan 99 - Oostende", "BE8754963210"));
                #endregion
                #region Limousines
                _limoRepo.Add(new Limousine("Porsche Cayenne Limousine White", 310, 1500, 1200, 1600));
                _limoRepo.Add(new Limousine("Porsche Cayenne Limousine Electric Blue", 350, 1600, 1300, 1750));
                _limoRepo.Add(new Limousine("Mercedes SL 55 AMG Silver", 225, -9, 700, 1000));
                _limoRepo.Add(new Limousine("Tesla Model X - White", 600, -9, 2500, 2700));
                _limoRepo.Add(new Limousine("Tesla Model S - White", 500, -9, 2000, 2200));
                _limoRepo.Add(new Limousine("Porsche Cayenne Limousine White", 300, 1500, 1000, -9));
                _limoRepo.Add(new Limousine("Porsche Cayenne Limousine White", 300, 1500, 1000, -9));
                _limoRepo.Add(new Limousine("Porsche Cayenne Limousine White", 300, 1500, 1000, -9));
                _limoRepo.Add(new Limousine("Porsche Cayenne Limousine White", 300, 1500, 1000, -9));
                _limoRepo.Add(new Limousine("Porsche Cayenne Limousine White", 300, 1500, 1000, -9));
                _limoRepo.Add(new Limousine("Lincoln White XXL Navigator Limousine", 255, 790, 650, 950));
                _limoRepo.Add(new Limousine("Lincoln Pink Limousine", 180, 900, 500, 1000));
                _limoRepo.Add(new Limousine("Lincoln Black Limousine", 195, 850, 600, 1000));
                _limoRepo.Add(new Limousine("Hummer Limousine Yellow", 225, 1290, 790, 1500));
                _limoRepo.Add(new Limousine("Hummer Limousine Black", 195, 990, -9, 1100));
                _limoRepo.Add(new Limousine("Hummer Limousine White", 195, 990, -9, -9));
                _limoRepo.Add(new Limousine("Chrysler 300C Sedan - White", 175, -9, 450, 600));
                _limoRepo.Add(new Limousine("Chrysler 300C Sedan – Black", 175, -9, 450, 600));
                _limoRepo.Add(new Limousine("Chrysler 300C Limousine – White", 175, 800, 500, 1000));
                _limoRepo.Add(new Limousine("Chrysler 300C Limousine - Tuxedo Crème", 180, 800, 600,-9));
                #endregion
                #region Locaties
                _locaRepo.Add(new Locatie("Gent"));
                _locaRepo.Add(new Locatie("Antwerpen"));
                _locaRepo.Add(new Locatie("Brussel"));
                _locaRepo.Add(new Locatie("Hasselt"));
                _locaRepo.Add(new Locatie("Charleroi"));
                #endregion
                #region Staffelkorting
                _staffelRepo.Add(new Staffelkorting(2, 0.05, KlantTypes.vip));
                _staffelRepo.Add(new Staffelkorting(7, 0.075, KlantTypes.vip));
                _staffelRepo.Add(new Staffelkorting(15, 0.10, KlantTypes.vip));
                _staffelRepo.Add(new Staffelkorting(5, 0.075, KlantTypes.huwelijksplanner));
                _staffelRepo.Add(new Staffelkorting(10, 0.10, KlantTypes.huwelijksplanner));
                _staffelRepo.Add(new Staffelkorting(15, 0.125, KlantTypes.huwelijksplanner));
                _staffelRepo.Add(new Staffelkorting(20, 0.15, KlantTypes.huwelijksplanner));
                _staffelRepo.Add(new Staffelkorting(25, 0.25, KlantTypes.huwelijksplanner));
                #endregion
                _ctx.SaveChanges();
            }
            
        }
    }
}
