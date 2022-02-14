using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class TabloBirlestirForPopup
    {

        public IEnumerable<FaturaKalem> FaturaKalemTable {get; set;}
        public IEnumerable<Fatura> FaturaTable {get; set;}
    }
}