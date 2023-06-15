using AutoMapper;
using ErpaHoldingFatihKarakas.Domain.Brands;
using ErpaHoldingFatihKarakas.Domain.Brands.Dto;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace ErpaHoldingFatihKarakas.Application.Services.Brands
{
    public class BrandServices : IBrandServices
    {
        private readonly IBrandRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public BrandServices(IBrandRepository repository, IMapper mapper, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BrandCreateDto> CreateAsync(BrandCreateDto brandCreateDto)
        {
            var Brand = _mapper.Map<Brand>(brandCreateDto);
            await _repository.CreateAsync(Brand);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BrandCreateDto>(Brand);
        }

        public async Task Delete(int Id)
        {
            var Brand = await _repository.GetByIdAsync(Id);
            if (Brand == null)
            {
                throw new Exception("Bulunamadı");
            }
            await _repository.DeleteAsync(Brand);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<BrandDto> Get(int id)
        {
            var brand = await _repository.GetAll().Include(x => x.Products).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (brand == null)
            {
                throw new Exception("Bulunamadı");
            }
            return _mapper.Map<BrandDto>(brand);
        }

        public async Task<List<BrandDto>> GetAll()
        {
            var BrandList = await _repository.GetAll().Include(x=>x.Products).ToListAsync();
            return _mapper.Map<List<BrandDto>>(BrandList);
        }

        public async Task<BrandDto> GetProductByBrand(int productId)
        {
            var Product = await _productRepository.GetByIdAsync(productId);
            var Brand=await _repository.GetByIdAsync(Product.BrandId);
            return _mapper.Map<BrandDto>(Brand);
            
        }

        public async Task<BrandUpdateDto> UpdateAsync(BrandUpdateDto brandUpdateDto)
        {
            var Brand = _mapper.Map<Brand>(brandUpdateDto);
            var BrandFromDb = await _repository.UpdateAsync(Brand);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BrandUpdateDto>(BrandFromDb);
        }
    }
}
