using CargoRoteiro.DbContext;
using Dapper;
using System;
using System.Linq;

namespace CargaRoteiro
{
    class Program
    {
        static void Main(string[] args)
        {
            var ini = DateTime.Now;
            var count = 0;
            using (var conn = DbConnectionFactory.GetInstance())
            {
                count = conn.QuerySingle<int>("select count(*) from PlanejadoVsRealizado");

                while(true)
                {
                    var lst = conn.Query<PlanejadoVsRealizado>(@"select top 500 Id=PlanejadoVsRealizadoId
                        from PlanejadoVsRealizadoRoteiro
                        group by PlanejadoVsRealizadoId
                        having COUNT(*) <> MAX(OrdemRoteiro)").ToList();
                    if (lst.Count == 0)
                        break;

                    foreach (var item in lst)
                    {
                        var id = item.Id;
                        conn.Execute(@"update PlanejadoVsRealizadoRoteiro
                        set OrdemRoteiro = tab.OrdemRoteiro
                        from
                        (
	                        select id, OrdemRoteiro = ROW_NUMBER() OVER(ORDER BY HorarioPlanejado, OrdemRoteiro)
	                        from PlanejadoVsRealizadoRoteiro
	                        where PlanejadoVsRealizadoId = @id
                        ) tab
                        where PlanejadoVsRealizadoRoteiro.Id = tab.Id", new { id });
                    } 
                }
            }
            var fim = DateTime.Now;
            Console.Write("{0} - {1} - {2}", ini, fim, fim.Subtract(ini));
            Console.ReadKey();
        }
    }
}
