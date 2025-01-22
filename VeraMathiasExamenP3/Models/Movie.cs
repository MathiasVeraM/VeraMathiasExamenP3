using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeraMathiasExamenP3.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string[] Genre { get; set; }
        public int Year { get; set; }
        public string[] Actors { get; set; }
        public string Awards { get; set; }
        public string Website { get; set; }
    }
}
