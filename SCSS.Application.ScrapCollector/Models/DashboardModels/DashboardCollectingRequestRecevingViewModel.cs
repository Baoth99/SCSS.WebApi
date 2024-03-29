﻿using System;

namespace SCSS.Application.ScrapCollector.Models.DashboardModels
{
    public class DashboardCollectingRequestRecevingViewModel
    {
        public Guid Id { get; set; }

        public string CollectingRequestCode { get; set; }

        public string SellerName { get; set; }

        // Date
        public int? DayOfWeek { get; set; }

        public string CollectingRequestDate { get; set; }

        public string FromTime { get; set; }

        public string ToTime { get; set; }

        // Location
        public string CollectingAddressName { get; set; }

        public string CollectingAddress { get; set; }

        public bool IsBulky { get; set; }

        public int? RequestType { get; set; }

        public float Distance { get; set; }

        public string DistanceText { get; set; }

        public string DurationTimeText { get; set; }

        public float DurationTimeVal { get; set; }
    }
}
