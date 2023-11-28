using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Model;

namespace Webshop.Sdk.Abstractions
{
    public interface IItemApi
    {
        Task<Item> GetAsync(int id);

        Task<IList<Item>> FindAsync();

        Task CreateItemAsync(Item item);

        Task SaveItemAsync(Item item);

        Task DeleteItemAsync(int id);
    }
}
