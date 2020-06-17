using System;
using System.Collections.Generic;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer.Models;

namespace VIP_Services_Rudy_2020.BusinessLayer.IRepositories
{
    public interface IKlantRepository
    {
        public void Add(Klant Klant);
        public Klant GetByID(int ID);
        public IList<Klant> GetAll();
        public void DeleteByID(int ID);
        public void SaveChanges();
    }
}
