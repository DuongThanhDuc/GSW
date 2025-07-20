using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using DataAccess;
using DataAccess.DTOs;


namespace GSW.GSWApi.Utility
{
    public class VnPayHelper
    {
        public static string CreatePaymentUrl(
        DataAccess.DTOs.PaymentRequestDTO model,
        IConfiguration configuration,
        string ipAddress)
        {
            var vnp_TmnCode = configuration["VnPay:TmnCode"];
            var vnp_HashSecret = configuration["VnPay:HashSecret"];
            var vnp_Url = configuration["VnPay:Url"];
            var vnp_ReturnUrl = configuration["VnPay:ReturnUrl"];

            var pay = new Dictionary<string, string>
        {
                {"vnp_Version", "2.1.0"},
                {"vnp_Command", "pay"},
                {"vnp_TmnCode", vnp_TmnCode},
                {"vnp_Amount", ((int)(model.Amount * 100)).ToString()},
                {"vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss")},
                {"vnp_CurrCode", "VND"},
                {"vnp_IpAddr", ipAddress},
                {"vnp_Locale", "vn"},
                {"vnp_OrderInfo", $"Thanh toan don hang {model.OrderId}"},
                {"vnp_OrderType", "other"},
                {"vnp_ReturnUrl", vnp_ReturnUrl},
                {"vnp_TxnRef", model.OrderId},
            };

            // Lọc bỏ param null/rỗng
            var filtered = pay.Where(x => !string.IsNullOrEmpty(x.Value))
                              .OrderBy(x => x.Key)
                              .ToList();

            // Build signData và query CHUẨN
            var query = string.Join("&", filtered.Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value)}"));
            var signData = string.Join("&", filtered.Select(x => $"{x.Key}={x.Value}"));
            var hash = CreateHmacSHA512(vnp_HashSecret, signData);

            // Log kiểm tra:
            Console.WriteLine("signData: " + signData);
            Console.WriteLine("hash: " + hash);

            var paymentUrl = $"{vnp_Url}?{query}&vnp_SecureHash={hash}";
            return paymentUrl;
        }


        public static string CreateHmacSHA512(string key, string input)
        {
            var hash = new HMACSHA512(Encoding.UTF8.GetBytes(key));
            var bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        // Validate chữ ký callback VNPAY (IPN, ReturnUrl)
        public static bool ValidateVnpaySignature(IQueryCollection query, string hashSecret)
        {
            var data = query
                .Where(kv => kv.Key.StartsWith("vnp_") && kv.Key != "vnp_SecureHash" && kv.Key != "vnp_SecureHashType")
                .OrderBy(kv => kv.Key)
                .ToDictionary(kv => kv.Key, kv => kv.Value.ToString());

            var rawData = string.Join("&", data.Select(x => $"{x.Key}={x.Value}"));
            var secureHash = CreateHmacSHA512(hashSecret, rawData);
            var vnp_SecureHash = query["vnp_SecureHash"].ToString();

            return string.Equals(secureHash, vnp_SecureHash, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
