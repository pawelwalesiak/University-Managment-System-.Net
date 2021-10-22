using System.ComponentModel.DataAnnotations;

namespace ZarzadzanieUczelnia.Models
{
    public class Odpowiedz
    {
        public long OdpowiedzID { get; set; }
        [Display(Name ="Odpowiedź")]
        public string Odp { get; set; }

        public virtual Odpowiedzi Odpowiedzi { get; set; }
    }
}