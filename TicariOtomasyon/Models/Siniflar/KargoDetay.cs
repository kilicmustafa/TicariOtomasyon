using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class KargoDetay
    {

        [Key]
        public int KargoDetayId { get; set; }
        
        [Column(TypeName ="Varchar")]
        [StringLength(15)]
        public string TakipKodu { get; set; }


        [Column(TypeName="Varchar")]
        [StringLength(300)]
        public string Aciklama { get; set; }
        
  
        public int Alici { get; set; }

        public int Personel { get; set; }
        public DateTime Tarih { get; set; }
    }
}