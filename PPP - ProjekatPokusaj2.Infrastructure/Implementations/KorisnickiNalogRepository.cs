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
    public class KorisnickiNalogRepository : IKorisnickiNalogRepository
    {
        private readonly MyAppDbContext _context;

        public KorisnickiNalogRepository(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<KorisnickiNalogBO> GetByUsernameAndPassword(string username, string password)
        {
            return await _context.KorisnickiNalog.FirstOrDefaultAsync(n => n.Username == username && n.Sifra == password);
        }

        public async Task Add(KorisnickiNalogBO model)
        {
            await _context.KorisnickiNalog.AddAsync(model);
            await _context.SaveChangesAsync();
        }
       

        public async Task Delete(int id)
        {
            var nalog = await _context.KorisnickiNalog.FindAsync(id);
            if (nalog != null)
            {

                _context.KorisnickiNalog.Remove(nalog);
                await Save();

            }
        }
        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<KorisnickiNalogBO>> GetAll()
        {
            var nalog = await _context.KorisnickiNalog.ToListAsync();
            return nalog;
        }
      

        public async Task<KorisnickiNalogBO> GetById(int id)
        {
            return await _context.KorisnickiNalog.FindAsync(id);

        }

        public async Task Update(KorisnickiNalogBO model)
        {
            var nalog = await _context.KorisnickiNalog.FindAsync(model.Id);
            if (nalog != null)
            {
                nalog.Ime = model.Ime;
                _context.Update(nalog);
                await _context.SaveChangesAsync();
            }
        }
    }
}
