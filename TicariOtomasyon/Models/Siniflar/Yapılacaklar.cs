using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Yapılacaklar
    {
        [Key]
        public int YapilacakId { get; set; }
        public String Aciklama { get; set; }

        public bool Durum { get; set; } 

    }
}