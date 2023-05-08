using InterBaseSql.Data.InterBaseClient;

namespace CodeBehind.InterBaseFather
{
    public class Conexao
    {
        public static IBConnectionStringBuilder BuildConnectionStringBuilder()
        {
            var builder = new IBConnectionStringBuilder();
            builder.UserID = "SYSDBA";
            builder.Password = "masterkey";
            builder.DataSource = "localhost";
            builder.Database = "C:\\temp\\BANCO.IB";
            builder.Port = 3050;
            return builder;
        }
    }
}
