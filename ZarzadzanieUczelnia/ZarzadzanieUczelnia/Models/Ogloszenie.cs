using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZarzadzanieUczelnia.Models
{
    public class Ogloszenie
    {
        public long OgloszenieID { get; set; }
        [Required]
        public string Temat { get; set; }
        [DataType(DataType.MultilineText),Display(Name ="Treść")]
        public string Tresc { get; set; }
        public DoKogo SkierowaneDo { get; set; }

        public virtual ICollection<Pytanie> Pytania { get; set; }
        public virtual ICollection<Odpowiedzi> Odpowiedzi { get; set; }

    }

    public enum DoKogo
    {
        Rodzice,
        Uczniowie,
        Wszyscy
    }
}