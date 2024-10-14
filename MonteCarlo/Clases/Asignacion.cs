using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo.Clases
{
    public class Asignacion
    {
        public int lim_inf { get; set; }
        public int lim_sup { get; set; }
        public int columnas { get; set; }
        public int n_iteraciones { get; set; }
        //public int resultadoOperacion { get; set; }
        //public int modResultado { get; set; }
        public Asignacion()
        {

        }
        public Asignacion (Asignacion asignacion)
        {
            lim_inf = asignacion.lim_inf;
            lim_sup = asignacion.lim_sup;
            columnas = asignacion.columnas;
            n_iteraciones=asignacion.n_iteraciones;

        }

    }


}
