using System;
namespace Monilyzer
{
    /// <summary>
    ///     Provides Helper functions for working with DateTime.
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        ///     Returns UTC 1970/01/01 00:00:00.000
        /// </summary>
        public static DateTime DefaultDateTime => new DateTime(1970, 01, 01, 00, 00, 00, DateTimeKind.Utc);

        /// <summary>
        ///     Returns UTC 9999/12/31 23:59:59.999
        /// </summary>
        public static DateTime MaxDateTime => new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Utc);

        /// <summary>
        ///     Returns the Epoch of a DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        public static int Epoch(DateTime dateTime)
        {
            var epoch = new DateTime(1970, 01, 01, 00, 00, 00, DateTimeKind.Utc);
            return (int)dateTime.Subtract(epoch).TotalSeconds;
        }
    }

}
