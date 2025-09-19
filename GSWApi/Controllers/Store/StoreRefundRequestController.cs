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
    private readonly IStoreOrderRepository _orderRepository;
    private readonly DBContext _ctx;
    public StoreRefundRequestController(IStoreRefundRequestRepository repository, IStoreOrderRepository orderRepository, DBContext ctx)
    {
        _repository = repository;
        _orderRepository = orderRepository;
        _ctx = ctx;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var entities = await _ctx.Store_RefundRequests.Include(r => r.Order).ToListAsync();
        var data = entities.Select(x => new
        {
            Id = x.ID,
            orderID = x.OrderID,
            userID = x.UserID,
            reason = x.Reason,
            status = x.Status,
            order = new OrderMinDTO
            {
                Id = x.OrderID,
                OrderCode = x.Order.OrderCode,
                TotalAmount = x.Order.TotalAmount,
                Status = x.Order.Status,
                CreatedAt = x.Order.CreatedAt,
            },

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
        if (entity == null) return NotFound(new { success = false, message = "Refund request not found" });

        // Cập nhật các thông tin của yêu cầu hoàn tiền
        entity.OrderID = dto.OrderID;
        entity.UserID = dto.UserID;
        entity.Reason = dto.Reason;
        entity.Status = dto.Status;  
        entity.RequestDate = dto.RequestDate;

        // Cập nhật yêu cầu hoàn tiền
        await _repository.UpdateAsync(entity);

        // Nếu trạng thái yêu cầu là 'accepted' (hoàn tiền được chấp nhận)
        if (entity.Status.Equals("accepted", StringComparison.OrdinalIgnoreCase))
        {
            // Cập nhật trạng thái đơn hàng liên quan thành 'refunded'
            var order = await _ctx.Store_Orders.FirstOrDefaultAsync(o => o.ID == entity.OrderID);
            if (order != null)
            {
                order.Status = "refunded";  
                await _ctx.SaveChangesAsync();
            }
        }
        // Nếu trạng thái yêu cầu là 'rejected' (hoàn tiền bị từ chối)
        else if (entity.Status.Equals("rejected", StringComparison.OrdinalIgnoreCase))
        {
            // Nếu không còn yêu cầu hoàn tiền nào khác, cập nhật trạng thái đơn hàng thành 'refund_rejected'
            var pendingRefunds = await _repository.GetAllAsync();
            var hasPendingRefund = pendingRefunds.Any(r => r.OrderID == entity.OrderID && r.Status.Equals("pending", StringComparison.OrdinalIgnoreCase));

            var order = await _ctx.Store_Orders.FirstOrDefaultAsync(o => o.ID == entity.OrderID);
            if (order != null)
            {
                order.Status = hasPendingRefund ? "waiting_refund" : "refund_rejected";  // Nếu còn yêu cầu pending khác, giữ trạng thái 'waiting_refund'
                await _ctx.SaveChangesAsync();
            }
        }

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
