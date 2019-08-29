using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace webMotors_backEnd.Models
{
    public class contexto: DbContext
    {
        //public DbSet<pessoa> Pessoas { get; set; }
        public DbSet<anuncio> Anuncio { get; set; }
    }
}