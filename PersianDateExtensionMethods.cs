using System;
using System.Globalization;
using System.Reflection;

namespace System
{
    public static class PersianDateExtensionMethods
    {
        private static CultureInfo _Culture;
        public static CultureInfo GetPersianCulture()
        {
            if (_Culture == null)
            {
                _Culture = new CultureInfo("fa-IR");

                System.Globalization.Calendar cal = new PersianCalendar();

                DateTimeFormatInfo formatInfo = _Culture.DateTimeFormat;

                formatInfo.AbbreviatedDayNames = new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
                formatInfo.DayNames = new[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهار شنبه", "پنجشنبه", "جمعه", "شنبه" };
                formatInfo.AbbreviatedMonthNames
                = formatInfo.MonthNames
                = formatInfo.MonthGenitiveNames
                = formatInfo.AbbreviatedMonthGenitiveNames
                = new[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };

                formatInfo.AMDesignator = "ق.ظ";
                formatInfo.PMDesignator = "ب.ظ";

                formatInfo.ShortDatePattern = "yyyy/MM/dd";
                formatInfo.LongDatePattern = "dddd, dd MMMM,yyyy";

                formatInfo.FirstDayOfWeek = DayOfWeek.Saturday;

                FieldInfo fieldInfo = _Culture.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
                if (fieldInfo != null)
                    fieldInfo.SetValue(_Culture, cal);

                FieldInfo info = formatInfo.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
                if (info != null)
                    info.SetValue(formatInfo, cal);

                _Culture.NumberFormat.NumberDecimalSeparator = "/";
                _Culture.NumberFormat.DigitSubstitution = DigitShapes.NativeNational;
                _Culture.NumberFormat.NumberNegativePattern = 0;
            }

            return _Culture;
        }

        public static string ToPersianDateString(this DateTime date)
        {
            string format = "yyyy/MM/dd HH:mm:ss";
            return date.ToLocalTime().ToString(format, GetPersianCulture());
        }
    }
}
