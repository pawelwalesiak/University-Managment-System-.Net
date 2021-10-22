using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarzadzanieUczelnia.Models
{
    public class Ocena
    {
        public long OcenaID { get; set; }
        [Display(Name ="Ocena"),Required]
        public short OtrzymanaOcena { get; set; }
        [DataType(DataType.Date),Required]
        public DateTime Data { get; set; }
        [DataType(DataType.MultilineText)]
        public string Komentarz { get; set; }
        public long UczenID { get; set; }
        public long PrzedmiotID { get; set; }
        [ForeignKey("UczenID")]
        public virtual UczenSzkoly Uczen { get; set; }
        [ForeignKey("PrzedmiotID")]
        public virtual Przedmiot Przedmiot { get; set; }
    }
}