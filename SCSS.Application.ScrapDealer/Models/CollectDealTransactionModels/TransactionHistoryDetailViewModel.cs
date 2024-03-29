﻿
using System;
using System.Collections.Generic;

namespace SCSS.Application.ScrapDealer.Models.CollectDealTransactionModels
{
    public class TransactionHistoryDetailViewModel
    {
        public string CollectorName { get; set; }

        public string ProfileURL { get; set; }

        public int? Gender { get; set; }

        // Transaction
        public string TransactionCode { get; set; }

        public string TransactionDate { get; set; }

        public string TransactionTime { get; set; }

        public long? Total { get; set; }

        public long? TotalBonus { get; set; }

        public long? TransactionFee { get; set; }

        public List<TransactionHistoryScrapCategoryViewModel> ItemDetail { get; set; }

        public ComplaintViewModel Complaint { get; set; }
    }

    public class TransactionHistoryScrapCategoryViewModel
    {
        public string ScrapCategoryName { get; set; }

        public float? Quantity { get; set; }

        public string Unit { get; set; }

        public long? Total { get; set; }

        public bool IsBonus { get; set; }

        public long? BonusAmount { get; set; }
    }

    public class ComplaintViewModel
    {
        public Guid? ComplaintId { get; set; }

        public int ComplaintStatus { get; set; }

        public string ComplaintContent { get; set; }

        public string AdminReply { get; set; }
    }
}
