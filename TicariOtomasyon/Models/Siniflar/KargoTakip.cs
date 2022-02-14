using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {


        [Key]
        public int KargoTakipId { get; set; }

        [Column(TypeName="Varchar")]
        [StringLength(15)]
        public string TakipKodu { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(50)]
        public string Aciklama { get; set; }
        public DateTime TarihZaman { get; set; }    
    
    }
}