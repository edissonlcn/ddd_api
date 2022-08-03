using System;

namespace APIMobileProduct.Domain.Models
{
    public class PermitModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private Guid _functionId;
        public Guid FunctionId
        {
            get { return _functionId; }
            set { _functionId = value; }
        }

        private Guid _profileId;
        public Guid ProfileId
        {
            get { return _profileId; }
            set { _profileId = value; }
        }

        private bool _consultar;
        public bool Consultar
        {
            get { return _consultar; }
            set { _consultar = value; }
        }

        private bool _cadastrar;
        public bool Cadastrar
        {
            get { return _cadastrar; }
            set { _cadastrar = value; }
        }

        private bool _editar;
        public bool Editar
        {
            get { return _editar; }
            set { _editar = value; }
        }

        private bool _deletar;
        public bool Deletar
        {
            get { return _deletar; }
            set { _deletar = value; }
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
