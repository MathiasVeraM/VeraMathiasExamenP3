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
        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<List<MVeraPeliculaAPI>> Obtener()
        {
            try
            {
                var respuesta = await _httpClient.GetAsync(_urlAPI);
                if (!respuesta.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error en la solicitud: {respuesta.StatusCode}");
                }

                var cuerpoRespuesta = await respuesta.Content.ReadAsStringAsync();

                var nodo = JsonNode.Parse(cuerpoRespuesta);
                var resultados = nodo["resultados"];

                var peliculas = JsonSerializer.Deserialize<List<MVeraPeliculaAPI>>(resultados.ToString());

                return peliculas ?? new List<MVeraPeliculaAPI>();
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
