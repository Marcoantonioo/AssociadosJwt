using System.Collections.Generic;
using System.Threading.Tasks;
using AppAssociados.Domain;

namespace AppAssociados.Repositories.Interfaces
{
    public interface IEstadoCivilRepository : IRepositoryBase<EstadoCivil>
    {
         Task<List<EstadoCivil>> GetAllAsync();
         Task<EstadoCivil> GetByIdAsync(int id);
    }
}