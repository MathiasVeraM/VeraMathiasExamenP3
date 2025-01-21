using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeraMathiasExamenP3.Models
{
    public class MVeraPeliculaAPI
    {
        public int id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string[] genre { get; set; }
        public float rating { get; set; }
        public string director { get; set; }
        public string[] actors { get; set; }
        public string plot { get; set; }
        public string poster { get; set; }
        public string trailer { get; set; }
        public int runtime { get; set; }
        public string awards { get; set; }
        public string country { get; set; }
        public string language { get; set; }
        public string boxOffice { get; set; }
        public string production { get; set; }
        public string website { get; set; }
    }
}
