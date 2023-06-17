﻿using ErpaHoldingFatihKarakas.Domain.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Categories.Dto
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public string Desciription { get; set; }

        //public int? SubCategoryId { get; set; }
    }
}
