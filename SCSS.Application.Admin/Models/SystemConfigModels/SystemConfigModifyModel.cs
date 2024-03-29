﻿using SCSS.Utilities.Constants;
using SCSS.Validations.ValidationAttributes.CommonValidations;

namespace SCSS.Application.Admin.Models.SystemConfigModels
{
    public class SystemConfigModifyModel
    {
        public int CancelTimeRange { get; set; }

        public int TimeRangeRequestNow { get; set; }

        public int RequestQuantity { get; set; }

        public int MaxNumberOfRequestDays { get; set; }

        public int ReceiveQuantity { get; set; }

        public int FeedbackDeadline { get; set; }

        [TimeSpanValidation(isCompareToNow: BooleanConstants.FALSE)]
        public string OperatingTimeFrom{ get; set; }

        [TimeSpanValidation(isCompareToNow: BooleanConstants.FALSE)]
        public string OperatingTimeTo{ get; set; }

        public float? NearestDistance { get; set; }

        public float? NearestDistanceOfAppointment { get; set; }

        public float? PriorityRating { get; set; }

        public double AvailableRadius { get; set; }
    }
}
