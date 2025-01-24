using EnvanterMVC.Entities.Validations;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvanterMVC.Entities.Model
{
    [Validator(typeof(UserValidator))]
    public class User
    {
        public int Id { get; set; }
        public string Tur { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string SeriNo { get; set; }
        public DateTime Tarih { get; set; }
        public string TeslimEden { get; set; }
        public string TeslimAlan { get; set; }
        public string TeslimEdilenDepartman { get; set; }
        public string UrunDurum { get; set; }
        public int? IMEI { get; set; } // ? İşareti ile nullable yapıldı.
        public string Aciklama { get; set; }
    }
}
