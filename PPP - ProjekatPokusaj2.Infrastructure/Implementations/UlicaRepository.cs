using Microsoft.EntityFrameworkCore;
using PPP___ProjekatPokusaj2.Core;
using PPP___ProjekatPokusaj2.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Infrastructure.Implementations
{
    

    public class UlicaRepository : IUlicaRepository
    {
        private readonly MyAppDbContext _context;

        public UlicaRepository(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task Add(UlicaBO model)
        {
            await _context.Ulica.AddAsync(model);
            await _context.SaveChangesAsync();
        }

       

        public async Task Delete(int id)
        {
            var ulica = await _context.Ulica.FindAsync(id);
            if(ulica != null)
            {

                _context.Ulica.Remove(ulica);

                await Save();

            }
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UlicaBO>> GetAll()
        {
            var ulice = await _context.Ulica.ToListAsync();
            return ulice;
        }

        public async Task<UlicaBO> GetById(int id)
        {
            return await _context.Ulica.FindAsync(id);
        }

        public async Task Update(UlicaBO model)
        {
            var ulica = await _context.Ulica.FindAsync(model.Id_ulice);
            if(ulica != null)
            {
                ulica.Nazivulice = model.Nazivulice;
                _context.Update(ulica);
               await _context.SaveChangesAsync();
            }
        }
       
    }
}
