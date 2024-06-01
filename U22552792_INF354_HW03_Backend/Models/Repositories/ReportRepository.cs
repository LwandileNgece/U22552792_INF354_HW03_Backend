using U22552792_INF354_HW03_Backend.Data;
using U22552792_INF354_HW03_Backend.Models.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static U22552792_INF354_HW03_Backend.Models.ViewModels.ActiveProductsReportViewModel;

namespace U22552792_INF354_HW03_Backend.Models.Repositories
{
    public class ReportRepository: IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, int>> GetProductCountByBrandAsync()
        {
            return await _context.Products
                .GroupBy(p => p.Brand.Name)
                .Select(group => new
                {
                    BrandName = group.Key,
                    ProductCount = group.Count()
                })
                .ToDictionaryAsync(g => g.BrandName, g => g.ProductCount);
        }

        public async Task<Dictionary<string, int>> GetProductCountByProductTypeAsync()
        {
            return await _context.Products
                .GroupBy(p => p.ProductType.Name)
                .Select(group => new
                {
                    ProductTypeName = group.Key,
                    ProductCount = group.Count()
                })
                .ToDictionaryAsync(g => g.ProductTypeName, g => g.ProductCount);
        }
        public async Task<IEnumerable<ActiveProductsReportDTO>> GetActiveProductsReportAsync()
        {
            var activeProducts = await _context.Products
                .Where(p => p.IsActive)
                .Include(p => p.ProductType)
                .Include(p => p.Brand)
                .ToListAsync();

            var groupedData = activeProducts
                .GroupBy(p => p.Brand.Name)
                .Select(g => new ActiveProductsReportDTO
                {
                    Brand = g.Key,
                    ProductTypes = g.GroupBy(p => p.ProductType.Name)
                              .Select(pt => new ProductTypeWithProductsDTO
                              {
                                  ProductType = pt.Key,
                                  Products = pt.Select(p => new ProductDTO
                                  {
                                      Name = p.Name,
                                      Description = p.Description,
                                      Price = p.Price,
                                      Image = p.Image
                                  }).ToList()
                              }).ToList()
                }).ToList();

            return groupedData;
        }

    }
}
