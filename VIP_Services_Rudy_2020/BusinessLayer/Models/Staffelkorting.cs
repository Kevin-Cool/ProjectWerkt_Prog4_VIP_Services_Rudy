using System;
using System.Collections.Generic;
using System.Text;

namespace VIP_Services_Rudy_2020.BusinessLayer.Models
{
    public class Staffelkorting
    {
        #region Attributes
        public int ID { get; set; }
        public int Aantal { get; set; }
        public double Korting { get; set; }
        public KlantTypes KlantType { get; set; }
        #endregion
        #region Constructors
        public Staffelkorting(int mAantal, double mKorting,KlantTypes mKlantTypes)
        {
            Aantal = mAantal;
            Korting = mKorting;
            KlantType = mKlantTypes;
        }
        public Staffelkorting()
        {

        }
        #endregion
    }
}
