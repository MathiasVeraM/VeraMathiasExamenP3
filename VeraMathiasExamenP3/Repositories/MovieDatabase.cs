using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeraMathiasExamenP3.Models;

namespace VeraMathiasExamenP3.Repositories
{
    public class MovieDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public MovieDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MovieDb>().Wait();
        }

        public async Task SaveMovieAsync(MovieDb movie)
        {
            await _database.InsertAsync(movie);
        }

        public async Task<List<MovieDb>> GetMoviesAsync()
        {
            return await _database.Table<MovieDb>().ToListAsync();
        }
    }
}
