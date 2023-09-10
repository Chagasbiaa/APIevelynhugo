using NetCoreAPIEvelyn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIEvelyn.Data.Repositories
{
    public interface IAutoraRepository
    {
        Task<IEnumerable<autora>> GetAllAutora();
        Task<autora> GetAutoraDetails(int id);
        Task<bool> InsertAutora(autora autora);
        Task<bool> UpdateAutora(autora autora);
        Task<bool> DeleteAutora(autora autora);
    }
}
