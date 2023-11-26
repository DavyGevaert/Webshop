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
        Bluray Get(int id);
        IList<Bluray> Find();
        Bluray Create(Bluray item);
        Bluray Update(int id, Bluray item);
        bool Delete(int id);
    }
}
