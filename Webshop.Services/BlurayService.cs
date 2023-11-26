using Microsoft.EntityFrameworkCore;
using Webshop.Model;
using Webshop.Repository;
using Webshop.Services.Abstractions;
using Webshop.Services.Extensions;

namespace Webshop.Services
{
    public class BlurayService : IBlurayService
    {
        private readonly WebshopDbContext _dbContext;

        public BlurayService(WebshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Bluray> GetAsync(int id)
        {
            var bluray = await _dbContext.Blurays.FirstOrDefaultAsync(b => b.Id == id);

            return bluray;
        }

        public async Task<IList<Bluray>> FindAsync()
        {
            var blurays = await _dbContext.Blurays.ToListAsync();

            return blurays;
        }

        public async Task<Bluray> Create(Bluray bluray)
        {
            var dbBluray = new Bluray
            {
                Id = bluray.Id,
                Title = bluray.Title,
                Description = bluray.Description,
                ImageURL = bluray.ImageURL,
                TrailerURL = bluray.TrailerURL,
                Price = bluray.Price
            };

            _dbContext.Blurays.Add(dbBluray);
            _dbContext.SaveChanges();

            return await GetAsync(bluray.Id);
        }

        public async Task<Bluray> Update(int id, Bluray bluray)
        {
            var dbBluray = _dbContext.Blurays
                            .SingleOrDefault(i => i.Id == id);

            if (dbBluray is null)
            {
                return null;
            }

            dbBluray.Id = bluray.Id;
            dbBluray.Title = bluray.Title;
            dbBluray.Description = bluray.Description;
            dbBluray.ImageURL = bluray.ImageURL;
            dbBluray.TrailerURL = bluray.TrailerURL;
            dbBluray.Price = bluray.Price;

            _dbContext.SaveChanges();

            return await GetAsync(dbBluray.Id);
        }

        public bool Delete(int id)
        {
            var dbBluray = _dbContext.Blurays
                            .SingleOrDefault(i => i.Id == id);

            if (dbBluray is null)
            {
                return false;
            }

            _dbContext.Blurays.Remove(dbBluray);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
