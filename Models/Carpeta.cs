using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    class Carpeta : Archivo
    {
        private List<Archivo> archivos;

        public Carpeta(List<Archivo> archivos, string nombre, string direccionmemoria) : base(nombre, direccionmemoria)
        {
            this.archivos = archivos;
        }

        internal List<Archivo> Archivos { get => archivos; set => archivos = value; }
    }
}
