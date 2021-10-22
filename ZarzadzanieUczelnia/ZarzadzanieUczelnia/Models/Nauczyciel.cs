using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZarzadzanieUczelnia.Models
{
    public class Nauczyciel : Uzytkownik
    {
      

        public virtual ICollection<Ogloszenie> Ogloszenia { get; set; }

    }
}