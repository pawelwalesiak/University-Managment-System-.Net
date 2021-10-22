using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarzadzanieUczelnia.Models
{
    public class Pytanie
    {
        public long PytanieID { get; set; }
        [Required]
        public string Tresc { get; set; }

        public long OgloszenieID { get; set; }
        [ForeignKey("OgloszenieID")]
        public virtual Ogloszenie Ogloszenie { get; set; }
        public virtual ICollection<Odpowiedzi> Odpowiedzi { get; set; }
    }


}