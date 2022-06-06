using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace AgenceTestPractical.Models
{
    public class Receita
    {
	public int? Co_Os { get; set; }
	public float? Valor { get; set; }
    public float? Total_Imp_Inc { get; set; }
    public DateTime? Data_Emissao { get; set; }
    public float? Comissao_Cn { get; set; }
    public float? Brut_Salario { get; set; }
}
}