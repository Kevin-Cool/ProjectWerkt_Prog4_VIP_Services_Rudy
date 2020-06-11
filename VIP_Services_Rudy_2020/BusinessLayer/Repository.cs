using System;
using System.Collections.Generic;
using System.Text;
using VIP_Services_Rudy_2020.DataLayer;

namespace VIP_Services_Rudy_2020.BusinessLayer
{
    public class Repository
    {
        private Context _context;

        public Repository(Context mContext)
        {
            _context = mContext;
        }



    }
}
