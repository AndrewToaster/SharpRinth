using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SharpRinth.Utility
{
    /// <summary>
    /// Utility class for converting RFC3339-formatted <see cref="string"/>s and <see cref="DateTime"/>
    /// </summary>
    public static class DateTimeRFC3339
    {
        /// <summary>
        /// Returns RFC3339-formatted <see cref="string"/> of the <paramref name="time"/>
        /// </summary>
        /// <param name="time">The time to convert</param>
        public static string FromDateTime(DateTime time)
        {
            return XmlConvert.ToString(time, XmlDateTimeSerializationMode.RoundtripKind);
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> from a RFC3339-formatted <see cref="string"/>
        /// </summary>
        /// <param name="time">The time to convert</param>
        public static DateTime FromString(string time)
        {
            return XmlConvert.ToDateTime(time, XmlDateTimeSerializationMode.RoundtripKind);
        }

        /// <summary>
        /// Returns RFC3339-formatted <see cref="string"/> of the <paramref name="time"/>
        /// </summary>
        /// <param name="time">The time to convert</param>
        public static string ToRFC3339(this DateTime time)
        {
            return FromDateTime(time);
        }
    }
}
