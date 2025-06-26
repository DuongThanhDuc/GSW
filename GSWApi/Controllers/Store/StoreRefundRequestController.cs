using DataAccess.DTOs;
using BusinessModel.Model;
using DataAccess.Repository; 
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataAccess.Repository.IRepository;

[ApiController]
[Route("api/[controller]")]
public class StoreRefundRequestController : ControllerBase
{
    private readonly IStoreRefundRequestRepository _repository;

    public StoreRefundRequestController(IStoreRefundRequestRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var entities = await _repository.GetAllAsync();
        var dtos = entities.Select(x => new StoreRefundRequestDTO
        {
            ID = x.ID,
            OrderID = x.OrderID,
            UserID = x.UserID,
            Reason = x.Reason,
            Status = x.Status,
            RequestDate = x.RequestDate
        }).ToList();

        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return NotFound();

        var dto = new StoreRefundRequestDTO
        {
            ID = entity.ID,
            OrderID = entity.OrderID,
            UserID = entity.UserID,
            Reason = entity.Reason,
            Status = entity.Status,
            RequestDate = entity.RequestDate
        };
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StoreRefundRequestDTO dto)
    {
        var entity = new StoreRefundRequest
        {
            OrderID = dto.OrderID,
            UserID = dto.UserID,
            Reason = dto.Reason,
            Status = dto.Status,
            RequestDate = dto.RequestDate
        };
        await _repository.AddAsync(entity);
        dto.ID = entity.ID; 
        return CreatedAtAction(nameof(Get), new { id = entity.ID }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] StoreRefundRequestDTO dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return NotFound();

        entity.OrderID = dto.OrderID;
        entity.UserID = dto.UserID;
        entity.Reason = dto.Reason;
        entity.Status = dto.Status;
        entity.RequestDate = dto.RequestDate;

        await _repository.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
