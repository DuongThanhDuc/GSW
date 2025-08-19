using DataAccess.DTOs;
using BusinessModel.Model;
using DataAccess.Repository; 
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class StoreRefundRequestController : ControllerBase
{
    private readonly IStoreRefundRequestRepository _repository;
    private readonly DBContext _ctx;
    public StoreRefundRequestController(IStoreRefundRequestRepository repository, DBContext ctx)
    {
        _repository = repository;
        _ctx = ctx;
    }

    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var entities = await _repository.GetAllAsync();

        var data = entities.Select(x => new
        {
            orderID = x.OrderID,
            userID = x.UserID,        
            reason = x.Reason,
            status = x.Status,
            requestDate = x.RequestDate
        }).ToList();

        return Ok(new { success = true, data });
    }

    // GET: /api/StoreRefundRequest/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var x = await _repository.GetByIdAsync(id);
        if (x == null) return NotFound(new { success = false, message = "Not found" });

        var data = new
        {
            orderID = x.OrderID,
            userID = x.UserID,
            reason = x.Reason,
            status = x.Status,
            requestDate = x.RequestDate
        };

        return Ok(new { success = true, data });
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

        var data = new
        {
            orderID = entity.OrderID,
            userID = entity.UserID,
            reason = entity.Reason,
            status = entity.Status,
            requestDate = entity.RequestDate
        };

        return CreatedAtAction(nameof(Get), new { id = entity.ID }, new { success = true, data });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] StoreRefundRequestDTO dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return NotFound(new { success = false, message = "Not found" });

        entity.OrderID = dto.OrderID;
        entity.UserID = dto.UserID;
        entity.Reason = dto.Reason;
        entity.Status = dto.Status;
        entity.RequestDate = dto.RequestDate;

        await _repository.UpdateAsync(entity);

       
        return Ok(new
        {
            success = true,
            data = new
            {
                orderID = entity.OrderID,
                userID = entity.UserID,
                reason = entity.Reason,
                status = entity.Status,
                requestDate = entity.RequestDate
            }
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok(new { success = true });
    }
}
