using EnvanterMVC.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvanterMVC.Entities.Mapping
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("User");
            this.HasKey(x=> x.Id); // Primary key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Oto Identity
            this.Property(x=> x.Username).IsRequired();
            this.Property(x=> x.Password).IsRequired();
            this.Property(x => x.Username).HasMaxLength(30);
            this.Property(x=> x.Password).HasMaxLength(30);
            this.Property(x=> x.Tur).IsRequired();
            this.Property(x=> x.TeslimEden).IsRequired();


        }
    }
}
