using Microsoft.EntityFrameworkCore;
using U22552792_INF354_HW03_Backend.Data;
using U22552792_INF354_HW03_Backend.Models.IRepositories;

namespace U22552792_INF354_HW03_Backend.Models.Repositories
{
    public class StoreRepository: IStoreRepository
    {
        private readonly AppDbContext _appDbContext;
        public StoreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Product[]> GetAllProductsAsync()
        {
            IQueryable<Product> query = _appDbContext.Products;
            return await query.ToArrayAsync();
        }
        public async Task<Brand[]> GetAllBrandsAsync()
        {
            IQueryable<Brand> query = _appDbContext.Brands;
            return await query.ToArrayAsync();
        }
        public async Task<ProductType[]> GetAllProductTypesAsync()
        {
            IQueryable<ProductType> query = _appDbContext.ProductTypes;
            return await query.ToArrayAsync();
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            try
            {
                _appDbContext.Products.Add(product);
                await _appDbContext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding product to the database", ex);
            }
        }
    }
}
