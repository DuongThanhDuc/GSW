using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;


namespace GSWApi.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/statistic")]
 
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticRepository _repo;

        public StatisticController(IStatisticRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("revenue")]
        public async Task<IActionResult> GetRevenueStatistic([FromBody] RevenueStatisticRequestDTO request)
        {
            if (request.From > request.To)
                return BadRequest("From date must be before To date.");

            var stat = await _repo.GetRevenueStatisticAsync(request);
            return Ok(stat);
        }

        [HttpPost("revenue/export")]
        public async Task<IActionResult> ExportRevenueStatistic([FromBody] RevenueStatisticRequestDTO request)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;



            var stat = await _repo.GetRevenueStatisticAsync(request);

            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("RevenueReport");
            ws.Cells[1, 1].Value = "Date";
            ws.Cells[1, 2].Value = "Revenue";
            ws.Cells[1, 3].Value = "Orders";

            int row = 2;
            foreach (var day in stat.RevenueByDay)
            {
                ws.Cells[row, 1].Value = day.Date.ToShortDateString();
                ws.Cells[row, 2].Value = day.Revenue;
                ws.Cells[row, 3].Value = day.Orders;
                row++;
            }

            ws.Cells[row + 1, 1].Value = "Total Revenue";
            ws.Cells[row + 1, 2].Value = stat.TotalRevenue;

            // Thêm sheet Top Game (optional)
            var wsTop = package.Workbook.Worksheets.Add("TopSellingGames");
            wsTop.Cells[1, 1].Value = "Game";
            wsTop.Cells[1, 2].Value = "Sold";
            wsTop.Cells[1, 3].Value = "Revenue";
            int row2 = 2;
            foreach (var game in stat.TopSellingGames)
            {
                wsTop.Cells[row2, 1].Value = game.GameName;
                wsTop.Cells[row2, 2].Value = game.SoldQuantity;
                wsTop.Cells[row2, 3].Value = game.Revenue;
                row2++;
            }

            var bytes = package.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RevenueReport.xlsx");
        }
    }
}
