using PPP___ProjekatPokusaj2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Infrastructure.Interface
{
    public interface IClanRepository
    {
        Task<IEnumerable<ClanBO>> GetAll();
        Task<ClanBO> GetById(int id);
        Task Add(ClanBO model);
        Task Update(ClanBO model);
        Task Delete(int id);
        public Task<ClanBO> GetByUsernameAndPassword(string username, string password);

    }
}
