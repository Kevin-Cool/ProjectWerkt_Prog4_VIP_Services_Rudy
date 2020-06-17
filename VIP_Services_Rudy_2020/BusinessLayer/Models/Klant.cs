using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VIP_Services_Rudy_2020.BusinessLayer.Models
{
    public class Klant
    {
        #region Attributes
        [Key]
        public int ID { get; set; }
        public string Naam { get; set; }
        public KlantTypes Categorie { get; set; }
        public string BTWnummer { get; set; }
        public string Adres { get; set; }
        #endregion
        #region Constructors
        public Klant(string mNaam, KlantTypes mCategorie, string mAdres, string mBTWnummer = "")
        {
            Naam = mNaam.Trim();
            Categorie = mCategorie;
            BTWnummer = (string)mBTWnummer.Trim(); 
            Adres = mAdres.Trim();
        }
        public Klant()
        {

        }
        #endregion
    }
}
