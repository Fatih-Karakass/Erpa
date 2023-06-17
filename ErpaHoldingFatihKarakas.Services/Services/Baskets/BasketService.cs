using AutoMapper;
using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.BasketProducts;
using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Baskets.Dto;
using ErpaHoldingFatihKarakas.Domain.Orders;
using ErpaHoldingFatihKarakas.Domain.Orders.Dto;
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
        private readonly IOrderRepository _orderRepository;
    
  
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository repository, IMapper mapper, IProductRepository productRepository, IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }


        public async Task AddProductToBasket(int productId, int productCount, Guid UserId)
        {
            
            var product=await _productRepository.GetByIdAsync(productId);
            var basket = await _repository.GetAll()
                .Where(x => x.IsOrdered == false)
                .Include(x=>x.Products)
                .Include(x=>x.User)
                .Where(x=>x.User.Id==UserId)
                .FirstOrDefaultAsync();
            if(product == null)
            {
                throw new Exception("Bulunamadı");
            }
            if (productCount > product.Stock && product.Stock <= 0)
            {
                throw new Exception("Stok sayısı yetersiz");
            }

            if (basket == null)//basket yoksa
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
                basket.Products.Add(product);
                await _unitOfWork.SaveChangesAsync();
                await _repository.UpdateProductCountBasket(basket.Id, productId, productCount);

            }

        }

        public async Task<BasketDto> BasketFinished(int basketId, string adress)
        {
            var basket= await _repository.GetAll().Include(x=>x.Products).FirstOrDefaultAsync(x=>x.Id==basketId);
            if (basket == null)
            {
                throw new Exception("Bulunamadı");
            }
            basket.IsOrdered = true;
            var basketDto= _mapper.Map<BasketDto>(basket);
            await OrderCreated(adress, basketDto);
            await _unitOfWork.SaveChangesAsync();
            return basketDto;
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

        public async Task<OrderDto> OrderCreated(string adress, BasketDto basketFromDb)
        {
            var t = await _repository.GetAll()
                .Include(x => x.User)
                .Include(x => x.Products)
                .Include(x => x.Order)
                .FirstOrDefaultAsync(x=>x.Id==basketFromDb.Id);
            if (t == null)
            {
                throw new Exception("bulunamadı");
            }
            var basket = _mapper.Map<Basket>(basketFromDb);
            Order order = new Order();
            
            order.Adress = adress;
            order.Basket = t;
           
            //order.Basket = basket;
            
            await _orderRepository.CreateAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<OrderDto>(order);
        }
    }
}
