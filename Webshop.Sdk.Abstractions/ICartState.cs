using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Model;

namespace Webshop.Sdk.Abstractions
{
	public interface ICartState
	{
		Task AddItemToBasketAsync(Item item);

		IList<Item> GetBasket();

		Task UpdateStock();
	}
}
