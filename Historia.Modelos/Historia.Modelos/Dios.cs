using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historia.Modelos
{
    public class Dios
    {
        public int Id { get; set; }
        public string ?NombreDivino { get; set; }
        public string NombrePopular { get; set; }
        public string ?Elemento { get; set; }
        public string ?Descripcion { get; set; }

        //Atributos de navegacion
        public int MitologiaId { get; set; }

        //Relaciones
        public Mitologia? Mitologia { get; set; }

    }
}
