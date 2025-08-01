using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTOs;
using Newtonsoft.Json;

namespace GSWApi.Utility
{
    public static class MomoHelper
    {
        // Build raw string để ký cho API MoMo v3 (theo thứ tự tài liệu)
        public static string BuildRawSignatureMomoV3(
            string accessKey, string amount, string extraData, string ipnUrl,
            string orderId, string orderInfo, string partnerCode, string redirectUrl,
            string requestId, string requestType)
        {
            return $"accessKey={accessKey}"
                + $"&amount={amount}"
                + $"&extraData={extraData}"
                + $"&ipnUrl={ipnUrl}"
                + $"&orderId={orderId}"
                + $"&orderInfo={orderInfo}"
                + $"&partnerCode={partnerCode}"
                + $"&redirectUrl={redirectUrl}"
                + $"&requestId={requestId}"
                + $"&requestType={requestType}";
        }

        // Tạo signature
        public static string CreateSignature(string rawData, string secretKey)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        // Gọi API tạo payment
        public static async Task<MomoPaymentResponseDTO> CreatePaymentAsync(
            string endpoint, string partnerCode, string accessKey, string secretKey, string redirectUrl,
            string ipnUrl, long amount, string orderId, string orderInfo, string requestType)
        {
            var requestId = Guid.NewGuid().ToString();
            var extraData = ""; // base64 nếu cần, còn không để trống

            var rawData = BuildRawSignatureMomoV3(
                accessKey, amount.ToString(), extraData, ipnUrl,
                orderId, orderInfo, partnerCode, redirectUrl, requestId, requestType
            );
            var signature = CreateSignature(rawData, secretKey);

            var requestBody = new
            {
                partnerCode,
                requestId,
                amount = amount,
                orderId,
                orderInfo,
                redirectUrl,
                ipnUrl,
                extraData,
                requestType,
                signature
            };

            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(endpoint, content);
            var resString = await response.Content.ReadAsStringAsync();

            Console.WriteLine("MOMO REQUEST BODY: " + JsonConvert.SerializeObject(requestBody));
            Console.WriteLine("MOMO RESPONSE: " + resString);

            return JsonConvert.DeserializeObject<MomoPaymentResponseDTO>(resString);
        }
    }
}
