using System;

namespace APIMobileProduct.Domain.Models
{
    public class UserModel
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
        private Guid _groupId;
        public Guid GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
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
