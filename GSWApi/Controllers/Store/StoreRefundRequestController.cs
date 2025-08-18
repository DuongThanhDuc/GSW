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
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var data = await (
            from r in _ctx.Store_RefundRequests.AsNoTracking()
            join o in _ctx.Store_Orders.AsNoTracking() on r.OrderID equals o.ID
            join u in _ctx.Users.AsNoTracking() on o.UserID equals u.Id // user của đơn hàng
            select new StoreRefundRequestDTO
            {
                ID = r.ID,
                OrderID = r.OrderID,
                UserID = o.UserID,                  // hoặc r.UserID nếu bạn muốn lấy theo request
                Reason = r.Reason,
                Status = r.Status,
                RequestDate = r.RequestDate,

                Order = new OrderMinDTO
                {
                    Id = o.ID,
                    OrderCode = o.OrderCode,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    CreatedAt = o.CreatedAt
                },
                User = new UserMinDTO
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber
                }
            }).ToListAsync(ct);

        return Ok(new { success = true, data });
    }

    // GET: /api/StoreRefundRequest/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct)
    {
        var dto = await (
            from r in _ctx.Store_RefundRequests.AsNoTracking()
            where r.ID == id
            join o in _ctx.Store_Orders.AsNoTracking() on r.OrderID equals o.ID
            join u in _ctx.Users.AsNoTracking() on o.UserID equals u.Id
            select new StoreRefundRequestDTO
            {
                ID = r.ID,
                OrderID = r.OrderID,
                UserID = o.UserID,
                Reason = r.Reason,
                Status = r.Status,
                RequestDate = r.RequestDate,
                Order = new OrderMinDTO
                {
                    Id = o.ID,
                    OrderCode = o.OrderCode,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    CreatedAt = o.CreatedAt
                },
                User = new UserMinDTO
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber
                }
            }).FirstOrDefaultAsync(ct);

        if (dto == null)
            return NotFound(new { success = false, message = "Refund request not found." });

        return Ok(new { success = true, data = dto });
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

        return CreatedAtAction(nameof(Get), new { id = entity.ID },
            new { success = true, data = dto });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] StoreRefundRequestDTO dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return NotFound(new { success = false, message = "Not found." });

        entity.OrderID = dto.OrderID;
        entity.UserID = dto.UserID;
        entity.Reason = dto.Reason;
        entity.Status = dto.Status;
        entity.RequestDate = dto.RequestDate;

        await _repository.UpdateAsync(entity);
        return Ok(new { success = true }); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok(new { success = true });
    }
}
