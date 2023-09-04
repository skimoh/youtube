using InterBaseSql.Data.InterBaseClient;
using System.Configuration;

namespace CodeBehind.InterBaseFather
{
    public class Conexao
    {
        public static IBConnectionStringBuilder BuildConnectionStringBuilder()
        {


            var builder = new IBConnectionStringBuilder
            {
                UserID = ConfigurationManager.AppSettings["Usuario"],
                Password = ConfigurationManager.AppSettings["Senha"],
                DataSource = ConfigurationManager.AppSettings["DataSource"],
                Database = ConfigurationManager.AppSettings["CaminhoBanco"],
                Port = Convert.ToInt32(ConfigurationManager.AppSettings["Porta"])
            };
            return builder;
        }
    }
}
