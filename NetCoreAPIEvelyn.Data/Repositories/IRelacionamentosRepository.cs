using NetCoreAPIEvelyn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIEvelyn.Data.Repositories
{
    public interface IRelacionamentosRepository
    {
        Task<IEnumerable<relacionamentos>> GetRelacionamentos();
        Task<relacionamentos> GetRelacionamentosDetails(int id);

        Task<bool> InsertRelacionamentos(relacionamentos relacionamentos);
        Task<bool> UpdateRelacionamentos(relacionamentos relacionamentos);
        Task<bool> DeleteRelacionamentos(relacionamentos relacionamentos);
    }
}
