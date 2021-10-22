using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieUczelnia.Models
{
    public abstract class Uzytkownik
    {
        [Key]
        public long UzytkownikID { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [DataType(DataType.Date),Required]
        public DateTime DataUrodzenia { get; set; }
    }
}