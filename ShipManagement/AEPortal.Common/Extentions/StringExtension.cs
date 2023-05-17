using System.Globalization;

namespace AEPortal.Common.Extentions
{
    public static class StringExtension
    {
        public static T ToEnum<T>(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return default;
            }
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public static DateTime ToDateTimeUTC(this string value, string hours, string format)
        {
            var result = DateTime.MinValue;
            if (double.TryParse(value, out double d) && !double.IsNaN(d) && !double.IsInfinity(d))
            {
                result = DateTime.FromOADate(double.Parse(value));
            }
            else
            {

                DateTime.TryParseExact(value, format, new CultureInfo("en-US"),
                       DateTimeStyles.None,
                       out result);
            }
            if (!string.IsNullOrEmpty(hours))
            {
                var time = DateTime.Parse(hours, CultureInfo.CurrentCulture);

                result = result.Add(time.TimeOfDay);
            }
            return result.ToUniversalTime();
        }
        public static decimal ToDecimal(this string value)
        {
            var result = decimal.Zero;
            decimal.TryParse(value, out result);
            return result;
        }
        public static int ToInt(this string value)
        {
            var result = 0;
            int.TryParse(value, out result);
            return result;
        }
    }
}
