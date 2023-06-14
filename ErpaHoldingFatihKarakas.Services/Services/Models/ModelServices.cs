using AutoMapper;
using ErpaHoldingFatihKarakas.Domain.Models;
using ErpaHoldingFatihKarakas.Domain.Models.Dto;
using ErpaHoldingFatihKarakas.Domain.Products;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Application.Services.Models
{
    public class ModelServices : IModelServices
    {
        private readonly IModelRepository _repository;

        private readonly IMapper _mapper;

        public ModelServices(IMapper mapper, IModelRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ModelCreateDto> CreateAsync(ModelCreateDto modelCreateDto)
        {
          if(modelCreateDto == null)
            {
                throw new ArgumentNullException(nameof(modelCreateDto));
            }
            var Model = _mapper.Map<Model>(modelCreateDto);
            await _repository.CreateAsync(Model);
            return _mapper.Map<ModelCreateDto>(Model);
            

        }

        public async Task DeleteModel(int Id)
        {
            var Model = await _repository.GetByIdAsync(Id);
            if (Model== null)
            {
                throw new Exception("Bulunamadı");
            }
            await _repository.DeleteAsync(Model);
    
        }

        public async Task<ModelDto> Get(int id)
        {
            var Model= await _repository.GetByIdAsync(id);
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
            var ModelList = await _repository.GetAll().Where(x => x.Product.BrandId == BrandId).ToListAsync();
            return _mapper.Map<List<ModelDto>>(ModelList);
        }

        public async Task<ModelUpdateDto> UpdateAsync(ModelUpdateDto modelUpdateDto)
        {
            var Model = _mapper.Map<Model>(modelUpdateDto);
            var ModelFromDb= await _repository.UpdateAsync(Model);
            return _mapper.Map<ModelUpdateDto>(ModelFromDb);
        }
    }
}
