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
    public class VoznjaRepository : IVoznjaRepository
    {
        private readonly MyAppDbContext _context;

        public VoznjaRepository(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task Add(VoznjaBO model)
        {
            await _context.Voznja.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var voznja = await _context.Voznja.FindAsync(id);
            if (voznja != null)
            {

                _context.Voznja.Remove(voznja);

                await Save();

            }
        }
        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VoznjaBO>> GetAll()
        {
            var voznja = await _context.Voznja.ToListAsync();
            return voznja;
        }

        public async Task<VoznjaBO> GetById(int id)
        {
            return await _context.Voznja.FindAsync(id);
        }

        public async Task Update(VoznjaBO model)
        {
            var voznja = await _context.Voznja.FindAsync(model.Id_voznje);
            if (voznja != null)
            {
                voznja.VremeVoznjeMin = model.VremeVoznjeMin;
                _context.Update(voznja);
                await _context.SaveChangesAsync();
            }
        }
    }
}
