using PPP___ProjekatPokusaj2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Infrastructure.Interface
{
    public interface IVoznjaRepository
    {
        Task<IEnumerable<VoznjaBO>> GetAll();
        Task<VoznjaBO> GetById(int id);
        Task Add(VoznjaBO model);
        Task Update(VoznjaBO model);
        Task Delete(int id);    
    }
}
