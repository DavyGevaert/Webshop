using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Services.Model.Core;
using Webshop.Services.Model.Results;

namespace Webshop.Sdk.Abstractions
{
    public interface IBlurayApi
    {
        Task<ServiceResult<BlurayResult>> GetAsync(int id);

        Task<ServiceResult<IList<BlurayResult>>> FindAsync();

        Task CreateItemAsync(BlurayResult blurayResult);

        Task SaveItemAsync(BlurayResult blurayResult);

        Task DeleteItemAsync(int id);
    }
}
