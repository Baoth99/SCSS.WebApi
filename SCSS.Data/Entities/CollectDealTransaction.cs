﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCSS.Data.Entities
{
    [Table("CollectDealTransaction")]
    public class CollectDealTransaction : BaseEntity, IHasSoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string TransactionCode { get; set; }

        [ForeignKey("Account")]
        public Guid? DealerAccountId { get; set; }

        [ForeignKey("Account")]
        public Guid? CollectorAccountId { get; set; }

        public long? Total { get; set; }

        public long? TransactionServiceFee { get; set; }

        public long? BonusAmount { get; set; }

        public float? AwardPoint { get; set; }

        public bool IsDeleted { get; set; }
    }
}
