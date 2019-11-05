using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Filtros
    {
        private List<string> caracteristicas;
        private List<Persona> personas;
        private List<tag> tags;
        private List<string> characteristic;
        private List<string> saturation;
        private List<string> resolution;
        private List<string> aspectratio;
        private List<int> rating;
        private List<Imagen> fotos;
        private List<string> filters;


        public Filtros()
        {

        }
        public Filtros(List<string> caracteristicas, List<Persona> personas, List<tag> tags, List<Imagen> fotos)
        {
            this.caracteristicas = caracteristicas;
            this.personas = personas;
            this.tags = tags;
            this.fotos = fotos;
        }

        public List<string> Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
        public List<Persona> Personas { get => personas; set => personas = value; }
        public List<tag> Tags { get => tags; set => tags = value; }
        public List<Imagen> Fotos { get => fotos; set => fotos = value; }
        public List<string> Filters { get => filters; set => filters = value; }
        public List<string> Characteristic { get => characteristic; set => characteristic = value; }
        public List<string> Saturation { get => saturation; set => saturation = value; }
        public List<string> Resolution { get => resolution; set => resolution = value; }
        public List<string> Aspectratio { get => aspectratio; set => aspectratio = value; }
        public List<int> Rating { get => rating; set => rating = value; }

        public Imagen agregarBusqueda(Imagen foto, List<Imagen> busqueda)
        {
            foreach (Imagen im in busqueda)
            {
                if (im == foto)
                {
                    return im;
                }
                else
                {
                    Console.WriteLine("No se pudo encontrar la imagen");
                }
            }
            return null;
        }
    }
}
