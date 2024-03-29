﻿using System;
using System.Collections.Generic;

namespace SCSS.Application.ScrapSeller.Models.ActivityModels
{
    public class ActivityDetailViewModel
    {
        public Guid Id { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedTime { get; set; }

        public string CollectingRequestCode { get; set; }

        public int? Status { get; set; }

        // Collector Information
        public CollectorInformation CollectorInfo { get; set; }

        // Collecting Request Information Detail
        public string AddressName { get; set; }

        public string Address { get; set; }

        public string CollectingRequestDate { get; set; }

        public string FromTime { get; set; }

        public string ToTime { get; set; }

        public string ApprovedDate { get; set; }

        public string ApprovedTime { get; set; }

        public bool IsBulky { get; set; }

        public string ScrapCategoryImageUrl { get; set; }

        public string Note { get; set; }

        public string CancelReasoin { get; set; }
        // Transaction Information
        public TransactionInformation Transaction { get; set; }

        public ComplaintViewModel Complaint { get; set; }

        public string DoneActivityDate { get; set; }

        public string DoneActivityTime { get; set; }

        public bool IsCancelable { get; set; }

    }

    public class CollectorInformation
    {
        public Guid? CollectorId { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public string  Phone { get; set; }

        public float? Rating { get; set; }
    }

    public class TransactionInformation
    {
        public Guid? TransactionId { get; set; }

        public string TransactionDate { get; set; }

        public string TransactionTime { get; set; }

        public long? Total { get; set; }

        public long? Fee { get; set; }

        public int? AwardPoint { get; set; }

        public FeedbackInformationResponse FeedbackInfo { get; set; }

        public List<TransactionInformationDetail> Details { get; set; }
    }

    public class FeedbackInformationResponse
    {
        public int FeedbackStatus { get; set; }

        public float? RatingFeedback { get; set; }
    }

    public class ComplaintViewModel
    {
        public Guid? ComplaintId { get; set; }

        public int ComplaintStatus { get; set; }

        public string ComplaintContent { get; set; }

        public string AdminReply { get; set; }
    }

    public class TransactionInformationDetail
    {
        public string ScrapCategoryName { get; set; }

        public float? Quantity { get; set; }

        public string Unit { get; set; }

        public long? Total { get; set; }
    }
}
