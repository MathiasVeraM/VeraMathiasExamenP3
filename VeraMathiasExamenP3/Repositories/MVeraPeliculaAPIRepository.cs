using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using VeraMathiasExamenP3.Interfaces;
using VeraMathiasExamenP3.Models;

namespace VeraMathiasExamenP3.Repositories
{
    public class MVeraPeliculaAPIRepository : IMVeraPeliculaAPI
    {
        private string _urlAPI = "https://freetestapi.com/api/v1/movies?";
        public async Task<List<MVeraPeliculaAPI>> Obtener()
        {
            var cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(_urlAPI);
            var cuerpoRespuesta = await respuesta.Content.ReadAsStringAsync();
            JsonNode nodes = JsonNode.Parse(cuerpoRespuesta);
            JsonNode results = nodes["results"];

            var peliculadata = JsonSerializer.Deserialize<List<MVeraPeliculaAPI>>(results.ToString());
            return peliculadata;
        }
    }
}
