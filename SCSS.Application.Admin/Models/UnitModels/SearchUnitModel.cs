﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSS.Application.Admin.Models.UnitModels
{
    public class SearchUnitModel : BaseFilterModel
    {
        public string Name { get; set; }

        public string CreatedBy { get; set; }
    }
}
