using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeraMathiasExamenP3.Models;

namespace VeraMathiasExamenP3.Interfaces
{
    public interface IMVeraPeliculaAPI
    {
        public Task<List<MVeraPeliculaAPI>> Obtener();
    }
}
