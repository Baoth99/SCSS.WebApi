﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SCSS.Application.Admin.Models.AccountModels
{
    public class AccountDetailViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int? Gender { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string BirthDate { get; set; }

        public string Image { get; set; }

        public int RoleKey { get; set; }

        public string RoleName { get; set; }

        public string IdCard { get; set; }

        public float? TotalPoint { get; set; }

        public string CreatedTime { get; set; }

        public int? Status { get; set; }

        [JsonIgnore]
        public string DeviceId { get; set; }
    }
}
