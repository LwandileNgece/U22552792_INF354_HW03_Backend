using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using U22552792_INF354_HW03_Backend.Models.IRepositories;

namespace U22552792_INF354_HW03_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet("productCountByBrand")]
        public async Task<IActionResult> GetProductCountByBrand()
        {
            try
            {
                var productCounts = await _reportRepository.GetProductCountByBrandAsync();
                return Ok(productCounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("productCountByProductType")]
        public async Task<IActionResult> GetProductCountByProductType()
        {
            try
            {
                var productCounts = await _reportRepository.GetProductCountByProductTypeAsync();
                return Ok(productCounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("activeProductsReport")]
        public async Task<IActionResult> GetActiveProductsReport()
        {
            try
            {
                var reportData = await _reportRepository.GetActiveProductsReportAsync();
                return Ok(reportData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
