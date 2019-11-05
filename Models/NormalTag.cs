using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    class NormalTag : tag
    {
        private Persona[] personas;
        private Archivo foto;

        public NormalTag(Persona[] personas, Archivo foto, string name) : base(name)
        {
            this.personas = personas;
            this.foto = foto;

        }
    }
}
