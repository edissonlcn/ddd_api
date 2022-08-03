using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.Profile
{
    public class ProfileGroupCreateDto
    {
        [Required]
        public Guid Id { get; set; }
    }
}
