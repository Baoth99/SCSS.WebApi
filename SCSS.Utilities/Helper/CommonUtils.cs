﻿using SCSS.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace SCSS.Utilities.Helper
{
    public class CommonUtils
    {

        public static Guid? CheckGuid(string guidString)
        {
            var isValid = Guid.TryParse(guidString, out Guid val);

            return isValid? val : Guid.Empty;
        }

        public static Dictionary<string, string> ObjToDictionary<T>(T obj)
        {
            var data = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                    .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj, null).ToString());

            return data;
        }

        public static T DictionaryToObject<T>(Dictionary<string, string> dic) where T : new()
        {
            T obj = new T();

            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                propertyInfo.SetValue(obj, dic[propertyInfo.Name]);
            }

            return obj;
        }

        public static int GetGender(string gender)
        {
            return gender == Gender.MALE_TEXT ? Gender.MALE : Gender.FEMALE;
        }

        public static int GetRole(string role)
        {
            return DictionaryConstants.AccountStatusCollection[role];
        }

        public static int GetDealerType(Guid? managedBy)
        {
            return ValidatorUtil.IsNull(managedBy) ? DealerType.LEADER : DealerType.MEMBER; // Leader is 1, Member is 1;
        }

        public static string GetFileName(PrefixFileName prefix, string fileNameEx)
        {
            return $"{prefix}-{DateTimeVN.DATETIME_NOW.ToString(DateTimeFormat.Format01)}-{fileNameEx.ToLower()}";
        }

        public static List<int> GetActivityStatus(int status)
        {
            return status switch
            {
                CollectingRequestStatus.PENDING => new List<int>() { CollectingRequestStatus.PENDING },
                CollectingRequestStatus.APPROVED => new List<int>() { CollectingRequestStatus.APPROVED },
                CollectingRequestStatus.COMPLETED => CollectionConstants.CompletedCRActivity,
                _ => CollectionConstants.Empty<int>(),
            };
        }

        public static string GetContentImageTypeString(string extension)
        {
            return extension switch
            {
                "png" => ContentTypeString.PngImageContentType,
                "jpg" => ContentTypeString.JpgImageContentType,
                "jpeg" => ContentTypeString.JpegImageContentType,
                _ => throw new ArgumentException("Image Extension is not valid !", nameof(extension)),
            };
        }

        public static int GetFeedbackToSystemStatus(int? collectingRequestStatus,
                                                    DateTime? approvedTime,
                                                    Guid? feedbackToSysId,
                                                    string adminReply)
        {
            if (collectingRequestStatus == CollectingRequestStatus.PENDING ||
                (collectingRequestStatus == CollectingRequestStatus.CANCEL_BY_SELLER) && ValidatorUtil.IsBlank(approvedTime))
            {
                return FeedbackToSystemStatus.CanNotGiveFeedback;
            }

            if (ValidatorUtil.IsNull(feedbackToSysId))
            {
                return FeedbackToSystemStatus.CanGiveFeedback;
            }

            if (!ValidatorUtil.IsNull(feedbackToSysId))
            {
                if (!ValidatorUtil.IsBlank(adminReply))
                {
                    return FeedbackToSystemStatus.AdminReplied;
                }
            }
            return FeedbackToSystemStatus.HaveGivenFeedback;
        }

    }
}
