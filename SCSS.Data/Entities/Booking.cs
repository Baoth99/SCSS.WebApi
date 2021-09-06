﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCSS.Data.Entities
{
    [Table("Booking")]
    public class Booking : BaseEntity, IHasSoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string BookingCode { get; set; }

        public DateTime? BookingDate { get; set; }

        public TimeSpan? TimeFrom { get; set; }

        public TimeSpan? TimeTo { get; set; }

        [ForeignKey("ItemType")]
        public Guid? ItemTypeId { get; set; }

        [ForeignKey("Location")]
        public Guid? LocationId { get; set; }

        [ForeignKey("Account")]
        public Guid? SellerAccountId { get; set; }

        [ForeignKey("Account")]
        public Guid? CollectorAccountId { get; set; }

        public bool IsBulky { get; set; }

        public string ScrapImageUrl { get; set; }

        public string Note { get; set; }

        public string CancelReason { get; set; }

        public int? Status { get; set; }

        public bool IsDeleted { get; set; }
    }
}

