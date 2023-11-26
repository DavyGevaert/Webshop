using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Model;

namespace Webshop.Services.Extensions
{
    public static class ProjectExtensions
    {
        public static IQueryable<Bluray> ProjectToResult(this IQueryable<Bluray> query)
        {
            return query.Select(b => new Bluray
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
