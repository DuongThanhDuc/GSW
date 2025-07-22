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
        public static string CreateSignature(Dictionary<string, string> rawData, string secretKey)
        {
            var raw = "partnerCode=" + rawData["partnerCode"]
                + "&accessKey=" + rawData["accessKey"]
                + "&requestId=" + rawData["requestId"]
                + "&amount=" + rawData["amount"]
                + "&orderId=" + rawData["orderId"]
                + "&orderInfo=" + rawData["orderInfo"]
                + "&returnUrl=" + rawData["returnUrl"]
                + "&notifyUrl=" + rawData["notifyUrl"]
                + "&extraData=" + rawData["extraData"];

            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(raw));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public static async Task<MomoPaymentResponseDTO> CreatePaymentAsync(
            string endpoint, string partnerCode, string accessKey, string secretKey, string returnUrl,
            string notifyUrl, string amount, string orderId, string orderInfo, string requestType)
        {
            var requestId = Guid.NewGuid().ToString();

            var rawData = new Dictionary<string, string>
            {
                { "accessKey", accessKey },
                { "amount", amount },
                { "extraData", "" },
                { "notifyUrl", notifyUrl }, 
                { "orderId", orderId },
                { "orderInfo", orderInfo },
                { "partnerCode", partnerCode },
                { "returnUrl", returnUrl }, 
                { "requestId", requestId },
                { "requestType", requestType }
            };

            string signature = CreateSignature(rawData, secretKey);

            var requestBody = new
            {
                partnerCode,
                accessKey,
                requestId,
                amount,
                orderId,
                orderInfo,
                returnUrl,   
                notifyUrl,   
                extraData = "",
                requestType,
                signature
            };

            // Debug/log request để kiểm tra
            Console.WriteLine("MOMO REQUEST BODY: " + JsonConvert.SerializeObject(requestBody));

            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(endpoint, content);
            var resString = await response.Content.ReadAsStringAsync();

            // Debug/log response để kiểm tra
            Console.WriteLine("MOMO RESPONSE: " + resString);

            return JsonConvert.DeserializeObject<MomoPaymentResponseDTO>(resString);
        }
    }
}
