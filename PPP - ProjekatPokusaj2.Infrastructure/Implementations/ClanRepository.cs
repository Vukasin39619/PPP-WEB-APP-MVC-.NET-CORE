using Microsoft.EntityFrameworkCore;
using PPP___ProjekatPokusaj2.Core;
using PPP___ProjekatPokusaj2.Infrastructure.Interface;

namespace PPP___ProjekatPokusaj2.Infrastructure.Implementations
{
    public class ClanRepository : IClanRepository
    {
        private readonly MyAppDbContext _context;

        public ClanRepository(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<ClanBO> GetByUsernameAndPassword(string username, string password)
        {
            return await _context.Clan.FirstOrDefaultAsync(n => n.Username == username && n.Password == password);
        }

        public async Task Add(ClanBO model)
        {
            await _context.Clan.AddAsync(model);
            await _context.SaveChangesAsync();
        }
       

        public async Task Delete(int id)
        {
            var clan = await _context.Clan.FindAsync(id);
            if (clan != null)
            {

                _context.Clan.Remove(clan);
                await Save();

            }
        }
        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ClanBO>> GetAll()
        {
            var clan = await _context.Clan.ToListAsync();
            return clan;
        }
      

        public async Task<ClanBO> GetById(int id)
        {
            return await _context.Clan.FindAsync(id);

        }

        public async Task Update(ClanBO model)
        {
            var clan = await _context.Clan.FindAsync(model.Id_Clana);
            if (clan != null)
            {
                clan.Ime = model.Ime;
                _context.Update(clan);
                await _context.SaveChangesAsync();
            }
        }
    }
}
