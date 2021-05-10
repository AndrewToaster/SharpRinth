using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SharpRinth.Utility
{
    public static class DateTimeRFC3339
    {
        public static string FromDateTime(DateTime time)
        {
            return XmlConvert.ToString(time, XmlDateTimeSerializationMode.RoundtripKind);
        }

        public static DateTime FromString(string time)
        {
            return XmlConvert.ToDateTime(time, XmlDateTimeSerializationMode.RoundtripKind);
        }

        public static string ToRFC3339(this DateTime time)
        {
            return FromDateTime(time);
        }
    }
}
