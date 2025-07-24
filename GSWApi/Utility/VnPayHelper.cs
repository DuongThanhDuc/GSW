using DataAccess.DTOs;
using System.Text;
using System.Web; 

public class VnPayHelper
{
    public static DateTime GetVietnamTime()
    {
        var tz = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
    }

    public static string CreatePaymentUrl(PaymentRequestDTO model, IConfiguration configuration, string ipAddress)
    {
        var vnp_TmnCode = configuration["VnPay:TmnCode"]?.Trim();
        var vnp_HashSecret = configuration["VnPay:HashSecret"]?.Trim();
        var vnp_Url = configuration["VnPay:Url"]?.Trim();
        var vnp_ReturnUrl = configuration["VnPay:ReturnUrl"]?.Trim();

        string orderId = string.IsNullOrWhiteSpace(model.OrderId) ? Guid.NewGuid().ToString("N").Substring(0, 10) : model.OrderId;
        var nowVN = GetVietnamTime();

        var pay = new Dictionary<string, string>
        {
            {"vnp_Version", "2.1.0"},
            {"vnp_Command", "pay"},
            {"vnp_TmnCode", vnp_TmnCode},
            {"vnp_Amount", ((long)(model.Amount * 100)).ToString()},
            {"vnp_CreateDate", nowVN.ToString("yyyyMMddHHmmss")},
            {"vnp_CurrCode", "VND"},
            {"vnp_IpAddr", ipAddress},
            {"vnp_Locale", "vn"},
            {"vnp_OrderInfo", $"Thanh toan don hang {orderId}"},
            {"vnp_OrderType", "other"},
            {"vnp_ReturnUrl", vnp_ReturnUrl},
            {"vnp_TxnRef", orderId},
            {"vnp_ExpireDate", nowVN.AddMinutes(15).ToString("yyyyMMddHHmmss")}
        };

        // Chuẩn: GHÉP query ENCODE value theo application/x-www-form-urlencoded (VNPAY yêu cầu)
        var sorted = pay.Where(x => !string.IsNullOrEmpty(x.Value)).OrderBy(x => x.Key).ToList();
        var query = string.Join("&", sorted.Select(x => $"{x.Key}={HttpUtility.UrlEncode(x.Value, Encoding.UTF8)}"));
        var signData = string.Join("&", sorted.Select(x => $"{x.Key}={x.Value}"));

        var hash = CreateHmacSHA512(vnp_HashSecret, signData);

        Console.WriteLine("======== VNPAY SIGNDATA ========");
        Console.WriteLine("signData: " + signData);
        Console.WriteLine("hash: " + hash);
        Console.WriteLine("paymentUrl: " + $"{vnp_Url}?{query}&vnp_SecureHash={hash}");
        Console.WriteLine("======== END ========");

        return $"{vnp_Url}?{query}&vnp_SecureHash={hash}";
    }

    public static string CreateHmacSHA512(string key, string input)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.UTF8.GetBytes(key)))
        {
            var bytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }

    public static bool ValidateVnpaySignature(IQueryCollection query, string hashSecret)
    {
        var data = query
            .Where(kv => kv.Key.StartsWith("vnp_")
                && kv.Key != "vnp_SecureHash"
                && kv.Key != "vnp_SecureHashType")
            .OrderBy(kv => kv.Key)
            .ToDictionary(kv => kv.Key, kv => kv.Value.ToString());

        var signData = string.Join("&", data.Select(x => $"{x.Key}={x.Value}"));
        var vnp_SecureHash = query["vnp_SecureHash"].ToString();
        var secureHash = CreateHmacSHA512(hashSecret, signData);

        Console.WriteLine("signData: " + signData);
        Console.WriteLine("hash (re-calc): " + secureHash);
        Console.WriteLine("hash (VNPAY): " + vnp_SecureHash);

        return string.Equals(secureHash, vnp_SecureHash, StringComparison.InvariantCultureIgnoreCase);
    }

    public static string GetClientIpAddress(HttpContext httpContext)
    {
        if (httpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
        {
            var xForwardedFor = httpContext.Request.Headers["X-Forwarded-For"].ToString();
            if (!string.IsNullOrEmpty(xForwardedFor))
                return xForwardedFor.Split(',')[0].Trim();
        }
        var remoteIp = httpContext.Connection.RemoteIpAddress;
        if (remoteIp != null)
            return remoteIp.MapToIPv4().ToString();
        return "0.0.0.0";
    }
}
