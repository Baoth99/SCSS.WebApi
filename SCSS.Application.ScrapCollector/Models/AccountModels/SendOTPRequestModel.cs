﻿using SCSS.Utilities.Constants;
using SCSS.Validations.ValidationAttributes.CommonValidations;

namespace SCSS.Application.ScrapCollector.Models.AccountModels
{
    public class SendOTPRequestModel
    {
        [ValidateRegex(RegularExpression.PhoneRegex)]
        public string Phone { get; set; }
    }
}
