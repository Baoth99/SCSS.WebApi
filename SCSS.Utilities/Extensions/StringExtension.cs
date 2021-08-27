﻿using Newtonsoft.Json;
using SCSS.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace SCSS.Utilities.Extensions
{
    public static class StringExtension
    {

        public static TimeSpan? ToTimeSpan(this string timeString)
        {
            var isSucess = TimeSpan.TryParse(timeString, out TimeSpan time);          
            return isSucess ? time : null;
        }

        public static DateTime? ToDateTime(this string dateString)
        {
            var isSuccess = DateTime.TryParse(dateString, out DateTime datetime);

            return isSuccess ? datetime : null;
        }

        public static List<T> ToList<T>(this string jsonString)
        {
            return jsonString != null ? JsonConvert.DeserializeObject<List<T>>(jsonString) : CollectionConstants.Empty<T>();
        }

        public static Bitmap ToBitmap(this string base64String)
        {
            byte[] byteBuffer = Convert.FromBase64String(base64String);
            var memoryStream = new MemoryStream(byteBuffer);

            try
            {
                memoryStream.Position = 0;
                var bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);
                return bmpReturn;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                memoryStream.Close();
            }
        }
    }
}
