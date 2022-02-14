using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        public String KategoriAd { get; set; }
        
        public bool Durum { get; set; }
        public ICollection<Urun> uruns { get; set; }



    }
}