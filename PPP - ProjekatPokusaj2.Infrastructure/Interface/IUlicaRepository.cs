using PPP___ProjekatPokusaj2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Infrastructure.Interface
{
    public interface IUlicaRepository
    {
        Task<IEnumerable<UlicaBO>> GetAll();
        Task<UlicaBO> GetById(int id);
        Task Add(UlicaBO model);
        Task Update(UlicaBO model);
        Task Delete(int id);
    }
}
