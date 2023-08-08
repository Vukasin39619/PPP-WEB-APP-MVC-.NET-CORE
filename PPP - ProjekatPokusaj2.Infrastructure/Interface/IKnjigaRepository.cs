using PPP___ProjekatPokusaj2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Infrastructure.Interface
{
    public interface IKnjigaRepository
    {
        Task<IEnumerable<KnjigaBO>> GetAll();
        Task<KnjigaBO> GetById(int id);
        Task Add(KnjigaBO model);
        Task Update(KnjigaBO model);
        Task Delete(int id);
    }
}
