using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer.IRepositories;
using VIP_Services_Rudy_2020.BusinessLayer.Models;

namespace VIP_Services_Rudy_2020.DataLayer.Repositories
{
    public class ReserveringRepository : IReserveringRepository
    {
        private readonly Context _context;
        private readonly DbSet<Reservering> _reservering;
        public ReserveringRepository(Context context)
        {
            _context = context;
            _reservering = context.Reserveringen;
        }

        public void Add(Reservering Reservering)
        {
            _reservering.Add(Reservering);
        }


        public void DeleteByID(int ID)
        {
            _reservering.Remove(_reservering.FirstOrDefault(x => x.ID == ID));
        }

        public int getAantalReservering(Reservering Reservering)
        {
            DateTime datum1jan = new DateTime(DateTime.Now.Year,1,1);
            return _reservering.Where(x => x.Klant == Reservering.Klant && DateTime.Compare(x.StartDatum, datum1jan) > 0 && Reservering.StartDatum > x.StartDatum).Count();
        }

        public IList<Reservering> getReserveringMetLimousine(Limousine Limousine)
        {
            return _reservering.Where(x => x.Limousine == Limousine).ToList();
        }

        public IList<Reservering> GetAll()
        {
            return _reservering.ToList();
        }

        public Reservering GetByID(int ID)
        {
            return _reservering.FirstOrDefault(x => x.ID == ID);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
