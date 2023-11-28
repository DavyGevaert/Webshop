using Microsoft.EntityFrameworkCore;
using Webshop.Model;
using Webshop.Repository;
using Webshop.Services.Abstractions;

namespace Webshop.Services
{
	public class CartItemService : ICartItemService
	{
		private readonly WebshopDbContext _dbContext;

		public CartItemService(WebshopDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<CartItem> GetAsync(int id)
		{
			var cartItem = await _dbContext.CartItems.FirstOrDefaultAsync(b => b.Id == id);

			return cartItem;
		}

		public async Task<IList<CartItem>> FindAsync()
		{
			var cartItems = await _dbContext.CartItems.ToListAsync();

			return cartItems;
		}

		public async Task<CartItem> Create(CartItem cartItem)
		{
			var dbCartItem = new CartItem
			{
				Id = cartItem.Id,
				Title = cartItem.Title,
				Description = cartItem.Description,
				ImageURL = cartItem.ImageURL,
				TrailerURL = cartItem.TrailerURL,
				Price = cartItem.Price,
				CurrentInStock = cartItem.CurrentInStock,
				Quantity = cartItem.Quantity
			};

			_dbContext.CartItems.Add(dbCartItem);
			_dbContext.SaveChanges();

			return await GetAsync(cartItem.Id);
		}

		public async Task<CartItem> Update(int id, CartItem cartItem)
		{
			var dbCartItem = _dbContext.CartItems
							.SingleOrDefault(i => i.Id == id);

			if (dbCartItem is null)
			{
				return null;
			}

			dbCartItem.Id = cartItem.Id;
			dbCartItem.Title = cartItem.Title;
			dbCartItem.Description = cartItem.Description;
			dbCartItem.ImageURL = cartItem.ImageURL;
			dbCartItem.TrailerURL = cartItem.TrailerURL;
			dbCartItem.Price = cartItem.Price;
			dbCartItem.CurrentInStock = cartItem.CurrentInStock;


			_dbContext.SaveChanges();

			return await GetAsync(dbCartItem.Id);
		}

		public bool Delete(int id)
		{
			var dbCartItem = _dbContext.CartItems
							.SingleOrDefault(i => i.Id == id);

			if (dbCartItem is null)
			{
				return false;
			}

			_dbContext.CartItems.Remove(dbCartItem);
			_dbContext.SaveChanges();

			return true;
		}
	}
}
