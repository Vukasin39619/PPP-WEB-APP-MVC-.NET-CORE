using PPP___ProjekatPokusaj2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Infrastructure.Interface
{
    public interface IKorisnickiNalogRepository
    {
        Task<IEnumerable<KorisnickiNalogBO>> GetAll();
        Task<KorisnickiNalogBO> GetById(int id);
        Task Add(KorisnickiNalogBO model);
        Task Update(KorisnickiNalogBO model);
        Task Delete(int id);
        public Task<KorisnickiNalogBO> GetByUsernameAndPassword(string username, string password);

    }
}
