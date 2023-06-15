using AutoMapper;
using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Baskets.Dto;
using ErpaHoldingFatihKarakas.Domain.Products;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Application.Services.Baskets
{
    public class BasketService : IBasketServices
    {
        private readonly IBasketRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
    
  
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository repository, IMapper mapper, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task AddProductToBasket(int productId, int productCount, Guid UserId)
        {
            
            var product=await _productRepository.GetByIdAsync(productId);
            var basket = await _repository.GetAll()
                .Include(x=>x.Products)
                .Include(x=>x.User)
                .Where(x=>x.User.Id==UserId)
                .Where(x => x.IsOrdered == false)
                .FirstOrDefaultAsync();
            if(product == null)
            {
                throw new Exception("Bulunamadı");
            }
            if (productCount > product.Stock && product.Stock <= 0)
            {
                throw new Exception("Stok sayısı yetersiz");
            }

            if (basket == null)//sepet yoksa
            {
                Basket newbasket = new Basket()
                {
                    Products = new List<Product>(),
                    UserId = UserId
                };
                newbasket.Products.Add(product);
               var basketFromDb= await _repository.CreateAsync(newbasket);
                await _unitOfWork.SaveChangesAsync();
                await _repository.UpdateProductCountBasket(basketFromDb.Id, productId, productCount);
                await _unitOfWork.SaveChangesAsync();
            }
            else//basket varsa
            {
            //ilerleyemedim.
            }
            
        }

        public async Task<BasketDto> ListBasket(int basketId)
        {
            var basket= await _repository.GetAll().Include(x=>x.Products).FirstOrDefaultAsync(x=>x.Id==basketId);
            if (basket == null)
            {
                throw new Exception("Bulunamadı");
            }
            return _mapper.Map<BasketDto>(basket);
        }

        public Task RemoveProductFromBasket(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<BasketUpdateDto> UpdateBasket(int productId, int basketId, int productCount)
        {
            
            throw new NotImplementedException();
        }
    }
}
