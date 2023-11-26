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

        public Bluray Get(int id)
        {
            var bluray = _dbContext.Blurays                
                .SingleOrDefault(p => p.Id == id);

            return bluray;
        }

        public IList<Bluray> Find()
        {
            var blurays = _dbContext.Blurays
                .ToList();

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
