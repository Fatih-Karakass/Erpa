using AutoMapper;
using ErpaHoldingFatihKarakas.Domain.Models;
using ErpaHoldingFatihKarakas.Domain.Models.Dto;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace ErpaHoldingFatihKarakas.Application.Services.Models
{
    public class ModelServices : IModelServices
    {
        private readonly IModelRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ModelServices(IMapper mapper, IModelRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ModelCreateDto> CreateAsync(ModelCreateDto modelCreateDto)
        {

            var Model = _mapper.Map<Model>(modelCreateDto);
            await _repository.CreateAsync(Model);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ModelCreateDto>(Model);


        }

        public async Task DeleteModel(int Id)
        {
            var Model = await _repository.GetByIdAsync(Id);
            if (Model == null)
            {
                throw new Exception("Bulunamadı");
            }
            await _repository.DeleteAsync(Model);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<ModelDto> Get(int id)
        {
            var Model = await _repository.GetAll().Include(x => x.Product).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (Model == null)
            {
                throw new Exception("Bulunamadı");
            }
            return _mapper.Map<ModelDto>(Model);
        }

        public async Task<List<ModelDto>> GetAll()
        {
            var ModelList = await _repository.GetAll().ToListAsync();
            return _mapper.Map<List<ModelDto>>(ModelList);
        }

        public async Task<List<ModelDto>> GetAllByBrand(int BrandId)
        {
            var ModelList = await _repository.GetAll().Include(x => x.Product).ThenInclude(x => x.Brand).Where(x => x.Product.BrandId == BrandId).ToListAsync();
            return _mapper.Map<List<ModelDto>>(ModelList);
        }

        public async Task<ModelUpdateDto> UpdateAsync(ModelUpdateDto modelUpdateDto)
        {
            var model = await _repository.GetAll().Include(x => x.Product).Where(x => x.Id == modelUpdateDto.Id).FirstOrDefaultAsync();
            if (model == null)
            {
                throw new Exception("bulunamadı");
            }
            model.Name = modelUpdateDto.Name;
            var modelFromDb = await _repository.UpdateAsync(model);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ModelUpdateDto>(modelFromDb);
        }
    }
}
