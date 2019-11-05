using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    class SpecialTag : tag
    {
        private string ubicacion;
        private string direccion;
        private string fotografo;
        private string estilo;
        private bool favorito;

        public SpecialTag(string ubicacion, string direccion, string fotografo, string estilo, bool favorito, string name) : base(name)
        {
            this.Ubicacion = ubicacion;
            this.Direccion = direccion;
            this.Fotografo = fotografo;
            this.Estilo = estilo;
            this.Favorito = favorito;
        }

        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Fotografo { get => fotografo; set => fotografo = value; }
        public string Estilo { get => estilo; set => estilo = value; }
        public bool Favorito { get => favorito; set => favorito = value; }
    }
}
