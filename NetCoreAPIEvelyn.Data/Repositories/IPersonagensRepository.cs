using NetCoreAPIEvelyn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIEvelyn.Data.Repositories
{
    public interface IPersonagensRepository
    {
        Task<IEnumerable<personagens>> GetAllPersonagens();
        Task<personagens> GetPersonagensDetails(int id);
        Task<bool> InsertPersonagens(personagens personagens);
        Task<bool> UpdatePersonagens(personagens personagens);
        Task<bool> DeletePersonagens(personagens personagens);
    }
}
