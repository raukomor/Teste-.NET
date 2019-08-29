using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webMotors_backEnd.Models
{
    public class MarcasViewModel
    {
        public List<string> ListaMarcas { get; set; }

        public List<string> ListaModelos { get; set; }

        public List<string> ListaVersoes { get; set; }



        public MarcasViewModel()
        {
            ListaMarcas = new List<string>();
            ListaModelos = new List<string>();
            ListaVersoes = new List<string>();
        }

    }
}