using System;

namespace APIMobileProduct.Domain.Models
{
    public class EventAliasModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }

        }

        private string _field;
        public string Field
        {
            get { return _field; }
            set { _field = value; }
        }

        private string _label;
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private Guid _companyid;
        public Guid CompanyId
        {
            get { return _companyid; }
            set { _companyid = value; }
        }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }
        private DateTime? _updateAt;
        public DateTime? UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }
    }
}
