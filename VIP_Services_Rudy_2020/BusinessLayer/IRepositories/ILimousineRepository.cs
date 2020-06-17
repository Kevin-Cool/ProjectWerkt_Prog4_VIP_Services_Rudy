using System;
using System.Collections.Generic;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer.Models;

namespace VIP_Services_Rudy_2020.BusinessLayer.IRepositories
{
    public interface ILimousineRepository
    {
        public void Add(Limousine Limousine);
        public Limousine GetByID(int ID);
        public IList<Limousine> GetAll();
        public void DeleteByID(int ID);
        public void SaveChanges();
    }
}
