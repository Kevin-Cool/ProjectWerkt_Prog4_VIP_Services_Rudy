using System;
using System.Collections.Generic;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer.Models;

namespace VIP_Services_Rudy_2020.BusinessLayer.IRepositories
{
    public interface IStaffelkortingRepository
    {
        public void Add(Staffelkorting Staffelkorting);
        public Staffelkorting GetByID(int ID);
        public IList<Staffelkorting> GetByKlantType(KlantTypes klantType);
        public IList<Staffelkorting> GetAll();
        public void DeleteByID(int ID);
        public void SaveChanges();
    }
}
