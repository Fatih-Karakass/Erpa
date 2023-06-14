using ErpaHoldingFatihKarakas.Application.Services.Categories;
using ErpaHoldingFatihKarakas.Domain.Categories.Dto;
using ErpaHoldingFatihKarakas.Domain.Models.Dto;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHoldingFatihKarakas.API.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelServices _modelServices;

        public ModelController(IModelServices modelServices)
        {
            _modelServices = modelServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddModel(ModelCreateDto modelCreateDto)
        {

            var Model = await _modelServices.CreateAsync(modelCreateDto);
            return Ok(Model);

        }
        [HttpPut]

        public async Task<IActionResult> UpdateModel(ModelUpdateDto modelUpdateDto)
        {

            var Model = await _modelServices.UpdateAsync(modelUpdateDto);
            return Ok(Model);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllModel()
        {

            var Models = await _modelServices.GetAll();
            return Ok(Models);

        }
        [HttpDelete]

        public async Task<IActionResult> DeleteModel(int id)
        {

            var Model = _modelServices.DeleteModel(id);
            return Ok(Model);

        }
        [HttpGet]

        public async Task<IActionResult> GetModel(int id)
        {

            var Model = await _modelServices.Get(id);
            return Ok(Model);

        }
        [HttpGet]

        public async Task<IActionResult> GetAllByBrand(int BrandId)
        {

            var Model = _modelServices.GetAllByBrand(BrandId);
            return Ok(Model);

        }
       
    }
}
