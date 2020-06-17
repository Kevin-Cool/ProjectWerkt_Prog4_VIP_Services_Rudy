using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer.IRepositories;
using VIP_Services_Rudy_2020.BusinessLayer.Models;

namespace VIP_Services_Rudy_2020.DataLayer.Repositories
{
    public class LimousineRepository : ILimousineRepository
    {
        private readonly Context _context;
        private readonly DbSet<Limousine> _limousines;
        public LimousineRepository(Context context)
        {
            _context = context;
            _limousines = context.Limousines;
        }

        public void Add(Limousine Limousine)
        {
            _limousines.Add(Limousine);
        }

        public void DeleteByID(int ID)
        {
            _limousines.Remove(_limousines.FirstOrDefault(x => x.ID == ID));
        }

        public IList<Limousine> GetAll()
        {
            return _limousines.ToList();
        }

        public Limousine GetByID(int ID)
        {
            return _limousines.FirstOrDefault(x => x.ID == ID);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
