using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Fatura
    {
        [Key]
        public int FaturaId { get; set; }
        
        public string FaturaSeriNo { get; set; }

        public string FaturaSıraNo { get; set; }

        public DateTime Tarih { get; set; }



        public string VergiDairesi { get; set; }
    
        public string TeslimEden { get; set; }

        public string TeslimAlan { get; set; }

        public bool Durum { get; set; }

 

        public decimal Toplam { get; set; }
   

        public ICollection<FaturaKalem> FaturaKalems { get; set; }



    }
}