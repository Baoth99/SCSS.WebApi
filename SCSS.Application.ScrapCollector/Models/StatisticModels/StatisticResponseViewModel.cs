﻿
namespace SCSS.Application.ScrapCollector.Models.StatisticModels
{
    public class StatisticResponseViewModel
    {
        public long TotalCollecting { get; set; }

        public long TotalSale { get; set; }

        public int TotalCompletedCR { get; set; }

        public int TotalCancelCR { get; set; }
    }
}
