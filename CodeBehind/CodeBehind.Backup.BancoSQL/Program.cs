using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO.Compression;


ServiceProvider serviceProvider = new ServiceCollection()
    .AddLogging((loggingBuilder) => loggingBuilder
        .SetMinimumLevel(LogLevel.Trace)
        )
    .BuildServiceProvider();

var _logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();

_logger.LogInformation("INICIO BACKUP SQL");

try
{
    var pastabackup = ConfigurationManager.AppSettings["PastaBackup"];
    var strCon = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["conexao"].ToString());
    var chavePasta = $"{DateTime.Now:yyyyMMddhhmmss}";
    var pastaUnica = $"{pastabackup}{chavePasta}\\";

    if (!Directory.Exists(pastaUnica))
        Directory.CreateDirectory(pastaUnica);

    var caminhoCompletoArquivo = $"{pastaUnica}SQLSERVER-{chavePasta}.bak";

    _logger.LogInformation("GERANDO .BAK");

    using (var conexao = new SqlConnection(strCon.ConnectionString))
    {
        var query = $"BACKUP DATABASE {strCon.InitialCatalog} TO DISK='{caminhoCompletoArquivo}'";

        using (var command = new SqlCommand(query, conexao))
        {
            conexao.Open();
            command.ExecuteNonQuery();
        }
    }

    var zipName = $"BKP_{chavePasta}.zip";

    _logger.LogInformation($"COMPACTANDO {zipName}");

    ZipFile.CreateFromDirectory($"{pastaUnica}\\", $"{pastabackup}{zipName}");

    //File.Move($"{pastabackup}{zipName}", "Seu storage");
    //FTP

    try
    {
        _logger.LogInformation($"EXCLUINDO TEMP");
        File.Delete(caminhoCompletoArquivo);
        Directory.Delete(pastaUnica);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erro na exclusão do temporario");
    }
}
catch (Exception ex)
{
    _logger.LogInformation($"ERRO: {ex.Message}");
}

_logger.LogInformation("FIM BACKUP");

