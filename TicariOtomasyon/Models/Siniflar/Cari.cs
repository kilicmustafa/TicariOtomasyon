using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage ="En fazla 30 karakter girebilirsiniz!")]
        
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string  CariSehir { get; set; }
        public string  CariMail { get; set; }

        public string Sifre { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }  

    }
}