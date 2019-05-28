using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaRoteiro
{
    public class PlanejadoVsRealizado : BaseLongIdTenancyLoggable
    {
        public long OperacaoId { get; set; }
        //public virtual Operacao Operacao { get; set; }

        public long TipoOperacaoId { get; set; }
        //public virtual TipoOperacao TipoOperacao { get; set; }

        public long SetorId { get; set; }
        //public virtual Setor Setor { get; set; }

        public int? PercPlanejado { get; set; }
        public int? PercRealizado { get; set; }

    }
}
