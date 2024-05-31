using static U22552792_INF354_HW03_Backend.Models.ViewModels.ActiveProductsReportViewModel;

namespace U22552792_INF354_HW03_Backend.Models.IRepositories
{
    public interface IReportRepository
    {
        Task<Dictionary<string, int>> GetProductCountByBrandAsync();
        Task<Dictionary<string, int>> GetProductCountByProductTypeAsync();
        Task<IEnumerable<ActiveProductsReportDTO>> GetActiveProductsReportAsync();
    }
}
