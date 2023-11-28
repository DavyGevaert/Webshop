using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Model;

namespace Webshop.Services.Abstractions
{
    public interface IItemService
    {
        Task<Item> GetAsync(int id);
        Task<IList<Item>> FindAsync();
        Task<Item> Create(Item item);
        Task<Item> Update(int id, Item item);
        bool Delete(int id);
    }
}
