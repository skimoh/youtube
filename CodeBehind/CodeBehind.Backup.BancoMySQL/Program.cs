using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Text;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddLogging((loggingBuilder) => loggingBuilder
        .SetMinimumLevel(LogLevel.Trace)
        )
    .BuildServiceProvider();

var _logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();

_logger.LogInformation("INICIO BACKUP MYSQL");

var pastabackup = ConfigurationManager.AppSettings["PastaBackup"];
if (!Directory.Exists(pastabackup))
    Directory.CreateDirectory(pastabackup);

var caminhoCompletoArquivo = $"{pastabackup}MYSQL-{DateTime.Now:yyyyMMddhhmmss}.sql";

var strCon = ConfigurationManager.ConnectionStrings["conexao"].ToString();

using (MySqlConnection conn = new MySqlConnection(strCon))
{
    conn.Close();
    using (MySqlCommand cmd = new MySqlCommand())
    {
        using (MySqlBackup mb = new MySqlBackup(cmd))
        {
            cmd.Connection = conn;
            conn.Open();
            mb.ExportToFile(caminhoCompletoArquivo);
            conn.Close();
        }
    }
}


_logger.LogInformation("FIM BACKUP MYSQL");