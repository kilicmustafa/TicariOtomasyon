using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {

        public int FaturaKalemId { get; set; }

        public string Aciklama { get; set; }

        public int Miktar { get; set; }

        public decimal BirimFiyat { get; set; }

        public decimal Tutar { get; set; }


        public int FaturaId { get; set; }
        public virtual Fatura Fatura { get; set; }
    }
}