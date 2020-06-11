using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer;

namespace VIP_Services_Rudy_2020.DataLayer
{
    public class Context : DbContext
    {
        private string connectionString;

        public Context()
        {
        }

        public Context(string db = "Production") : base()
        {
            SetConnectionString(db);
        }

        private void SetConnectionString(string db = "Production")
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();
            switch (db)
            {
                case "Production":
                    connectionString = configuration.GetConnectionString("ProdSQLconnection").ToString();
                    break;
                case "Test":
                    connectionString = configuration.GetConnectionString("TestSQLconnection").ToString();
                    break;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (connectionString == null)
            {
                SetConnectionString();
            }
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
