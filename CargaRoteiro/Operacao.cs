using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaRoteiro
{
    public class Operacao : BaseLongIdTenancyLoggable
    {
        public long UnidadeId { get; set; }
        //public virtual Unidade Unidade { get; set; }

        public long TurnoId { get; set; }
        //public virtual TurnoOperacional Turno { get; set; }

        public DateTime DataOperacao { get; set; }
    }
}
