﻿using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers.Games
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesDiscountController : ControllerBase
    {
        private readonly IGamesDiscountRepository _repository;

        public GamesDiscountController(IGamesDiscountRepository repository)
        {
            _repository = repository;
        }

        // CRUD tổng thể
        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _repository.GetAll();
            var dtos = models.Select(d => new GamesDiscountDTO
            {
                Id = d.Id,
                Code = d.Code,
                Description = d.Description,
                Value = d.Value,
                IsPercent = d.IsPercent,
                StartDate = d.StartDate,
                EndDate = d.EndDate,
                IsActive = d.IsActive,
                CreatedAt = d.CreatedAt
            }).ToList();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var d = _repository.Get(id);
            if (d == null) return NotFound();

            var dto = new GamesDiscountDTO
            {
                Id = d.Id,
                Code = d.Code,
                Description = d.Description,
                Value = d.Value,
                IsPercent = d.IsPercent,
                StartDate = d.StartDate,
                EndDate = d.EndDate,
                IsActive = d.IsActive,
                CreatedAt = d.CreatedAt
            };
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] GamesDiscountDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.EndDate < dto.StartDate)
                return BadRequest("EndDate must be after StartDate.");

            if (_repository.IsCodeExist(dto.Code))
                return BadRequest("Code already exists.");

            var entity = new GamesDiscount
            {
                Code = dto.Code,
                Description = dto.Description,
                Value = dto.Value,
                IsPercent = dto.IsPercent,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsActive = dto.IsActive
            };

            var created = _repository.Create(entity);

            dto.Id = created.Id;
            dto.CreatedAt = created.CreatedAt;
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GamesDiscountDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.EndDate < dto.StartDate)
                return BadRequest("EndDate must be after StartDate.");

            if (_repository.IsCodeExist(dto.Code, id))
                return BadRequest("Code already exists.");

            var entity = new GamesDiscount
            {
                Id = id,
                Code = dto.Code,
                Description = dto.Description,
                Value = dto.Value,
                IsPercent = dto.IsPercent,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsActive = dto.IsActive
            };

            var updated = _repository.Update(id, entity);
            if (updated == null) return NotFound();

            dto.Id = updated.Id;
            dto.CreatedAt = updated.CreatedAt;
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }

        // --- NEW: API thao tác discount theo game ---

        [HttpGet("by-game/{gameId}")]
        public IActionResult GetDiscountsByGame(int gameId)
        {
            var models = _repository.GetByGameId(gameId);
            var dtos = models.Select(d => new GamesDiscountDTO
            {
                Id = d.Id,
                Code = d.Code,
                Description = d.Description,
                Value = d.Value,
                IsPercent = d.IsPercent,
                StartDate = d.StartDate,
                EndDate = d.EndDate,
                IsActive = d.IsActive,
                CreatedAt = d.CreatedAt
            }).ToList();
            return Ok(dtos);
        }

        // Gán discount có sẵn cho game
        [HttpPost("assign/{gameId}/{discountId}")]
        public IActionResult AssignDiscountToGame(int gameId, int discountId)
        {
            _repository.AddDiscountToGame(gameId, discountId);
            return Ok();
        }

        // Bỏ discount khỏi game
        [HttpDelete("remove/{gameId}/{discountId}")]
        public IActionResult RemoveDiscountFromGame(int gameId, int discountId)
        {
            _repository.RemoveDiscountFromGame(gameId, discountId);
            return NoContent();
        }

        // (OPTIONAL) Tạo mới discount và gán vào game ngay
        [HttpPost("create-and-assign/{gameId}")]
        public IActionResult CreateAndAssignDiscount(int gameId, [FromBody] GamesDiscountDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.EndDate < dto.StartDate)
                return BadRequest("EndDate must be after StartDate.");

            if (_repository.IsCodeExist(dto.Code))
                return BadRequest("Code already exists.");

            var entity = new GamesDiscount
            {
                Code = dto.Code,
                Description = dto.Description,
                Value = dto.Value,
                IsPercent = dto.IsPercent,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsActive = dto.IsActive
            };

            var created = _repository.Create(entity);
            _repository.AddDiscountToGame(gameId, created.Id);

            dto.Id = created.Id;
            dto.CreatedAt = created.CreatedAt;
            return Ok(dto);
        }
    }

}
