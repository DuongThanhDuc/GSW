using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IPaymentRepository
    {
        Task<PaymentTransaction> CreateTransactionAsync(PaymentTransaction transaction);
        Task<PaymentTransaction?> GetByOrderCodeAsync(string orderCode);
        Task<IEnumerable<PaymentTransaction>> GetByStoreOrderIdAsync(int storeOrderId);
        Task<StoreOrder?> FindOrderByCodeAsync(string orderCode);
        Task UpdateTransactionAsync(PaymentTransaction transaction);
        Task GrantGameToLibraryAsync(string orderCode);
        Task UpdateOrderStatusByCodeAsync(string orderCode, string status);
        Task<StoreOrder> CreateProvisionalOrderAsync(string orderCode, string? userId, decimal amount,string? buyerEmail = null, string? buyerName = null);


    }

}
