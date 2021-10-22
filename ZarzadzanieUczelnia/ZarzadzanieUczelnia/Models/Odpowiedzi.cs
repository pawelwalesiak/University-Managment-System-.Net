using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZarzadzanieUczelnia.Models
{
    public class Odpowiedzi
    {
        public long OdpowiedziID { get; set; }
        [Required]
        public string Tresc { get; set; }
        public virtual ICollection<Odpowiedz> Odpowiedz { get; set; }
    }
}