﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Services.Model.Core;
using Webshop.Services.Model.Results;

namespace Webshop.Services.Abstractions
{
    public interface IBlurayService
    {
        Task<ServiceResult<BlurayResult>> GetAsync(int id);
        Task<ServiceResult<IList<BlurayResult>>> FindAsync();
        Task<ServiceResult<BlurayResult>> Create(BlurayResult item);
        Task<ServiceResult<BlurayResult>> Update(int id, BlurayResult item);
        bool Delete(int id);
    }
}
