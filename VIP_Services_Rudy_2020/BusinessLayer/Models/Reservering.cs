using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VIP_Services_Rudy_2020.BusinessLayer.Models
{
    public class Reservering
    {
        #region Attributes
        [Key]
        public int ID { get; set; }
        public int GereserveerdeTijd { get; set; }
        public DateTime StartDatum { get; set; }
        public Locatie StartPlaats { get; set; }
        public Locatie EindPlaats { get; set; }
        public Limousine Limousine { get; set; }
        public Klant Klant { get; set; }
        public ReserveringType ReservatieType { get; set; }
        public double Cost { get; set; }
        [NotMapped]
        public string toString { get { return ToString(); } }
        [NotMapped]
        public Dictionary<string, double> CostInfo { get; set; }
        #endregion
        #region Constructors
        public Reservering(int mGereserveerdeTijd, DateTime mStartDatum, Locatie mStratPlaats, Locatie mEindPlaats, Limousine mLimousine, Klant mKlant, ReserveringType mReservatieType)
        {
            GereserveerdeTijd = mGereserveerdeTijd;
            StartDatum = mStartDatum;
            StartPlaats = mStratPlaats;
            EindPlaats = mEindPlaats;
            Limousine = mLimousine;
            Klant = mKlant;
            ReservatieType = mReservatieType;
        }
        public Reservering()
        {

        }
        #endregion
        #region methods
        public int BerekenPrijs()
        {
            Cost = 0;
            if ((ReservatieType == ReserveringType.Airport) || (ReservatieType == ReserveringType.Business))
            {
                //aantal uur 
                int AantalUur = (GereserveerdeTijd);
                int CurrentTime = StartDatum.Hour;
                Cost =  Limousine.EersteUur;
                for (int i = 1; i < AantalUur; i++)
                {
                    int Aantal5 = 0;
                    if ((CurrentTime >= 22) || (CurrentTime < 7))
                    {
                        Aantal5 = ((140 * ((int)Limousine.EersteUur / 100)) / 5);
                    }
                    else
                    {
                        Aantal5 = ((65 * ((int)Limousine.EersteUur / 100)) / 5);
                    }
                    Cost += Aantal5 * 5;
                    CurrentTime++;
                    if (CurrentTime.Equals(24))
                    {
                        CurrentTime = 0;
                    }
                }
            }
            else
            {
                if (ReservatieType == ReserveringType.NightLife)
                {
                    Cost = Limousine.Nightlife;
                    if (GereserveerdeTijd > 7)
                    {
                        int AantalUur = (GereserveerdeTijd) - 7;
                        int CurrentTime = StartDatum.Hour;
                        for (int i = 1; i < AantalUur; i++)
                        {

                            int Aantal5 = ((140 * ((int)Limousine.EersteUur / 100)) / 5);

                            Cost += Aantal5 * 5;
                            CurrentTime++;
                            if (CurrentTime.Equals(24))
                            {
                                CurrentTime = 0;
                            }
                        }
                    }
                }
                else
                if (ReservatieType == ReserveringType.Wedding)
                {
                    Cost =  Limousine.Wedding;
                    if (GereserveerdeTijd > 7)
                    {
                        int AantalUur = (GereserveerdeTijd) - 7;
                        int CurrentTime = StartDatum.Hour;
                        for (int i = 1; i < AantalUur; i++)
                        {
                            int Aantal5 = 0;
                            if ((CurrentTime >= 22) || (CurrentTime < 7))
                            {
                                Aantal5 = ((140 * ((int)Limousine.EersteUur / 100)) / 5);
                            }
                            else
                            {
                                Aantal5 = ((65 * ((int)Limousine.EersteUur / 100)) / 5);
                            }
                            Cost += Aantal5 * 5;
                            CurrentTime++;
                            if (CurrentTime.Equals(24))
                            {
                                CurrentTime = 0;
                            }
                        }
                    }
                }
                else
                if (ReservatieType == ReserveringType.Wellness)
                {
                    Cost =  Limousine.Wellness;
                    if (GereserveerdeTijd > 10)
                    {
                        int AantalUur = (GereserveerdeTijd) - 10;
                        int CurrentTime = StartDatum.Hour;
                        for (int i = 1; i < AantalUur; i++)
                        {
                            int Aantal5 = 0;
                            if ((CurrentTime >= 22) || (CurrentTime < 7))
                            {
                                Aantal5 = ((140 * ((int)Limousine.EersteUur / 100)) / 5);
                            }
                            else
                            {
                                Aantal5 = ((65 * ((int)Limousine.EersteUur / 100)) / 5);
                            }

                            Cost += Aantal5 * 5;
                            CurrentTime++;
                            if (CurrentTime.Equals(24))
                            {
                                CurrentTime = 0;
                            }
                        }
                    }
                }
            }
            Cost = ((int)Math.Round(Cost / 5.0)) * 5;
            return (int)Cost;
        }
        public override string ToString()
        {
            if (CostInfo is null)
            {
                return $"GereserveerdeTijd:{GereserveerdeTijd} ,\nStartDatum:{StartDatum.ToShortDateString() + " " + StartDatum.ToShortTimeString()} ,\nStratPlaats:{StartPlaats.Naam},\nEindPlaats:{EindPlaats.Naam},\nKlant:{Klant.Naam},\nReservatieType:{ReservatieType},\nCost:{BerekenPrijs()}";
            }
            else
            {
                return $"GereserveerdeTijd:{GereserveerdeTijd} ,\nStartDatum:{StartDatum.ToShortDateString() + " " + StartDatum.ToShortTimeString()} ,\nStratPlaats:{StartPlaats.Naam},\nEindPlaats:{EindPlaats.Naam},\nKlant:{Klant.Naam},\nReservatieType:{ReservatieType},\nPrijs:{CostInfo["eenheidsprijs"]},\nKorting:{CostInfo["Korting"]},\nHet BTW bedrag:{CostInfo["BTWBedrag"]},\nHet totaal bedrag inclusief BTW: { CostInfo["TotaalInclusiefBTW"]}";
            }
        }
        #endregion

    }
}
