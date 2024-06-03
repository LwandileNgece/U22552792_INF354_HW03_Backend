using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using U22552792_INF354_HW03_Backend.Models;
using U22552792_INF354_HW03_Backend.Models.IRepositories;
using U22552792_INF354_HW03_Backend.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static U22552792_INF354_HW03_Backend.Models.ViewModels.ActiveProductsReportViewModel;

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
        public async Task<IActionResult> AddProduct([FromForm] ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                // Handle the uploaded file
                var file = productDto.Image;
                string filePath = null;

                if (file != null && file.Length > 0)
                {
                    // Process the file (e.g., save to disk or cloud storage)
                    filePath = Path.Combine("wwwroot", "images", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                //var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var imageUrl = Path.Combine("images", file.FileName);
                // Handle the rest of the product data
                var product = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    Description = productDto.Description,
                    BrandId = productDto.BrandId,
                    ProductTypeId = productDto.ProductTypeId,
                    Image = imageUrl // Store the file path
                };

                try
                {
                    var newProduct = await _storeRepository.AddProductAsync(product);
                    return Ok(newProduct);
                }
                catch (Exception ex)
                {
                    // Log the exception if necessary
                    return StatusCode(500, "Internal server error");
                }
            }
            return BadRequest(ModelState);
        }


        private async Task<string> UploadImage(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return null;
                }

                // Generate unique file name
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // Path where the image will be stored
                var imagePath = Path.Combine("wwwroot", "images", fileName);

                // Save the image to the server
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Return the path to the uploaded image
                var imageUrl = Path.Combine("images", fileName);
                return imageUrl;
            }
            catch (Exception ex)
            {
                // Log the error or handle it as needed
                throw new Exception($"Failed to upload image: {ex.Message}");
            }
        }

    }
}
