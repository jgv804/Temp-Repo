using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class tag
    {
        private string name;

        public tag()
        {

        }
        public tag(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }

    }
}
