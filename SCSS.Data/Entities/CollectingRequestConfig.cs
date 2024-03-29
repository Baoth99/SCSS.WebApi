﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCSS.Data.Entities
{
    [Table("CollectingRequestConfig")]
    public class CollectingRequestConfig : BaseEntity, IHasSoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int RequestQuantity { get; set; }

        public int ReceiveQuantity { get; set; }

        public int MaxNumberOfRequestDays { get; set; }

        public int CancelTimeRange { get; set; }

        public int TimeRangeRequestNow { get; set; }

        public int FeedbackDealine { get; set; }

        public TimeSpan? OperatingTimeFrom { get; set; }

        public TimeSpan? OperatingTimeTo { get; set; }

        public float? NearestDistance { get; set; }

        public float? NearestDistanceOfAppointment { get; set; }

        public float? PriorityRating { get; set; }

        public double AvailableRadius { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
