using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer.IRepositories;
using VIP_Services_Rudy_2020.BusinessLayer.Models;
using VIP_Services_Rudy_2020.DataLayer;
using VIP_Services_Rudy_2020.DataLayer.Repositories;
using System.Linq;

namespace VIP_Services_Rudy_2020.BusinessLayer
{
    public class DomainController
    {
        private IKlantRepository _klantRepo;
        private ILimousineRepository _limoRepo;
        private ILocatieRepository _locaRepo;
        private IStaffelkortingRepository _staffelRepo;
        private IReserveringRepository _reserRepo;
        public DomainController(Context context)
        {
            _klantRepo = new KlantRepository(context);
            _limoRepo = new LimousineRepository(context);
            _locaRepo = new LocatieRepository(context);
            _staffelRepo = new StaffelkortingRepository(context);
            _reserRepo = new ReserveringRepository(context);
        }
        public DomainController(IKlantRepository IKlantRepository, ILimousineRepository ILimousineRepository , ILocatieRepository ILocatieRepository, IStaffelkortingRepository IStaffelkortingRepository, IReserveringRepository IReserveringRepository)
        {
            _klantRepo = IKlantRepository;
            _limoRepo = ILimousineRepository;
            _locaRepo = ILocatieRepository;
            _staffelRepo = IStaffelkortingRepository;
            _reserRepo = IReserveringRepository;
        }
        public void Add(object Object)
        {
            switch (Object)
            {
                case Klant Klant:
                    _klantRepo.Add(Klant);
                    break;
                case Limousine Limousine:
                    _limoRepo.Add(Limousine);
                    break;
                case Locatie Locatie:
                    _locaRepo.Add(Locatie);
                    break;
                case Staffelkorting Staffelkorting:
                    _staffelRepo.Add(Staffelkorting);
                    break;
                case Reservering Reservering:
                    if(Reservering.GereserveerdeTijd > 11)
                    {
                        throw new ArgumentException("Gereserveerde tijd mag niet boven 11 zijn.");
                    }
                    if(( Reservering.ReservatieType.Equals(ReserveringType.NightLife)) && (Reservering.StartDatum.Hour < 20))
                    {
                        throw new ArgumentException("NightLife reserveringen mogen niet voor 20 uur of na 24 uur gestart worden.");
                    }
                    if ((Reservering.ReservatieType.Equals(ReserveringType.Wedding)) &&(( (Reservering.StartDatum.Hour < 7))||(Reservering.StartDatum.Hour > 15)))
                    {
                        throw new ArgumentException("Wedding reserveringen mogen niet voor 7 uur of na 15 uur gestart worden.");
                    }
                    if ((Reservering.ReservatieType.Equals(ReserveringType.Wellness)) && (((Reservering.StartDatum.Hour < 7)) || (Reservering.StartDatum.Hour > 12)))
                    {
                        throw new ArgumentException("Wellness reserveringen mogen niet voor 7 uur of na 12 uur gestart worden.");
                    }
                    if (_reserRepo.getReserveringMetLimousine(Reservering.Limousine).Any(r =>
                        // reservering tussen nu en 6 uur
                        (Reservering.StartDatum.CompareTo(r.StartDatum) >= 0 && Reservering.StartDatum.AddHours(6).CompareTo(r.StartDatum) <= 0) ||
                        // reservering tussen -6 uur en nu
                        (Reservering.StartDatum.CompareTo(r.StartDatum) <= 0 && Reservering.StartDatum.AddHours(-6).CompareTo(r.StartDatum) >= 0))
                        )
                        {
                        throw new ArgumentException("Er moet minstens 6 uur tussen het hergebruik van eenzelfde limousine zijn.");
                        }
                    _reserRepo.Add(Reservering);
                    break; 
                default:
                    break;
            }
            _klantRepo.SaveChanges();
        }
        public void DeleteByID<T>(int ID)
        {
            switch (default(T))
            {
                case Klant Klant:
                    _klantRepo.DeleteByID(ID);
                    break;
                case Limousine Limousine:
                    _limoRepo.DeleteByID(ID);
                    break;
                case Locatie Locatie:
                    _locaRepo.DeleteByID(ID);
                    break;
                case Staffelkorting Staffelkorting:
                    _staffelRepo.DeleteByID(ID);
                    break;
                case Reservering Reservering:
                    _reserRepo.DeleteByID(ID);
                    break;
                default:
                    break;
            }
            _klantRepo.SaveChanges();
        }
        public object GetAll(string type)
        {
            switch (type)
            {
                case "Klant":
                    return _klantRepo.GetAll();
                case "Limousine":
                    return _limoRepo.GetAll();
                case "Locatie":
                    return _locaRepo.GetAll();
                case "Staffelkorting" :
                    return _staffelRepo.GetAll();
                case "Reservering":
                    return _reserRepo.GetAll();
                default:
                    break;
            }
            return null;
        }
        public object GetByID(int ID,string bono)
        {
            switch (bono)
            {
                case "Klant" :
                    return  _klantRepo.GetByID(ID);
                case "Limousine" :
                    return _limoRepo.GetByID(ID);
                case "Locatie" :
                    return _locaRepo.GetByID(ID);
                case "Staffelkorting" :
                    return _staffelRepo.GetByID(ID);
                case "Reservering" :
                    return _reserRepo.GetByID(ID);
                default:
                    break;
            }
            return null;
        }

        public Dictionary<string,double> CalculateReserveringCost(Reservering Reservatie)
        {
            //eenheidsprijs , subtotaal , aangerekende korting , totalen exclusief btw , btw bedrag, te betalen
            Dictionary<string, double> ReturnDictionary = new Dictionary<string, double>();
            //get lijst staffelkortingen 
            List<Staffelkorting> staffelkortingen = _staffelRepo.GetByKlantType(Reservatie.Klant.Categorie).ToList();
            //get aantal reserveringen laatste jaar
            int aantalReservereingen = _reserRepo.getAantalReservering(Reservatie);
            //bereken korting 
            ReturnDictionary.Add("Korting", 0);
            foreach (Staffelkorting staff in staffelkortingen)
            {
                if (staff.Aantal < aantalReservereingen)
                {
                    ReturnDictionary["Korting"] = staff.Korting;
                }
            }
            //berkenen prijs
            int tempPrijst = Reservatie.BerekenPrijs();
            ReturnDictionary.Add("eenheidsprijs",tempPrijst - ((tempPrijst / 100)* ReturnDictionary["Korting"]));
            //bereken 6% btw
            double tempBTW = ((ReturnDictionary["eenheidsprijs"] / 100) * 6);
            ReturnDictionary.Add("BTWBedrag", (Math.Round(tempBTW, 2)));
            //toevoegen van de btw
            ReturnDictionary.Add("TotaalInclusiefBTW", (Math.Round((ReturnDictionary["eenheidsprijs"] + ReturnDictionary["BTWBedrag"])));
            return ReturnDictionary;
        }
    }
}
