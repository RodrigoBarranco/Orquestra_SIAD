using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data;
using System.ComponentModel;

namespace Orquestra3_SIAD.Util
{
    public static class Parse
    {

        public static string Sanitize(string stringToClean)
        {
            stringToClean = stringToClean.Replace(",", "");
            stringToClean = stringToClean.Replace("?", "");
            stringToClean = stringToClean.Replace(":", "");
            stringToClean = stringToClean.Replace("&", "");
            stringToClean = stringToClean.Replace("=", "");
            stringToClean = stringToClean.Replace("|", "");
            stringToClean = stringToClean.Replace("+", "");
            stringToClean = stringToClean.Replace("%", "");
            stringToClean = stringToClean.Replace("#", "");
            stringToClean = stringToClean.Replace("@", "");
            stringToClean = stringToClean.Replace("\"", "");
            stringToClean = stringToClean.Replace("\'", "");
            stringToClean = stringToClean.Replace("(", "");
            stringToClean = stringToClean.Replace(")", "");
            stringToClean = stringToClean.Replace("!", "");
            stringToClean = stringToClean.Replace("$", "");
            stringToClean = stringToClean.Replace("*", "");
            stringToClean = stringToClean.Replace("<", "");
            stringToClean = stringToClean.Replace(">", "");
            
            stringToClean = stringToClean.Replace(";", "");
            stringToClean = stringToClean.Replace("~", "");
            
            stringToClean = stringToClean.Replace("'", "");
            stringToClean = stringToClean.Replace("\"", "");
            stringToClean = stringToClean.Replace("/", "");
            stringToClean = stringToClean.Trim();
            stringToClean = Regex.Replace(stringToClean, @"\s+", "-"); // trocar espaços por hífen

            string stFormD = stringToClean.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }

            return (sb.ToString());
        }

        public static System.Guid ToGuid(object s)
        {
            if (s != null && s.ToString() != "")
                return (System.Guid)(s);
            return Guid.Empty;
        }

        public static System.Guid ToGuid(string s)
        {
            return Guid.Parse(s);
        }

        public static string ToString(object s)
        {
            if (s != null && !Convert.IsDBNull(s) && s.ToString() != "")
            {
                return Convert.ToString(s);
            }
            else
            {
                return "";
            }
        }

        public static double ToDouble(object s)
        {
            if (s != null && !Convert.IsDBNull(s) && s.ToString() != "")
            {
                return Convert.ToDouble(s);
            }
            else
            {
                return 0;
            }
        }

        public static decimal ToDecimal(object s)
        {
            if (s != null && !Convert.IsDBNull(s) && s.ToString() != "")
            {
                return Convert.ToDecimal(s);
            }
            else
            {
                return 0;
            }
        }

        public static decimal ToMoney(object s, CultureInfo culture)
        {

            if (s != null && !Convert.IsDBNull(s) && s.ToString() != "")
            {
                return Convert.ToDecimal(s, culture);
            }
            else
            {
                return 0;
            }
        }

        public static decimal ToMoney(object s)
        {
            if (s != null && !Convert.IsDBNull(s) && s.ToString() != "")
            {
                return Convert.ToDecimal(s);
            }
            else
            {
                return 0;
            }
        }

        public static int ToInt(object s)
        {
            if (s != null && !Convert.IsDBNull(s) && s.ToString() != "")
                return Convert.ToInt32(s.ToString());
            else
                return int.MinValue;


        }

        public static bool ToBool(object s)
        {
            if (s != null && !Convert.IsDBNull(s) && s.ToString() != "")
                return Convert.ToBoolean(s);
            else
                return false;
        }

        public static bool ToBool(int s)
        {
            if (s == 0)
                return false;
            else
                return true;
        }


        public static System.DateTime ToDateTimeParse(string s)
        {
            if (s != null && !Convert.IsDBNull(s) && s.ToString() != "")
            {
                System.DateTime newDateTime;
                s = s.Replace("PST", "-8");
                s = s.Replace("PDT", "-7");
                if (System.DateTime.TryParse(s, out newDateTime))
                {
                    return newDateTime;
                }
                return System.DateTime.MinValue;
            }
            else
            {
                return System.DateTime.MinValue;
            }
        }

        public static System.DateTime ToDateTime(object s)
        {
            if (s != null && !Convert.IsDBNull(s) && s.ToString() != "")
                return Convert.ToDateTime(s);
            else
                return System.DateTime.MinValue;
        }


        public static string ToDateTimeISO8601(System.DateTime d)
        {
            return d.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
        }

        public static string ToDateTimeICal(System.DateTime d)
        {
            return d.ToString("yyyyMMddTHHmmssZ");
        }

        public static System.DateTime ToDateTime(TimeSpan s)
        {
            if (s != null && !Convert.IsDBNull(s) && s.ToString() != "")
                return new System.DateTime(s.Ticks);
            else
                return System.DateTime.MinValue;
        }

        public static System.TimeSpan ToTimeSpan(object s)
        {
            if (s != null && !Convert.IsDBNull(s) && s.ToString() != "")
                return TimeSpan.Parse(s.ToString());
            else
                return System.TimeSpan.MinValue;
        }

        public static System.TimeSpan ToTimeSpan(System.DateTime s)
        {
            return TimeSpan.FromTicks(s.Ticks);
        }

        public static bool IsNullOrEmpty(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsNullOrEmpty(object o)
        {
            if (o == null) return true;
            string s = o.ToString();
            if (String.IsNullOrEmpty(s))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static object StringOrNull(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return DBNull.Value;
            }
            else
            {
                return s;
            }
        }

        public static object IntOrNull(int i)
        {
            if (i == int.MinValue)
            {
                return DBNull.Value;
            }
            else
            {
                return i.ToString();
            }
        }

        public static object DecimalOrNull(decimal i)
        {
            if (i == decimal.MinValue)
            {
                return DBNull.Value;
            }
            else
            {
                return i.ToString();
            }
        }

        public static object GuidOrNull(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                return DBNull.Value;
            }
            else
            {
                return guid;
            }
        }

        public static object DateTimeOrNull(System.DateTime d)
        {
            if (d == System.DateTime.MinValue)
            {
                return DBNull.Value;
            }
            else
            {
                return d;
            }
        }

        public static bool IsNumeric(string val)
        {
            return IsNumeric(val, System.Globalization.NumberStyles.Integer);
        }

        public static bool IsNumeric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        public static System.DateTime FromUnixTimestamp(double timestamp)
        {
            System.DateTime utc = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            utc = utc.AddSeconds(timestamp);
            utc = utc.AddSeconds(-utc.Second);
            return utc;
            //return origin;
        }

        public static double ToUnixTimestamp(System.DateTime date)
        {
            System.DateTime origin = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);//.AddHours(-3);
            TimeSpan diff = date - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        public static string Substring(string s, int length)
        {

            if (s.Length > length)
                s = s.Substring(0, length - 1);
            return s;
        }

        public static string Substring(string s, int length, string replacewith)
        {

            if (s.Length > length)
            {
                s = s.Substring(0, length - 1);
                s += replacewith;
            }
            return s;
        }

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static String BytesToString(long byteCount)
        {
            string[] suf = { "Bytes", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
        }

    }

}