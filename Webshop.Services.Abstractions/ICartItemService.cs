using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Model;

namespace Webshop.Services.Abstractions
{
	public interface ICartItemService
	{
		Task<CartItem> GetAsync(int id);
		Task<IList<CartItem>> FindAsync();
		Task<CartItem> Create(CartItem cartItem);
		Task<CartItem> Update(int id, CartItem cartItem);
		bool Delete(int id);
	}
}
