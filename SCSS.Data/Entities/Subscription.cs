﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCSS.Data.Entities
{
    [Table("Subscription")]
    public class Subscription : BaseEntity, IHasSoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("DealerInformation")]
        public Guid? DealerInformationId { get; set; }

        [ForeignKey("ServicePack")]
        public Guid? ServicePackId { get; set; }

        public DateTime? FromTime { get; set; }

        public DateTime? ToTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
