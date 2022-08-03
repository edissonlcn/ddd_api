using System;

namespace APIMobileProduct.Domain.Models
{
    public class EventTypeModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private int _tipogeometria;
        public int TipoGeometria
        {
            get { return _tipogeometria; }
            set { _tipogeometria = value; }
        }



        private byte[] _file;
        public byte[] File
        {
            get { return _file; }
            set { _file = value; }
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
        private DateTime? _updateAt;
        public DateTime? UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }
    }
}
