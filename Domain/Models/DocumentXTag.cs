﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentinAPI.Domain.Models
{
    public class DocumentXTag
    {

        [Required]
        public int TagId { get; set; }

        [Required]
        public int DocumentId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }

        [ForeignKey(nameof(DocumentId))]
        public virtual Document Document { get; set; }

    }
}
