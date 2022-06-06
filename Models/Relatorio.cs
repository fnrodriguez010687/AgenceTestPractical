using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace AgenceTestPractical.Models
{
    public class RelatorioTabla
    {
		public string  Periodo { get; set; }
		public double ReceitaLiquida { get; set; }
		public double CustoFixo { get; set; }
		public double Comissao { get; set; }
		public double Lucro { get; set; }
	}
}