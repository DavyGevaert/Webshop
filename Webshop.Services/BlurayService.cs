using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Model;
using Webshop.Repository;

namespace Webshop.Services
{
    public class BlurayService
    {
        private readonly WebshopDbContext _dbContext;

        public BlurayService(WebshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Bluray Get(int id)
        {
            var bluray = _dbContext.Blurays
                .Select(b => new Bluray
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

        public async Task<Bluray> GetAsync(int id)
        {
            var bluray = await _dbContext.Blurays
                .SingleOrDefaultAsync(i => i.Id == id);

            return bluray;
        }

        public async Task<IList<Bluray>> FindAsync()
        {
            var blurays = await _dbContext.Blurays
                .ToListAsync();

            return blurays;
        }

        public Bluray Create(Bluray bluray)
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

        public Bluray Update(int id, Bluray bluray)
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
