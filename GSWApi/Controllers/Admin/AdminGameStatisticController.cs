using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace GSWApi.Controllers.Admin
{

    [Route("api/admin/games")]
    [ApiController]
    public class AdminGameStatisticController : ControllerBase
    {
        private readonly IGameStatisticRepository _repo;

        public AdminGameStatisticController(IGameStatisticRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("top-selling")]
        public async Task<IActionResult> GetTopSellingGames([FromBody] TopSellingGameRequestDTO req)
        {
            if (req.From > req.To)
                return BadRequest("From date must be before To date.");

            var result = await _repo.GetTopSellingGamesAsync(req.From, req.To, req.TopN > 0 ? req.TopN : 5);
            return Ok(result);
        }

        // Export Excel Top Selling Game
        [HttpPost("top-selling/export")]
        public async Task<IActionResult> ExportTopSellingGames([FromBody] TopSellingGameRequestDTO req)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            var result = await _repo.GetTopSellingGamesAsync(req);

            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("TopSellingGames");
            ws.Cells[1, 1].Value = "Game";
            ws.Cells[1, 2].Value = "Genre";
            ws.Cells[1, 3].Value = "Developer";
            ws.Cells[1, 4].Value = "Status";
            ws.Cells[1, 5].Value = "Sold";
            ws.Cells[1, 6].Value = "Revenue";

            int row = 2;
            foreach (var game in result.Games)
            {
                ws.Cells[row, 1].Value = game.GameTitle;
                ws.Cells[row, 2].Value = game.Genre;
                ws.Cells[row, 3].Value = game.DeveloperId;
                ws.Cells[row, 4].Value = game.Status;
                ws.Cells[row, 5].Value = game.SoldQuantity;
                ws.Cells[row, 6].Value = game.TotalRevenue;
                row++;
            }

            var bytes = package.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TopSellingGames.xlsx");
        }
    }
}
