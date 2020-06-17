using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VIP_Services_Rudy_2020.BusinessLayer.Models
{
    public class Locatie
    {
        #region Attributes
        [Key]
        public int ID { get; set; }
        public string Naam { get; set; }
        public string StraatNaam { get; set; }
        public string straatNummer { get; set; }
        #endregion
        #region Constructors
        public Locatie(string mNaam)
        {
            Naam = mNaam;
        }
        public Locatie()
        {

        }
        #endregion
    }
}
