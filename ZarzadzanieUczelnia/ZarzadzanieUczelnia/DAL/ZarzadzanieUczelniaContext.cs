using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZarzadzanieUczelnia.DAL
{
    public class ZarzadzanieUczelniaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ZarzadzanieUczelniaContext() : base("name=ZarzadzanieUczelnia")
        {
        }

        public System.Data.Entity.DbSet<ZarzadzanieUczelnia.Models.UczenSzkoly> UczenSzkolies { get; set; }

        public System.Data.Entity.DbSet<ZarzadzanieUczelnia.Models.Grupa> Grupas { get; set; }

        public System.Data.Entity.DbSet<ZarzadzanieUczelnia.Models.Ocena> Ocenas { get; set; }

        public System.Data.Entity.DbSet<ZarzadzanieUczelnia.Models.Przedmiot> Przedmiots { get; set; }

        public System.Data.Entity.DbSet<ZarzadzanieUczelnia.Models.Nauczyciel> Nauczyciels { get; set; }
    }
}
