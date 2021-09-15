﻿using SCSS.Utilities.Constants;
using System.Globalization;

namespace SCSS.Utilities.Extensions
{
    public static class NumberExtension
    {
        public static string ToMoney(this long? val, string culture = Globalization.VN_CULTURE)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo(culture);

            if (!val.HasValue)
            {
                return string.Format("{0}", CommonConstants.Null);
            }
            string result = val.Value.ToString("#,###", cul.NumberFormat);

            return string.Format("{0} vnđ", result);
        }
    }
}
