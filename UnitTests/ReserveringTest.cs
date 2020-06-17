using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VIP_Services_Rudy_2020.BusinessLayer;
using VIP_Services_Rudy_2020.BusinessLayer.Models;
using VIP_Services_Rudy_2020.DataLayer;
using FluentAssertions;
using System.Security.Cryptography.X509Certificates;

namespace UnitTests
{
    [TestClass]
    public class ReserveringTest
    {
        private DomainController DC;
        private Reservering testReservering = new Reservering(5, DateTime.Now, new Locatie("Gent"), new Locatie("Gent"), new Limousine("Giga Limo 9000", 69, 69, 69, 69), new Klant("klantNaam", KlantTypes.vip, "somewhere", ""), ReserveringType.Business);
        
        [TestInitialize]
        public void SetUp()
        {
            DC = new DomainController(new ContextTest(false));
        }

        [TestMethod]
        public void Reservering_AddCorrectReservering_CreatesReservering()
        {
            DC.Add(testReservering);

            Reservering tempReservering = (Reservering)DC.GetByID(1, "Reservering");
            tempReservering.GereserveerdeTijd.Should().Be(testReservering.GereserveerdeTijd);
            tempReservering.StartDatum.Should().Be(testReservering.StartDatum);
            tempReservering.StartPlaats.Should().Be(testReservering.StartPlaats);
            tempReservering.EindPlaats.Should().Be(testReservering.EindPlaats);
            tempReservering.Limousine.Should().Be(testReservering.Limousine);
            tempReservering.Klant.Should().Be(testReservering.Klant);
            tempReservering.ReservatieType.Should().Be(testReservering.ReservatieType);
        }
        [TestMethod]
        public void Reservering_AddReserveringWith12GereserveerdeTijd_ThrowsException()
        {
            Reservering tempRes = new Reservering(69, DateTime.Now, new Locatie("Gent"), new Locatie("Gent"), new Limousine("Giga Limo 9000", 69, 69, 69, 69), new Klant("klantNaam", KlantTypes.vip, "somewhere", ""), ReserveringType.Business);

            Action act = () => DC.Add(tempRes);

            act.Should().Throw<ArgumentException>()
                        .WithMessage("Gereserveerde tijd mag niet boven 11 zijn.");
        }
        [TestMethod]
        public void Reservering_AddReserveringWithtoWrongTimeForNightLife_ThrowsException()
        {
            
            Reservering tempRes = new Reservering(8, new DateTime(2020,1,1,9,0,0), new Locatie("Gent"), new Locatie("Gent"), new Limousine("Giga Limo 9000", 69, 69, 69, 69), new Klant("klantNaam", KlantTypes.vip, "somewhere", ""), ReserveringType.NightLife);

            Action act = () => DC.Add(tempRes);

            act.Should().Throw<ArgumentException>()
                        .WithMessage("NightLife reserveringen mogen niet voor 20 uur of na 24 uur gestart worden.");
        }
        [TestMethod]
        public void Reservering_AddReserveringWithtoWrongTimeWedding_ThrowsException()
        {

            Reservering tempRes = new Reservering(8, new DateTime(2020, 1, 1, 2, 0, 0), new Locatie("Gent"), new Locatie("Gent"), new Limousine("Giga Limo 9000", 69, 69, 69, 69), new Klant("klantNaam", KlantTypes.vip, "somewhere", ""), ReserveringType.Wedding);

            Action act = () => DC.Add(tempRes);

            act.Should().Throw<ArgumentException>()
                        .WithMessage("Wedding reserveringen mogen niet voor 7 uur of na 15 uur gestart worden.");
        }
        [TestMethod]
        public void Reservering_AddReserveringWithtoWrongTimeWellness_ThrowsException()
        {

            Reservering tempRes = new Reservering(8, new DateTime(2020, 1, 1, 2, 0, 0), new Locatie("Gent"), new Locatie("Gent"), new Limousine("Giga Limo 9000", 69, 69, 69, 69), new Klant("klantNaam", KlantTypes.vip, "somewhere", ""), ReserveringType.Wellness);

            Action act = () => DC.Add(tempRes);

            act.Should().Throw<ArgumentException>()
                        .WithMessage("Wellness reserveringen mogen niet voor 7 uur of na 12 uur gestart worden.");
        }
        [TestMethod]
        public void Reservering_AddReserveringMetLimoBinnen6UurVanEenAnder_ThrowsException()
        {
            DC.Add(testReservering);
            Reservering tempRes = new Reservering(8, new DateTime(2020, 1, 22, 2, 0, 0), new Locatie("Gent"), new Locatie("Gent"), new Limousine("Giga Limo 9000", 69, 69, 69, 69), new Klant("klantNaam", KlantTypes.vip, "somewhere", ""), ReserveringType.Wedding);

            Action act = () => DC.Add(tempRes);

            act.Should().Throw<ArgumentException>();
        }
        [TestMethod]
        public void Reservering_AddReserveringMetFouteLimousine_ThrowsException()
        {
            Reservering tempRes = new Reservering(8, new DateTime(2020, 1, 10, 2, 0, 0), new Locatie("Gent"), new Locatie("Gent"), new Limousine("Giga Limo 9000", 69, 69, -9, 69), new Klant("klantNaam", KlantTypes.vip, "somewhere", ""), ReserveringType.Wedding);

            Action act = () => DC.Add(tempRes);

            act.Should().Throw<ArgumentException>();
        }
    }
}
