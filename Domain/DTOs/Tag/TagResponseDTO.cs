﻿using System.ComponentModel.DataAnnotations;

namespace DocumentinAPI.Domain.DTOs.Tag
{
    public class TagResponseDTO
    {

        public int TagId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }

    }
}
