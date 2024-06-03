using Microsoft.AspNetCore.Mvc;

namespace U22552792_INF354_HW03_Backend.Models.IRepositories
{
    public interface IStoreRepository
    {
        Task<Product[]> GetAllProductsAsync();
        Task<Brand[]> GetAllBrandsAsync();
        Task<ProductType[]> GetAllProductTypesAsync();
        Task<Product> AddProductAsync(Product product);
    }
}
