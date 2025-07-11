﻿using System;
using System.Collections.Concurrent;

namespace GSWApi.Utility
{
    public class OtpEntry
    {
        public string Otp { get; set; }
        public DateTime ExpireAt { get; set; }
    }

    public static class OtpManager
    {
        // Email -> OtpEntry
        private static ConcurrentDictionary<string, OtpEntry> otpStore = new();

        public static string GenerateOtp(string email, int digits = 6)
        {
            var rnd = new Random();
            string otp = rnd.Next(0, (int)Math.Pow(10, digits)).ToString($"D{digits}");
            otpStore[email] = new OtpEntry { Otp = otp, ExpireAt = DateTime.Now.AddMinutes(5) };
            return otp;
        }

        public static bool VerifyOtp(string email, string otp)
        {
            if (otpStore.TryGetValue(email, out var entry))
            {
                if (entry.ExpireAt > DateTime.Now && entry.Otp == otp)
                {
                    otpStore.TryRemove(email, out _); // Xoá sau khi xác thực
                    return true;
                }
            }
            return false;
        }
    }
}
