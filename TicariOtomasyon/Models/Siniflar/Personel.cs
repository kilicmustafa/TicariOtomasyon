using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        [Display(Name = "Personel Ad Soyad")]
        public string PersonelAdSoyad { get; set; }


        [Display(Name = "Personel Görseli")]
        public string PersonelGörsel { get; set; }
        public int DepartmanId { get; set; }

        public string PersonelKullaniciAdi { get; set; }
        public string PersonelSifre { get; set; }
        public bool Durum { get; set; }
        public virtual Departman departman { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}