﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCSS.Data.Entities
{
    [Table("Feedback")]
    public class Feedback : BaseEntity, IHasSoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Account")]
        public Guid? SellingAccountId { get; set; }

        [ForeignKey("Account")]
        public Guid? BuyingAccountId { get; set; }

        public float? Rate { get; set; }

        [MaxLength(500)]
        public string SellingReview { get; set; }

        [MaxLength(500)]
        public string BuyingReview { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeleteTime { get; set; }
    }
}
