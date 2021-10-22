using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZarzadzanieUczelnia.Models
{
    public class Zajecia
    {
        public long ZajeciaID { get; set; }
       
        [DataType(DataType.Date),Required]
        public DateTime Data { get; set; }

        public long NauczycielID { get; set; }
        public long PrzedmiotID { get; set; }
        [ForeignKey("NauczycielID")]
        public virtual Nauczyciel Nauczyciel { get; set; }
        [ForeignKey("PrzedmiotID")]
        public virtual Przedmiot Przedmiot { get; set; }
        public virtual ICollection<UczenSzkoly> Uczniowie { get; set; }
        

    }
}