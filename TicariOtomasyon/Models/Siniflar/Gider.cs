using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GiderId { get; set; }

        public string Aciklama { get; set; }

        public DateTime Tarih { get; set; }

        public decimal Turar { get; set; }



    }
}