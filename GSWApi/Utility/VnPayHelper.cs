using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using DataAccess.DTOs;
using GSWApi.Utility;
using Microsoft.Extensions.Configuration;

public static class VnPayHelper
{
    // Method to get Vietnam's time
    public static DateTime GetVietnamTime()
    {
        var tz = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
    }

    // Method to create the payment URL for VnPay
    public static string CreatePaymentUrl(PaymentRequestDTO model, IConfiguration configuration, string ipAddress)
    {
        var vnp_TmnCode = configuration["VnPay:TmnCode"]?.Trim();
        var vnp_HashSecret = configuration["VnPay:HashSecret"]?.Trim();
        var vnp_Url = configuration["VnPay:Url"]?.Trim();
        var vnp_ReturnUrl = configuration["VnPay:ReturnUrl"]?.Trim();

        string orderId = string.IsNullOrWhiteSpace(model.OrderId)
            ? (DateTime.UtcNow.Ticks % 1000000000).ToString()
            : model.OrderId;

        var nowVN = GetVietnamTime();

        // Create instance of PayLib
        VNLibrary pay = new VNLibrary();

        // Add request data for VnPay payment request
        pay.AddRequestData("vnp_Version", "2.1.0");
        pay.AddRequestData("vnp_Command", "pay");
        pay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
        pay.AddRequestData("vnp_Amount", ((long)(model.Amount * 100)).ToString());
        pay.AddRequestData("vnp_BankCode", "");
        pay.AddRequestData("vnp_CreateDate", nowVN.ToString("yyyyMMddHHmmss"));
        pay.AddRequestData("vnp_CurrCode", "VND");
        pay.AddRequestData("vnp_IpAddr", ipAddress);
        pay.AddRequestData("vnp_Locale", "vn");
        pay.AddRequestData("vnp_OrderInfo", $"Thanh toan don hang {orderId}");
        pay.AddRequestData("vnp_OrderType", "other");
        pay.AddRequestData("vnp_ReturnUrl", vnp_ReturnUrl);
        pay.AddRequestData("vnp_TxnRef", orderId);
        pay.AddRequestData("vnp_ExpireDate", nowVN.AddMinutes(15).ToString("yyyyMMddHHmmss"));

        // Generate the payment URL with the request data and secure hash
        return pay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
    }

    public static bool ValidateSignature(string rspraw, string inputHash, string secretKey)
    {
        string myChecksum = VNLibrary.HmacSHA512(secretKey, rspraw);
        return myChecksum.Equals(inputHash, StringComparison.InvariantCultureIgnoreCase);
    }
}
