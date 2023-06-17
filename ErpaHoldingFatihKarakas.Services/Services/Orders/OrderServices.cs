using AutoMapper;
using ErpaHoldingFatihKarakas.Domain.Orders.Dto;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace ErpaHoldingFatihKarakas.Application.Services.Orders
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public OrderServices(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDto> GetOrder(int id, Guid userId)
        {
            var order = await _orderRepository.GetAll()

                .Include(x => x.Basket)
                .ThenInclude(x => x.Products)
                .Where(x => x.Basket.User.Id == userId)
                .Where(x => x.Basket.IsOrdered == true)
                .FirstOrDefaultAsync();
            if (order == null)
            {
                throw new Exception("bulunamadı");
            }
            return _mapper.Map<OrderDto>(order);

        }

        public async Task<List<OrderDto>> GetOrderByUser(string userName)
        {
            var order = await _orderRepository.GetAll()
                 .Include(x => x.Basket)
                 .ThenInclude(x => x.Products)
                 .ThenInclude(x => x.Baskets)
                 .ThenInclude(x => x.User)
                 .Where(x => x.Basket.IsOrdered == true)
                 .Where(x => x.Basket.User.UserName == userName)
                 .ToListAsync();
            //.ThenInclude(x => x.Baskets)
            //     .ThenInclude(x => x.User)
            //     .Where(x => x.Basket.User.UserName == userName)
            //burda
            if (order.Count == 0)
            {
                throw new Exception("bulunamadı");
            }
            return _mapper.Map<List<OrderDto>>(order);
        }

        public async Task<List<OrderDto>> ListAllOrder()
        {
            var order = await _orderRepository.GetAll()
                .Include(x => x.Basket)
                .ThenInclude(x => x.Products)
                .ToListAsync();
            if (order == null)
            {
                throw new Exception("bulunamadı");
            }
            return _mapper.Map<List<OrderDto>>(order);

        }

        public async Task<OrderUpdateDto> UpdateOrder(int orderId, Guid userId)
        {
            var order = await _orderRepository.GetAll()
                .Include(x => x.Basket)
                .ThenInclude(x => x.Products)
                .Where(x => x.Basket.User.Id == userId)
                .Where(x => x.Basket.IsOrdered == true)
                .FirstOrDefaultAsync(x => x.Id == orderId);
            if (order == null)
            {
                throw new Exception("bulunamadı");
            }
            return _mapper.Map<OrderUpdateDto>(order);

        }
    }
}
