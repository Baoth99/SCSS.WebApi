﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSS.Utilities.Constants
{
    public class CollectionConstants
    {
        public static readonly List<int> AccountStatusCollection = new List<int>()
        {
            AccountStatus.NOT_APPROVED,
            AccountStatus.ACTIVE,
            AccountStatus.BANNING,
        };

        public static readonly List<string> FileS3PathCollection = new List<string>()
        {
            FileS3Path.AdminAccountImages.ToString(),
            FileS3Path.CollectorAccountImages.ToString(),
            FileS3Path.DealerAccountImages.ToString(),
            FileS3Path.SellerAccountImages.ToString(),
            FileS3Path.ScrapCategoryImages.ToString(),
            FileS3Path.DealerInformationImages.ToString(),
            FileS3Path.ImageSliderImages.ToString()
        };


        public static readonly List<string> ImageExtensions = new List<string>()
        {
            ImageFileConstants.JPEG,
            ImageFileConstants.JPG,
            ImageFileConstants.PNG
        };

        public static readonly List<int> CollectingRequestStatusCollection = new List<int>()
        {
            CollectingRequestStatus.PENDING,
            CollectingRequestStatus.CANCEL_BY_SELLER,
            CollectingRequestStatus.CANCEL_BY_COLLECTOR,
            CollectingRequestStatus.APPROVED,
            CollectingRequestStatus.COMPLETED
        };

        public static readonly List<int> GenderCollection = new List<int>()
        {
            Gender.FEMALE,
            Gender.MALE
        };

        public static int[] PromotionStatusCollection => new int[2]
        {
            PromotionStatus.ACTIVE,
            PromotionStatus.DEACTIVE
        };
            

        public static readonly string[] VietnameseSigns = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public static List<T> Empty<T>() => Enumerable.Empty<T>().ToList();
    }

    public class DictionaryConstants
    {      

        public static readonly Dictionary<string, int> AccountStatusCollection = new Dictionary<string, int>()
        {
            {AccountRoleConstants.ADMIN, AccountRole.ADMIN },
            {AccountRoleConstants.SELLER, AccountRole.SELLER },
            {AccountRoleConstants.DEALER, AccountRole.DEALER },
            {AccountRoleConstants.COLLECTOR, AccountRole.COLLECTOR },
            {AccountRoleConstants.DEALER_MEMBER, AccountRole.DEALER_MEMBER }
        };

    }
}
