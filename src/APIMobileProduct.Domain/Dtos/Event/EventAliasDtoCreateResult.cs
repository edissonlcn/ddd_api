using System;

namespace APIMobileProduct.Domain.Dtos.Event
{
    public class EventAliasDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Field { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
