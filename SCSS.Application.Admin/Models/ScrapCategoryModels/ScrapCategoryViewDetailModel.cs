﻿using System.Collections.Generic;

namespace SCSS.Application.Admin.Models.ScrapCategoryModels
{
    public class CollectorScrapCategoryViewDetailModel
    {
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public int? Status { get; set; }

        public string ImageUrl { get; set; }

        public int Role { get; set; }

        public string CreatedTime { get; set; }

        public string UpdatedTime { get; set; }

        public List<ScrapCategoryDetailViewItemModel> Items { get; set; }
    }


    public class DealerScrapCategoryViewDetailModel
    {
        public string Name { get; set; }

        public string DealerName { get; set; }

        public string ManageBy { get; set; }

        public string CreatedBy { get; set; }

        public int? Status { get; set; }

        public string ImageUrl { get; set; }

        public int Role { get; set; }

        public string CreatedTime { get; set; }

        public string UpdatedTime { get; set; }

        public List<ScrapCategoryDetailViewItemModel> Items { get; set; }
    }

    public class ScrapCategoryDetailViewItemModel
    {
        public string Unit { get; set; }

        public long? Price { get; set; }

        public int? Status { get; set; }

        public string UpdatedTime { get; set; }
    }
}
