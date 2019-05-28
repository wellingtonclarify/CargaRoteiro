using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaRoteiro
{
    public class PlanejadoVsRealizadoRoteiro : BaseLongIdTenancyLoggable
    {
        public long PlanejadoVsRealizadoId { get; set; }
        //public virtual PlanejadoVsRealizado PlanejadoVsRealizado { get; set; }

        public string CEPD { get; set; }
        public string CEPE { get; set; }
        public string Logradouro { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public int OrdemRoteiro { get; set; }
        public DateTime HorarioPlanejado { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

        public DateTime? HorarioPassagem { get; set; }
        public decimal? LongitudePassagem { get; set; }
        public decimal? LatitudePassagem { get; set; }
        public decimal? DistanciaPassagem { get; set; }
    }
}
