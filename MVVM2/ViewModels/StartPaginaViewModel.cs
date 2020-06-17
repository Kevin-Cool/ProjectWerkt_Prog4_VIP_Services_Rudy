using GalaSoft.MvvmLight;
using MVVM2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using VIP_Services_Rudy_2020.BusinessLayer;
using VIP_Services_Rudy_2020.BusinessLayer.IRepositories;
using VIP_Services_Rudy_2020.BusinessLayer.Models;
using VIP_Services_Rudy_2020.DataLayer;
using VIP_Services_Rudy_2020.DataLayer.Repositories;

namespace MVVM2.ViewModels
{
    public class StartPaginaViewModel : ViewModelBase
    {
        public DomainController DC;
        public List<Klant> LijstKlanten { get; set; }
        public Klant SelectedKlant { get; set; }
        public Klant SelectedKlantZoeken { get; set; }
        public List<Limousine> LijstLimousine { get; set; }
        public Limousine SelectedLimousine { get; set; }
        public List<Locatie> LijstLocaties { get; set; }
        public Locatie StartLocatie { get; set; }
        public Locatie EindLocatie { get; set; }
        public int AantalUur { get; set; }
        public DateTime DatumReservatie { get; set; } = DateTime.Today;
        public DateTime DatumReservatieZoeken { get; set; } = DateTime.Today;
        public ReserveringType ReserveringType { get; set; }
        public ObservableCollection<Reservering> LijstReserveringen { get; set; } = new ObservableCollection<Reservering>();
        public StartPaginaViewModel()
        {
            Context ctx = new Context("Production");
            DC = new DomainController(ctx);
            GetAll();
        }
        public void GetAll()
        {
            LijstKlanten = (List<Klant>)DC.GetAll("Klant");
            LijstLimousine = (List<Limousine>)DC.GetAll("Limousine");
            LijstLocaties = (List<Locatie>)DC.GetAll("Locatie");
            List<Reservering> tempList = (List<Reservering>)DC.GetAll("Reservering");
            tempList = tempList.OrderByDescending(x => x.StartDatum).ToList();
            for (int i = 0; i < tempList.Count; i++)
            {
                tempList[i].CostInfo = DC.CalculateReserveringCost(tempList[i]);
            }
            LijstReserveringen.Clear();
            foreach (var item in tempList)
            {
                LijstReserveringen.Add(item);
            }
        }
        public void AantalUurOntvangen(string s)
        {
            int parsedInt = 0;
            if (int.TryParse(s, out parsedInt))
            {
                AantalUur = parsedInt;
            }
        }
        public void UurOntvangen(string s)
        {
            int parsedInt = 0;
            if (int.TryParse(s, out parsedInt))
            {
                DatumReservatie += new TimeSpan(parsedInt,0,0) ;
            }
        }
        public void MaakNiewReservatie()
        {
            try
            {
                DC.Add(new Reservering(AantalUur, DatumReservatie, StartLocatie, EindLocatie, SelectedLimousine, SelectedKlant, ReserveringType));
                MessageBox.Show("Reservatie Toe gevoeged.");
                GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void PasLijstReserveringenAanOpKlant()
        {
            List<Reservering> tempList = (List<Reservering>)DC.GetAll("Reservering");
            tempList = tempList.OrderByDescending(x => x.StartDatum).ToList();
            for (int i = 0; i < tempList.Count; i++)
            {
                tempList[i].CostInfo = DC.CalculateReserveringCost(tempList[i]);
            }
            LijstReserveringen.Clear();
            foreach (var item in tempList)
            {
                if (item.Klant.Equals(SelectedKlantZoeken))
                {
                    LijstReserveringen.Add(item);
                }
            }
        }
        public void PasLijstReserveringenAanOpDatum()
        {
            List<Reservering> tempList = (List<Reservering>)DC.GetAll("Reservering");
            tempList = tempList.OrderByDescending(x => x.StartDatum).ToList();
            for (int i = 0; i < tempList.Count; i++)
            {
                tempList[i].CostInfo = DC.CalculateReserveringCost(tempList[i]);
            }
            LijstReserveringen.Clear();
            foreach (var item in tempList)
            {//(item.StartDatum.Equals(DatumReservatieZoeken))
                if ((item.StartDatum.Year.Equals(DatumReservatieZoeken.Year)) && (item.StartDatum.Month.Equals(DatumReservatieZoeken.Month)) && (item.StartDatum.Day.Equals(DatumReservatieZoeken.Day)))
                {
                    LijstReserveringen.Add(item);
                }
            }
        }
    }
}
