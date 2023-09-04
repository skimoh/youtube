using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddLogging((loggingBuilder) => loggingBuilder
        .SetMinimumLevel(LogLevel.Trace)
        )
    .BuildServiceProvider();

var _logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();

_logger.LogInformation("INICIO BACKUP SQLite");

var pastabackup = ConfigurationManager.AppSettings["PastaBackup"];

if (!Directory.Exists(pastabackup))
    Directory.CreateDirectory(pastabackup);

var caminhoCompletoArquivo = $"{pastabackup}SQLITE-{DateTime.Now:yyyyMMddhhmmss}.db";

try
{    

    using (var location = new SqliteConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString()))
    using (var destination = new SqliteConnection(string.Format($"Data Source={caminhoCompletoArquivo};")))
    {
        location.Open();
        destination.Open();
        location.BackupDatabase(destination, "main", "main");
    }

    // comando VACUUM INTO introduzido no SQLite versão 3.27.0 (07/02/2019) 
    //using (var con = new SqliteConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString()))
    //{
    //    con.Open();
    //    SqliteCommand sqlCmd = con.CreateCommand();
    //    sqlCmd.CommandText = $"VACUUM INTO '{caminhoCompletoArquivo}'";        

    //    sqlCmd.ExecuteNonQuery();
    //}
}
catch (Exception ex)
{
    _logger.LogInformation($"ERRO: {ex.Message}");
}

_logger.LogInformation("FIM BACKUP SQLite");
