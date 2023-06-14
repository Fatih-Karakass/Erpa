using ErpaHoldingFatihKarakas.Domain.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Services
{
    public interface IModelServices
    {
        public Task<ModelCreateDto> CreateAsync(ModelCreateDto modelCreateDto);
        public Task<ModelUpdateDto> UpdateAsync(ModelUpdateDto modelUpdateDto);
        public Task DeleteModel(int Id);
        public Task<List<ModelDto>> GetAll();
        public Task<ModelDto> Get(int id);
        public Task<List<ModelDto>> GetAllByBrand(int BrandId);
    }
}
