﻿using SCSS.Utilities.Constants;
using SCSS.Validations.ValidationAttributes.CommonValidations;

namespace SCSS.Application.ScrapSeller.Models.AccountModels
{
    public class SendOTPRequestModel
    {
        [ValidateRegex(RegularExpression.PhoneRegex)]
        public string Phone { get; set; }
    }
}
