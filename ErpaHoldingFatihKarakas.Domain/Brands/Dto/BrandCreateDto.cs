﻿using ErpaHoldingFatihKarakas.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Brands.Dto
{
    public class BrandCreateDto
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
