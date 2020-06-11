using System;
using System.Collections.Generic;
using System.Text;

namespace VIP_Services_Rudy_2020.BusinessLayer.Classes
{
    public class Klant
    {
        #region Attributes
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Categorie { get; set; }
        public string BTWnummer { get; set; }
        public string Adres { get; set; }
        #endregion
        #region Constructors
        public Klant(string mNaam,string mCategorie, string mBTWnummer, string mAdres)
        {
            SetNaam(mNaam);
            SetCategorie(mCategorie);
            SetBTWnummer(mBTWnummer);
            SetAdres(mAdres);
        }
        public Klant()
        {

        }
        #endregion
        #region Setters
        public void SetNaam(string mNaam)
        {
            Naam = mNaam;
        }
        public void SetCategorie(string mCategorie)
        {
            Categorie = mCategorie;
        }
        public void SetBTWnummer(string mBTWnummer)
        {
            BTWnummer = mBTWnummer;
        }
        public void SetAdres(string mAdres)
        {
            Adres = mAdres;
        }
        #endregion
    }
}
