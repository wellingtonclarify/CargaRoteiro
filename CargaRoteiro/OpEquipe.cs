using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaRoteiro
{
    public class OpEquipe : BaseLongIdTenancyLoggable
    {
        public long OperacaoId { get; set; }
        public long TipoOperacaoId { get; set; }
    }
}
