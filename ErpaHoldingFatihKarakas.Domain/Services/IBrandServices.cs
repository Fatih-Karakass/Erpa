using ErpaHoldingFatihKarakas.Domain.Brands.Dto;
using ErpaHoldingFatihKarakas.Domain.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Services
{
    public interface IBrandServices
    {
        public Task<BrandCreateDto> CreateAsync(BrandCreateDto brandCreateDto);
        public Task<BrandUpdateDto> UpdateAsync(BrandUpdateDto brandUpdateDto);
        public Task Delete(int Id);
        public Task<List<BrandDto>> GetAll();
        public Task<BrandDto> Get(int id);
        //public Task<List<BrandDto>> GetProductByBrand(int productId);
        public Task<BrandDto> GetProductByBrand(int productId);
    }
}
