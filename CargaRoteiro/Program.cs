using CargoRoteiro.DbContext;
using Dapper;
using System;
using System.Data;
using System.Linq;

namespace CargaRoteiro
{
    class Program
    {
        static void Main(string[] args)
        {
            int idx = 0;
            IDbConnection conn = null;
            try
            {
                var ini = DateTime.Now;
                //var count = 0;
                using (conn = DbConnectionFactory.GetInstance())
                {
                    //count = conn.QuerySingle<int>("select count(*) from PlanejadoVsRealizado");
                    
                    while (true)
                    {
                        Console.Write("Obtendo registros");
                        var lst = conn.Query<PlanejadoVsRealizado>(@"select top 10 Id=PlanejadoVsRealizadoId
                        from PlanejadoVsRealizadoRoteiro
                        group by PlanejadoVsRealizadoId
                        having COUNT(*) <> MAX(OrdemRoteiro)", commandTimeout: int.MaxValue).ToList();
                        Console.WriteLine(" - obtidos");
                        if (lst.Count == 0)
                            break;

                        foreach (var item in lst)
                        {
                            Console.Write("{0}º fazendo", ++idx);
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
                            Console.WriteLine(" - feito");
                        }
                    }
                }
                var fim = DateTime.Now;
                Console.WriteLine("{0} - {1} - {2}", ini, fim, fim.Subtract(ini));
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Erro: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                Console.ReadKey();
            }
        }
    }
}
