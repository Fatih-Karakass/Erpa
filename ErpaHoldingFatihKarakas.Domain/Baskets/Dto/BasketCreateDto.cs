﻿using ErpaHoldingFatihKarakas.Domain.Products;
using ErpaHoldingFatihKarakas.Domain.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Baskets.Dto
{
    public class BasketCreateDto
    {


        public List<ProductDto> Products { get; set; }
 

        public bool IsOrdered { get; set; } = false;
    }
}
