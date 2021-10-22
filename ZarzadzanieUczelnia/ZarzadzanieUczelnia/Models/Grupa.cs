using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZarzadzanieUczelnia.Models;

namespace ZarzadzanieUczelnia.Models
{
    public class Grupa
    {
        public long GrupaID { get; set; }
        [Range(1,6),Required]
        public short Semestr { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public long NauczycielID { get; set; }
        [ForeignKey("NauczycielID")]
        public virtual Nauczyciel Nauczyciel { get; set; }
        public virtual ICollection<UczenSzkoly> Uczniowie { get; set; }
       

    }
}