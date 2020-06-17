using System;
using System.Collections.Generic;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer.Models;

namespace VIP_Services_Rudy_2020.BusinessLayer.IRepositories
{
    public interface ILocatieRepository
    {
        public void Add(Locatie Locatie);
        public Locatie GetByID(int ID);
        public IList<Locatie> GetAll();
        public void DeleteByID(int ID);
        public void SaveChanges();
    }
}
