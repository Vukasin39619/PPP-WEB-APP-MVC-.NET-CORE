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
    public class KnjigaRepository : IKnjigaRepository
    {
        private readonly MyAppDbContext _context;

        public KnjigaRepository(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task Add(KnjigaBO model)
        {
            await _context.Knjiga.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var voznja = await _context.Knjiga.FindAsync(id);
            if (voznja != null)
            {

                _context.Knjiga.Remove(voznja);

                await Save();

            }
        }
        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<KnjigaBO>> GetAll()
        {
            var voznja = await _context.Knjiga.ToListAsync();
            return voznja;
        }

        public async Task<KnjigaBO> GetById(int id)
        {
            return await _context.Knjiga.FindAsync(id);
        }

        public async Task Update(KnjigaBO model)
        {
            var voznja = await _context.Knjiga.FindAsync(model.Id_Knjige);
            if (voznja != null)
            {
                //voznja.VremeVoznjeMin = model.VremeVoznjeMin; vrv sta se update
                _context.Update(voznja);
                await _context.SaveChangesAsync();
            }
        }
    }
}
