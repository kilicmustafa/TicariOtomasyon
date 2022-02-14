using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class TabloBirlestir
    {
        public IEnumerable<Urun> UrunTable { get; set; }

        public IEnumerable<Detay> DetayTable { get; set; }

       
    }
}