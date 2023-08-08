using PPP___ProjekatPokusaj2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Infrastructure.Interface
{
    public interface IRacunRepository
    {
        Task<IEnumerable<RacunBO>> GetAll();
        Task<RacunBO> GetById(int id);
        Task Add(RacunBO model);
        Task Update(RacunBO model);
        Task Delete(int id);
    }
}
