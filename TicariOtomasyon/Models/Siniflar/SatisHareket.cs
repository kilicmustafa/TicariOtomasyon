﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {

        [Key]
        public int SatisId { get; set; }



        public DateTime Tarih { get; set; }

        public int Adet { get; set; }

        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }


        public bool Durum { get; set; }
        public int UrunID { get; set; }
        public virtual Urun Urun { get; set; }

        public int CariId { get; set; }
        public virtual Cari Cari { get; set; }

        public int PersonelId { get; set; }
        public virtual Personel Personel { get; set; }  
        


    }
}