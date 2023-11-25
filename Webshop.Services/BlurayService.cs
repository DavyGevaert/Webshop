using Microsoft.EntityFrameworkCore;
using Webshop.Model;
using Webshop.Repository;
using Webshop.Services.Abstractions;
using Webshop.Services.Extensions;
using Webshop.Services.Model.Results;

namespace Webshop.Services
{
    public class BlurayService : IBlurayService
    {
        private readonly WebshopDbContext _dbContext;

        public BlurayService(WebshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BlurayResult Get(int id)
        {
            var bluray = _dbContext.Blurays
                .Select(b => new BlurayResult
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    ImageURL = b.ImageURL,
                    TrailerURL = b.TrailerURL,
                    Price = b.Price
                })
                .SingleOrDefault(p => p.Id == id);

            return bluray;
        }

        public async Task<BlurayResult> GetAsync(int id)
        {
            var bluray = await _dbContext.Blurays
                .ProjectToResult()
                .SingleOrDefaultAsync(i => i.Id == id);

            return bluray;
        }

        public async Task<IList<BlurayResult>> FindAsync()
        {
            var blurays = await _dbContext.Blurays
                .ProjectToResult()
                .ToListAsync();

            return blurays;
        }

        public BlurayResult Create(BlurayResult bluray)
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

            return Get(bluray.Id);
        }

        public BlurayResult Update(int id, BlurayResult bluray)
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

            return Get(dbBluray.Id);
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
