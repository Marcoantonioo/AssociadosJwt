using System.Collections.Generic;
using System.Threading.Tasks;
using AppAssociados.Domain;

namespace AppAssociados.Repositories.Interfaces
{
    public interface IParentescoRepository : IRepositoryBase<Parentesco>
    {
         Task<List<Parentesco>> GetAllAsync();
         Task<Parentesco> GetByIdAsync(int id);
    }
}