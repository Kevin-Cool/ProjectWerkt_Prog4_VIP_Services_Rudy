using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VIP_Services_Rudy_2020.BusinessLayer.Models
{
    public class Limousine
    {
        #region Attributes
        [Key]
        public int ID { get; set; }
        public string Naam { get; set; }
        public double EersteUur { get; set; }
        public double Nightlife { get; set; }
        public double Wedding { get; set; }
        public double Wellness { get; set; }
        #endregion
        #region Constructors
        public Limousine(string mNaam, double mEersteUur, double mNightlife, double mWedding, double mWellness)
        {
            Naam = mNaam;
            if (mEersteUur != -9) { EersteUur = mEersteUur; }
            if (mNightlife != -9) { Nightlife = mNightlife; }
            if (mWedding   != -9) { Wedding = mWedding;     }
            if (mWellness  != -9) { Wellness = mWellness;   }
        }
        public Limousine()
        {

        }
        #endregion

    }
}
