﻿
namespace SCSS.Application.ScrapCollector.Models.AccountModels
{
    public class CollectorAccountUpdateRequestModel
    {
        public string Name { get; set; }

        public string BirthDate { get; set; }

        public string ImageUrl { get; set; }

        public int Gender { get; set; }

        public string Email { get; set; }
    }
}
