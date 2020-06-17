using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer.IRepositories;
using VIP_Services_Rudy_2020.BusinessLayer.Models;

namespace VIP_Services_Rudy_2020.DataLayer.Repositories
{
    public class StaffelkortingRepository : IStaffelkortingRepository
    {
        private readonly Context _context;
        private readonly DbSet<Staffelkorting> _staffelkortingen;
        public StaffelkortingRepository(Context context)
        {
            _context = context;
            _staffelkortingen = context.Staffelkortingen;
        }
        public void Add(Staffelkorting Klant)
        {
            _staffelkortingen.Add(Klant);
        }
        public void DeleteByID(int ID)
        {
            _staffelkortingen.Remove(_staffelkortingen.FirstOrDefault(x => x.ID == ID));
        }
        public IList<Staffelkorting> GetByKlantType(KlantTypes klantType)
        {
            return _staffelkortingen.Where(x => x.KlantType == klantType).ToList();
        }
        public IList<Staffelkorting> GetAll()
        {
            return _staffelkortingen.ToList();
        }

        public Staffelkorting GetByID(int ID)
        {
            return _staffelkortingen.FirstOrDefault(x => x.ID == ID);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
