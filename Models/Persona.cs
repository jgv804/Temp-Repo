using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Persona
    {
        private int idPersona;
        private int[] nacimiento;
        private string nombre, sexo, nacionalidad, colorPE, colorPI, colorOJ;
        List<Imagen> fotos;
        //icono AVATAR

        public Persona()
        {

        }
        public Persona(int idPersona, int[] nacimiento, string nombre, string sexo, string nacionalidad, string colorPE, string colorPI, string colorOJ, List<Imagen> fotos)
        {
            this.idPersona = idPersona;
            this.nacimiento = nacimiento;
            this.nombre = nombre;
            this.sexo = sexo;
            this.nacionalidad = nacionalidad;
            this.colorPE = colorPE;
            this.colorPI = colorPI;
            this.colorOJ = colorOJ;
            this.fotos = fotos;
        }

        public int IdPersona { get => idPersona; set => idPersona = value; }
        public int[] Nacimiento { get => nacimiento; set => nacimiento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string ColorPE { get => colorPE; set => colorPE = value; }
        public string ColorPI { get => colorPI; set => colorPI = value; }
        public string ColorOJ { get => colorOJ; set => colorOJ = value; }
        public List<Imagen> Fotos { get => fotos; set => fotos = value; }

    }
}
