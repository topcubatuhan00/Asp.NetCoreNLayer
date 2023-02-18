using AutoMapper;
using Core.DTos;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using NLayerAPI.Filters;

namespace NLayerAPI.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _service = productService;
            _mapper = mapper;
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }




        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products).ToList();
            //return Ok( CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            //return Ok( CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            //return Ok( CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));

            //return Ok( CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            //return Ok( CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
