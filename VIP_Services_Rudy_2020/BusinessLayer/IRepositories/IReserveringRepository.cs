using System;
using System.Collections.Generic;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer.Models;

namespace VIP_Services_Rudy_2020.BusinessLayer.IRepositories
{
    public interface IReserveringRepository
    {
        public void Add(Reservering Reservering);
        public Reservering GetByID(int ID);
        public int getAantalReservering(Reservering Reservering);
        public IList<Reservering> getReserveringMetLimousine(Limousine Limousine);
        public IList<Reservering> GetAll();
        public void DeleteByID(int ID);
        public void SaveChanges();
    }
}
