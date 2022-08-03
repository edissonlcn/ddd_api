using System;
using System.ComponentModel.DataAnnotations;

namespace APIMobileProduct.Domain.Dtos.User
{
    public class UserDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Guid GroupId { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
