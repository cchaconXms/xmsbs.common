using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.Exceptions
{
    [Serializable]
    public class NotFoundException<IDT> : Exception
    {
        public IDT Id { get; set; }
        public String TipoEntidad { get; set; }

        public NotFoundException()
        {
        }

        public NotFoundException(IDT id, string tipoEntidad) : base()
        {
            this.Id = id;
            this.TipoEntidad = tipoEntidad;
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public NotFoundException(string message, Exception inner, IDT id, string tipoEntidad)
            : base(message, inner)
        {
            this.Id = id;
            this.TipoEntidad = tipoEntidad;
        }

    }
}
