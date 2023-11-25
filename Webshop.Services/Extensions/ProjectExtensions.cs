using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Model;
using Webshop.Services.Model.Results;

namespace Webshop.Services.Extensions
{
    public static class ProjectExtensions
    {
        public static IQueryable<BlurayResult> ProjectToResult(this IQueryable<Bluray> query)
        {
            return query.Select(b => new BlurayResult
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                ImageURL = b.ImageURL,
                TrailerURL = b.TrailerURL,
                Price = b.Price
            });
        }
    }
}
