using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Model;

namespace Webshop.Services.Abstractions
{
    public interface IBlurayService
    {
        Task<Bluray> GetAsync(int id);
        Task<IList<Bluray>> FindAsync();
        Task<Bluray> Create(Bluray item);
        Task<Bluray> Update(int id, Bluray item);
        bool Delete(int id);
    }
}
