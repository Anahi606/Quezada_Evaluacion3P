using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Quezada_Evaluacion3P.Models;

namespace Quezada_Evaluacion3P.Services
{
    public class AQSevicioDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public AQSevicioDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AQGame>().Wait();
        }

        public Task<List<AQGame>> GetGamesAsync()
        {
            return _database.Table<AQGame>().ToListAsync();
        }

        public Task<int> SaveGameAsync(AQGame game)
        {
            return _database.InsertAsync(game);
        }
    }
}



