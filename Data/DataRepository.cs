using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using CyberpunkAPI.Data.Models;

namespace CyberpunkAPI.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly string _connectionString;

        public DataRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];  //The configuration parameter gives access to items within appsettings.json. The key to use when accessing the configuration object is the path to the item you want with colons to navigate feilds in json
        }
        public IEnumerable<GetManyPlayers> GetPlayerBySearch(string search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetManyPlayers> GetPlayers()
        {
            using (var connection = new SqlConnection(_connectionString))  //A using block automatically disposes of the object defined in the block when the program exits the scope of the block
            {
                connection.Open();
                return connection.Query<GetManyPlayers>(@"EXEC dbo.GetAllPlayers");
            }
        }

        public bool PlayerExists(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
