using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_interface_graphique
{
    internal class TP2Context : DbContext 
    {
        public DbSet<Models.Users> Users { get; set; }

        public DbSet<Models.Predictions> Predictions { get; set; }  

        public DbSet<Models.Parameters> Parameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) 
        {
            string ConnexionString = "server=localhost;Port=3306;database=tp2;user=usertp2;password=Test1234;";
            dbContextOptionsBuilder.UseMySql(ConnexionString);
        
        }


    }
}
