using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using U22552792_INF354_HW03_Backend.Models;
using U22552792_INF354_HW03_Backend.Models.IRepositories;
using U22552792_INF354_HW03_Backend.Models.ViewModels;

namespace U22552792_INF354_HW03_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            try
            {
                var results = await _storeRepository.GetAllProductsAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
        [HttpGet]
        [Route("GetAllProductTypes")]
        public async Task<IActionResult> GetAllProductTypesAsync()
        {
            try
            {
                var results = await _storeRepository.GetAllProductTypesAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
        [HttpGet]
        [Route("GetAllBrands")]
        public async Task<IActionResult> GetAllBrandsAsync()
        {
            try
            {
                var results = await _storeRepository.GetAllBrandsAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct(AddProductViewModel productVM)
        {
            try
            {
                // Map DTO to Product entity
                var product = new Product
                {
                    Name = productVM.Name,
                    Description = productVM.Description,
                    DateCreated = productVM.DateCreated,
                    DateModified = productVM.DateModified,
                    IsActive = productVM.IsActive,
                    IsDeleted = productVM.IsDeleted,
                    Price = productVM.Price,
                    ProductTypeId = productVM.ProductTypeId,
                    BrandId = productVM.BrandId,
                    Image = productVM.Image
                };

                var addedProduct = await _storeRepository.AddProductAsync(product);
                return Ok(addedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
