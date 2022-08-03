using System;

namespace APIMobileProduct.Domain.Dtos.Event
{
    public class EventAliasDtoUpdate
    {
        public Guid Id { get; set; }
        public string Field { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public Guid CompanyId { get; set; }
    }
}
