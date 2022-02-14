using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Departman
    {

        [Key]

        public int DepartmanId { get; set; }
        public string DepartmanAd { get; set; }

        public bool Durum { get; set; }

        public ICollection<Personel> personels { get; set; }


    }
}