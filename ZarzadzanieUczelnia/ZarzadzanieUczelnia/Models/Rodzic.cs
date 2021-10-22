using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZarzadzanieUczelnia.Models
{
    public class Rodzic : Uzytkownik
    {
        public virtual ICollection<UczenSzkoly> Dziecko { get; set; }
    }
}