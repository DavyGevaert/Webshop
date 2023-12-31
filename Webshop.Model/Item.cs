﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Model
{
    public class Item
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? ImageURL { get; set; }

        public string? TrailerURL { get; set; }

        public int Price { get; set; }

        public int CurrentInStock { get; set; }

        public int Quantity { get; set; }

        public bool OutOfStock { get; set; }

        public string ButtonText { get; set; } = "Buy";
    }
}
