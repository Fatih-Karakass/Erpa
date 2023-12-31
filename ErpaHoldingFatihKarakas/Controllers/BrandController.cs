﻿using ErpaHoldingFatihKarakas.Domain.Brands.Dto;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHoldingFatihKarakas.API.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandServices _brandRepository;

        public BrandController(IBrandServices brandRepository)
        {
            _brandRepository = brandRepository;
        }
        [HttpPost]

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateBrand(BrandCreateDto brandCreateDto)
        {
            var brand = await _brandRepository.CreateAsync(brandCreateDto);
            return Ok(brand);

        }
        [HttpPut]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateBrand(BrandUpdateDto brandUpdateDto)
        {
            var brand = await _brandRepository.UpdateAsync(brandUpdateDto);
            return Ok(brand);

        }
        [HttpDelete]

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBrand(int Id)
        {
            await _brandRepository.Delete(Id);
            return Ok();

        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {
            var brand = await _brandRepository.GetAll();
            return Ok(brand);

        }
        [HttpGet]

        public async Task<IActionResult> GetBrandProducts(int Id)
        {
            var brand = await _brandRepository.Get(Id);
            return Ok(brand);

        }
        [HttpGet]

        public async Task<IActionResult> GetProductByBrand(int productId)
        {
            var brand = await _brandRepository.GetProductByBrand(productId);
            return Ok(brand);

        }

    }
}
