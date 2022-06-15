using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace AgenceTestPractical.Models
{

public class ReceitaQuery
{

	public readonly AppDb Db;
	public ReceitaQuery(AppDb db)
	{
		Db = db;
	}

		

	public List<Receita> ReceitasXCosultores(DateTime dateini, DateTime dateend, string usuario)
	{
		return ReadAll(ReceitasXCosultoresCmd(dateini, dateend, usuario).ExecuteReader());
	}

	

	public DbCommand ReceitasXCosultoresCmd(DateTime dateini, DateTime dateend, string usuarios)
	{
		var users = "in("+usuarios+")";
		var dateIni = dateini.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
		var dateEnd = dateend.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
		
		var cmd = Db.Connection.CreateCommand();
		cmd.CommandText = @"SELECT f.`co_os`, 
									 `valor`, 
									 `total_imp_inc`, 
									 `data_emissao`, 
									 `comissao_cn`, 
									 sal.`brut_salario` 
							FROM `cao_fatura` as f 
							join `cao_os` as os on(f.`co_os` = os.`co_os` ) 
							join `cao_salario` as sal on (os.`co_usuario` = sal.`co_usuario`) 
							WHERE `data_emissao`>= '"+dateIni+"' and `data_emissao`<= '"+dateEnd+"' and os.`co_usuario` "+@users;	
		
		
		return cmd as MySqlCommand;
	}

	private List<Receita> ReadAll(DbDataReader reader)
	{
		var receitas = new List<Receita>();
		using (reader)
		{
			while (reader.Read())
			{
				var receita = new Receita();
				
					receita.Co_Os = reader.GetFieldValue<int?>(0);
					receita.Valor = reader.GetFieldValue<Single?>(1);
					receita.Total_Imp_Inc = reader.GetFieldValue<Single?>(2);
					receita.Data_Emissao = reader.GetFieldValue<DateTime?>(3);
					receita.Comissao_Cn = reader.GetFieldValue<Single?>(4);
					receita.Brut_Salario = reader.GetFieldValue<float?>(5);					
				
				receitas.Add(receita);
			}
		}
		return receitas;
	}

	
}
}