using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    class Icono
    {
        private Imagen foto;
        private int ancho;
        private int alto;

        public Icono(Imagen foto, int ancho, int alto)
        {
            this.foto = foto;
            this.ancho = ancho;
            this.alto = alto;

        }

        public int Ancho { get => ancho; set => ancho = value; }
        public Imagen Foto { get => foto; set => foto = value; }
        public int Alto { get => alto; set => alto = value; }
    }
}
