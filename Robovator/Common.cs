using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robovator
{
    public static class Common
    {
        public static long getCurrentUTCTime()
        {
            TimeSpan span = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            long currentTimeUTC = (long)span.TotalSeconds;
            return currentTimeUTC;
        }

        public static long dateTimeToUtcTimeStamp(DateTime dateTime)
        {
            TimeSpan span = (dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            long currentTimeUTC = (long)span.TotalSeconds;
            return currentTimeUTC;
        }

        public static DateTime utcTimeStampToDateTime(long utcTimeStamp)
        {
            TimeSpan tmp = new TimeSpan(utcTimeStamp);
            return new DateTime((long)tmp.TotalMilliseconds);
        }
    }
}
