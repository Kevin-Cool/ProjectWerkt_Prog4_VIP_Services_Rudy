using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer.IRepositories;
using VIP_Services_Rudy_2020.BusinessLayer.Models;

namespace VIP_Services_Rudy_2020.DataLayer.Repositories
{
    public class KlantRepository : IKlantRepository
    {
        private readonly Context _context;
        private readonly DbSet<Klant> _klanten;
        public  KlantRepository(Context context)
        {
            _context = context;
            _klanten = context.Klanten;
        }
        public void Add(Klant Klant)
        {
            _klanten.Add(Klant);
        }
        public void DeleteByID(int ID)
        {
            _klanten.Remove(_klanten.FirstOrDefault(x => x.ID == ID));
        }

        public IList<Klant> GetAll()
        {
            return _klanten.ToList();
        }

        public Klant GetByID(int ID)
        {
            return _klanten.FirstOrDefault(x => x.ID == ID);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
