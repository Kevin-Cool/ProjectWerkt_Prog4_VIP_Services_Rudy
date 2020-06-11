using System;
using System.Collections.Generic;
using System.Text;

namespace VIP_Services_Rudy_2020.BusinessLayer.Classes
{
    public class limousine
    {
        #region Attributes
        public int ID { get; set; }
        public string Naam { get; set; }
        public double EersteUur { get; set; }
        public double Nightlife { get; set; }
        public double Wedding { get; set; }
        public double Wellness { get; set; }
        #endregion
        #region Constructors
        public limousine(string mNaam, double mEersteUur, double mNightlife, double mWedding, double mWellness)
        {
            SetNaam(mNaam);
            SetEersteUur(mEersteUur);
            SeNightlife(mNightlife);
            SetWedding(mWedding);
            SetWellness(mWellness);
        }
        public limousine()
        {

        }
        #endregion
        #region Setters
        public void SetNaam(string mNaam)
        {
            Naam = mNaam;
        }
        public void SetEersteUur(double mEersteUur)
        {
            EersteUur = mEersteUur;
        }
        public void SeNightlife(double mNightlife)
        {
            Nightlife = mNightlife;
        }
        public void SetWedding(double mWedding)
        {
            Wedding = mWedding;
        }
        public void SetWellness(double mWellness)
        {
            Wellness = mWellness;
        }
        #endregion
    }
}
