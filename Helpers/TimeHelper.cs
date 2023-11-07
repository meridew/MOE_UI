using System;
using System.Data;

namespace MOE_UI.Helpers
{
    internal static class TimeHelper
    {
        public static DateTime ConvertToUtc(string region, DateTime localDateTime)
        {
            TimeZoneInfo timeZone;

            switch (region)
            {
                case "AMRS":
                case "AMRS2":
                case "AMRS3":
                    timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    break;
                case "APAC":
                    timeZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
                    break;
                case "EMEA":
                    timeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
                    break;
                default:
                    throw new ArgumentException($"Unsupported region: {region}");
            }

            return TimeZoneInfo.ConvertTimeToUtc(localDateTime, timeZone);
        }
    }
}
