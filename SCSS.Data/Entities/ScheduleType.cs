﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCSS.Data.Entities
{
    [Table("ScheduleType")]
    public class ScheduleType : IHasSoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeleteTime { get; set; }
    }
}
