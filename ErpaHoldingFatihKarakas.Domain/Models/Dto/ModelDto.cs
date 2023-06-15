using ErpaHoldingFatihKarakas.Domain.Products;
using ErpaHoldingFatihKarakas.Domain.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Models.Dto
{
    public class ModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductDto Product { get; set; }
    }
}
