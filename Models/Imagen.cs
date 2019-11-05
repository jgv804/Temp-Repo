using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;

namespace Models
{
    [Serializable]
    public class Imagen : Archivo
    {

        private int id, ranking;
        private List<tag> tags, personas;
        private List<Persona> persona;
        private List<string> chara;
        private string fecha, camara, resolucion, saturacion, relacionaspecto, genero;
        private string rating;
        private bool favorito;
        //[XmlIgnore]//
        //private Image image;//
        public Imagen()
        {

        }
        public Imagen(string nombre, string direccionmemoria, int id, int ranking, List<tag> tags, List<tag> personas, string fecha, string camara, string resolucion, string saturacion, string relacionaspecto, string genero, bool favorito) : base(nombre, direccionmemoria)
        {
            this.id = id;
            this.ranking = ranking;
            this.tags = tags;
            this.personas = personas;
            this.fecha = fecha;
            this.camara = camara;
            this.resolucion = resolucion;
            this.saturacion = saturacion;
            this.relacionaspecto = relacionaspecto;
            this.genero = genero;
            this.favorito = favorito;
        }
        public Imagen(string nombre, string direccionmemoria) : base(nombre, direccionmemoria)
        {

        }


        public int Id { get => id; set => id = value; }
        //public Image Image { get => image; set => image = value; }//

        public List<tag> Tags { get => tags; set => tags = value; }
        public List<tag> Personas { get => personas; set => personas = value; }
        public int Ranking { get => ranking; set => ranking = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Camara { get => camara; set => camara = value; }
        public string Resolucion { get => resolucion; set => resolucion = value; }
        public string Saturacion { get => saturacion; set => saturacion = value; }
        public string Realcionaspecto { get => relacionaspecto; set => relacionaspecto = value; }
        public string Genero { get => genero; set => genero = value; }
        public bool Favorito { get => favorito; set => favorito = value; }
        public List<Persona> Persona { get => persona; set => persona = value; }
        public List<string> Chara { get => chara; set => chara = value; }
        public string Rating { get => rating; set => rating = value; }

        public Image GetImage()
        {
            Image O = Image.FromFile(this.Direccionmemoria);
            return O;
        }
    }
}
