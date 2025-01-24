using EnvanterMVC.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvanterMVC.Entities.Model.Context
{
    public class EnvanterContext : DbContext
    {
        public EnvanterContext() : base("Envanter")
        {
            
        }
        public DbSet<User> User { get; set; }
        public DbSet<Kullanicilar> Kullanicilar{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new KullanicilarMap());
        }
    }
}
