using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Services.Model.Results
{
    public class BlurayResult
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? ImageURL { get; set; }

        public string? TrailerURL { get; set; }

        public int Price { get; set; }
    }
}
