using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberpunkAPI.Data.Models;

namespace CyberpunkAPI.Data
{
    public interface IDataRepository
    {
        IEnumerable<GetManyPlayers> GetPlayers();

        IEnumerable<GetManyPlayers>
            GetPlayerBySearch(string search);

        bool PlayerExists(int ID);
    }
}
