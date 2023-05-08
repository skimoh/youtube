using CodeBehind.InterBaseFather;
using Dapper;
using InterBaseSql.Data.InterBaseClient;

//CONEXAO DIA ADO ---------------------------------------------------------------------
var con = new IBConnection(Conexao.BuildConnectionStringBuilder().ToString());
con.Open();

var cmd = con.CreateCommand();
cmd.CommandText = "SELECT * FROM TMP$POOLS";
var rd = cmd.ExecuteReader();
if (rd.HasRows)
{
    while (rd.Read())
    {
        Console.WriteLine(rd[1].ToString());
    }
}
con.Close();
//FIM-CONEXAO DIA ADO ---------------------------------------------------------------------




//CONEXAO VIA DAPPER ----------------------------------------------------------------------
using (var conDap = new IBConnection(Conexao.BuildConnectionStringBuilder().ToString()))
{

    var res = conDap.Query<string>("SELECT TMP$TYPE FROM TMP$POOLS");

    var maxId = conDap.QueryFirst<int>("SELECT MAX(ID) AS ID FROM CLIENTE") + 1;

    conDap.Execute($"INSERT INTO CLIENTE VALUES ({maxId},'LUCAS DA SILVA {maxId}')");

    conDap.Execute("UPDATE CLIENTE SET NOME = 'MARIA DA SILVA GOMES' WHERE ID = 2");

    conDap.Execute($"DELETE FROM CLIENTE WHERE ID = {maxId}");
}

//FIM-CONEXAO VIA DAPPER -----------------------------------------------------------------