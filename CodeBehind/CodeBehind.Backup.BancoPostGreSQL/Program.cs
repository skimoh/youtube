using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Diagnostics;
using System.Text;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddLogging((loggingBuilder) => loggingBuilder
        .SetMinimumLevel(LogLevel.Trace)
        )
    .BuildServiceProvider();

var _logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();

_logger.LogInformation("INICIO BACKUP PostGreSQL");
var pastabackup = ConfigurationManager.AppSettings["PastaBackup"];
if (!Directory.Exists(pastabackup))
    Directory.CreateDirectory(pastabackup);

var pastaDump = ConfigurationManager.AppSettings["PastaDump"];
var host = ConfigurationManager.AppSettings["Server"];
var port = ConfigurationManager.AppSettings["Port"];
var user = ConfigurationManager.AppSettings["UserId"];
var password = ConfigurationManager.AppSettings["Password"];
var database = ConfigurationManager.AppSettings["Database"];
var caminhoCompletoArquivo = $"{pastabackup}POSTGRESQL-{DateTime.Now:yyyyMMddhhmmss}.sql";


String dumpCommand = "\"" + pastaDump + "\"" + " -Fc" + " -h " + host + " -p " + port + " -d " + database + " -U " + user + "";
String passFileContent = "" + host + ":" + port + ":" + database + ":" + user + ":" + password + "";

String batFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".bat");
String passFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".conf");

try
{
    String batchContent = "";
    batchContent += "@" + "set PGPASSFILE=" + passFilePath + "\n";
    batchContent += "@" + dumpCommand + "  > " + "\"" + caminhoCompletoArquivo + "\"" + "\n";

    File.WriteAllText(batFilePath,batchContent, Encoding.ASCII);

    File.WriteAllText(passFilePath,passFileContent,Encoding.ASCII);

    if (File.Exists(caminhoCompletoArquivo))
        File.Delete(caminhoCompletoArquivo);

    ProcessStartInfo oInfo = new ProcessStartInfo(batFilePath);
    oInfo.UseShellExecute = false;
    oInfo.CreateNoWindow = true;

    using (Process proc = System.Diagnostics.Process.Start(oInfo))
    {
        proc.WaitForExit();
        proc.Close();
    }
}
finally
{
    if (File.Exists(batFilePath))
        File.Delete(batFilePath);

    if (File.Exists(passFilePath))
        File.Delete(passFilePath);
}