using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer.IRepositories;
using VIP_Services_Rudy_2020.BusinessLayer.Models;

namespace VIP_Services_Rudy_2020.DataLayer.Repositories
{
    public class LocatieRepository : ILocatieRepository
    {
        private readonly Context _context;
        private readonly DbSet<Locatie> _locatie;
        public LocatieRepository(Context context)
        {
            _context = context;
            _locatie = context.Locaties;
        }

        public void Add(Locatie Locatie)
        {
            _locatie.Add(Locatie);
        }

        public void DeleteByID(int ID)
        {
            _locatie.Remove(_locatie.FirstOrDefault(x => x.ID == ID));
        }

        public IList<Locatie> GetAll()
        {
            return _locatie.ToList();
        }

        public Locatie GetByID(int ID)
        {
            return _locatie.FirstOrDefault(x => x.ID == ID);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
