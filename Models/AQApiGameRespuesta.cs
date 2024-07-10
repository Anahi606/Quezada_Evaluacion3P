using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quezada_Evaluacion3P.Models
{
    public class AQApiGameRespuesta
    {
        public int Count { get; set; }
        public List<AQGame> Resultados { get; set; }
    }
}
