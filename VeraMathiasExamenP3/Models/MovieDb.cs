using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeraMathiasExamenP3.Models
{
    public class MovieDb
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string MainActor { get; set; }
        public string Awards { get; set; }
        public string Website { get; set; }
        public string MVera { get; set; }
    }
}
