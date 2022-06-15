
using MySql.Data.MySqlClient;
namespace AgenceTestPractical
{
    public class AppDb : IDisposable
    {
        public MySqlConnection Connection;

        public AppDb()
        
        {
            Connection = new MySqlConnection(AppConfig.Config["Data:ConnectionStrings"]);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}