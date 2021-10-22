using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZarzadzanieUczelnia.Models
{
    public class Przedmiot
    {
        public long PrzedmiotID { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public virtual ICollection<Zajecia> Zajecia { get; set; }
    }
}