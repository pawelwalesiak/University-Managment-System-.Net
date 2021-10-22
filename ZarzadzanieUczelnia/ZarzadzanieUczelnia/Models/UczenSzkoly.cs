using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZarzadzanieUczelnia.Models
{
    public class UczenSzkoly : Uzytkownik
    {
        [Required]
        public string Indeks { get; set; }
        public long GrupaID { get; set; } 
        [ForeignKey("GrupaID")]
        public virtual Grupa Grupa { get; set; }
        public virtual ICollection<Ocena> Oceny { get; set; }

    }
}