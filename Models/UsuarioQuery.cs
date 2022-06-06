using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AgenceTestPractical.Models
{

public class UsuarioQuery
{

	public readonly AppDb Db;
	public UsuarioQuery(AppDb db)
	{
		Db = db;
	}

		

	public List<Usuario> CosultoresActivos()
	{
		return ReadAll(CosultoresActivosCmd().ExecuteReader());
	}

	

	public DbCommand CosultoresActivosCmd()
	{
		var cmd = Db.Connection.CreateCommand();
		cmd.CommandText = @"SELECT u.`no_usuario`, u.`co_usuario` FROM `cao_usuario` as u
												join `permissao_sistema` as p on (u.`co_usuario` = p.`co_usuario`) 
												WHERE p.`co_sistema` = 1 and p.`in_ativo` = 'S' and p.`co_tipo_usuario` in (0,1,2);";	
		return cmd as MySqlCommand;
	}

	private List<Usuario> ReadAll(DbDataReader reader)
	{
		var usuarios = new List<Usuario>();
		using (reader)
		{
			while (reader.Read())
			{
				var usuario = new Usuario()
				{
					No_Usuario = reader.GetFieldValue<string>(0),
					Co_Usuario = reader.GetFieldValue<string>(1)
					
				};
				usuarios.Add(usuario);
			}
		}
		return usuarios;
	}

	
}
}