using Microsoft.EntityFrameworkCore;
using Webshop.Model;
using Webshop.Repository;
using Webshop.Services.Abstractions;
using Webshop.Services.Extensions;

namespace Webshop.Services
{
    public class ItemService : IItemService
    {
        private readonly WebshopDbContext _dbContext;

        public ItemService(WebshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Item> GetAsync(int id)
        {
            var item = await _dbContext.Items.FirstOrDefaultAsync(b => b.Id == id);

            return item;
        }

        public async Task<IList<Item>> FindAsync()
        {
            var items = await _dbContext.Items.ToListAsync();

            return items;
        }

        public async Task<Item> Create(Item item)
        {
            var dbItem = new Item
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                ImageURL = item.ImageURL,
                TrailerURL = item.TrailerURL,
                Price = item.Price,
                CurrentInStock = item.CurrentInStock
            };

            _dbContext.Items.Add(dbItem);
            _dbContext.SaveChanges();

            return await GetAsync(item.Id);
        }

        public async Task<Item> Update(int id, Item item)
        {
            var dbItem = _dbContext.Items
							.SingleOrDefault(i => i.Id == id);

            if (dbItem is null)
            {
                return null;
            }

            dbItem.Id = item.Id;
            dbItem.Title = item.Title;
            dbItem.Description = item.Description;
            dbItem.ImageURL = item.ImageURL;
            dbItem.TrailerURL = item.TrailerURL;
            dbItem.Price = item.Price;
            dbItem.CurrentInStock = item.CurrentInStock;


			_dbContext.SaveChanges();

            return await GetAsync(dbItem.Id);
        }

        public bool Delete(int id)
        {
            var dbItem = _dbContext.Items
							.SingleOrDefault(i => i.Id == id);

            if (dbItem is null)
            {
                return false;
            }

            _dbContext.Items.Remove(dbItem);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
