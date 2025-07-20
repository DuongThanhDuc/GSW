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
        Task<PaymentTransaction> GetByOrderIdAsync(string orderId);
        Task UpdateTransactionAsync(PaymentTransaction transaction);
    }
}
