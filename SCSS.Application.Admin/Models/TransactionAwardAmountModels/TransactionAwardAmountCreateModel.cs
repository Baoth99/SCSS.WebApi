﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSS.Application.Admin.Models.TransactionAwardAmountModels
{
    public class TransactionAwardAmountCreateModel
    {
        public int AppliedObject { get; set; }

        public long AppliedAmount { get; set; }

        public float? Amount { get; set; }
    }
}
