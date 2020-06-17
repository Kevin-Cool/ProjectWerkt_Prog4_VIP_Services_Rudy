using MVVM2.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VIP_Services_Rudy_2020.BusinessLayer.Models;

namespace MVVM2.Views
{
    /// <summary>
    /// Interaction logic for StartPaginaView.xaml
    /// </summary>
    
    public partial class StartPaginaView : Page
    {
        public StartPaginaViewModel ViewModel { get; set; }
        public StartPaginaView()
        {
            InitializeComponent();
            ViewModel = new StartPaginaViewModel();
            DataContext = ViewModel;

            /*
            foreach (var item in ViewModel.GetKlanten())
            {
                KlantDropDown.Items.Add(item.Naam);
            }*/
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           /* ViewModel = new StartPaginaViewModel();
            DataContext = ViewModel;*/
        }

        private void KlantDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectedKlant = KlantDropDown.SelectedItem as Klant;
        }
        private void KlantSelectDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectedKlantZoeken = KlantSelect.SelectedItem as Klant;
        }
        private void LimousineDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectedLimousine = LimousineDropDown.SelectedItem as Limousine;
        }
        private void StartLocatieDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.StartLocatie = StartLocatieDropDown.SelectedItem as Locatie;
        }
        private void EindLocatieDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.EindLocatie = EindLocatieDropDown.SelectedItem as Locatie;
        }

        private void AantalUur_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void DatumSelect_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           // ViewModel.DatumReservatie = DatumSelect.DisplayDate;
        }

        private void Uur_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void ReservatiType_Loaded(object sender, RoutedEventArgs e)
        {
            ReservatiType.ItemsSource = Enum.GetValues(typeof(ReserveringType));
        }

        private void ReservatiType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.ReserveringType = (ReserveringType)ReservatiType.SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DatumReservatie = (DateTime)DatumSelect.SelectedDate;
            ViewModel.AantalUurOntvangen(AantalUur.Text);
            ViewModel.UurOntvangen(Uur.Text);
            ViewModel.MaakNiewReservatie();
        }
        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
           //nothing
        }

        private void GeefReserveringenKlant(object sender, RoutedEventArgs e)
        {
            ViewModel.PasLijstReserveringenAanOpKlant();
        }

        private void GeefReserveringenDatum(object sender, RoutedEventArgs e)
        {
            ViewModel.PasLijstReserveringenAanOpDatum();
        }

        private void ShowAll(object sender, RoutedEventArgs e)
        {
            ViewModel.GetAll();
        }
    }
}
