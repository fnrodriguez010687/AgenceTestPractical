using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace AgenceTestPractical.Models
{
    public class DesempenoTabla
    {
	public string Consultor { get; set; }
		
	public List<RelatorioTabla> Relatorios { get; set; }	
	}
}