using System;

namespace APIMobileProduct.Domain.Models
{
    public class BasemapModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private Guid _companyId;
        public Guid CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        private string _filename;
        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }


        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }
        private DateTime _updateAt;
        public DateTime UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }
    }
}
