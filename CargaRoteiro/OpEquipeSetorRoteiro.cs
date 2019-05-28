using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaRoteiro
{
    public class OpEquipeSetorRoteiro : BaseLongIdTenancyLoggable
    {
        public long OpEquipeId { get; set; }
        //public virtual OpEquipe OpEquipe { get; set; }
        
        public string CEPD { get; set; }
        public string CEPE { get; set; }
        public string Logradouro { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public int OrdemRoteiro { get; set; }
        public DateTime HorarioPlanejado { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public long SetorId { get; set; }
        public string Setor { get; set; }

        public DateTime? HorarioPassagem { get; set; }
        public decimal? LongitudePassagem { get; set; }
        public decimal? LatitudePassagem { get; set; }
        public decimal? DistanciaPassagem { get; set; }
    }
}
