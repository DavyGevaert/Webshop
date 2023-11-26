using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Model;

namespace Webshop.Sdk.Abstractions
{
    public interface IBlurayApi
    {
        Task<Bluray> GetAsync(int id);

        Task<IList<Bluray>> FindAsync();

        Task CreateItemAsync(Bluray blurayResult);

        Task SaveItemAsync(Bluray blurayResult);

        Task DeleteItemAsync(int id);
    }
}
