using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descrição resumida de OcorrenciasBD
/// </summary>
public class OcorrenciasBD
{

    public static DataSet SelectOcorrencias(int moradorID)
    {
        try
        {
            DataSet ds = new DataSet();
            IDbConnection conn = ConexaoBD.Conexao();
            string sql = "SELECT * FROM OCO_OCORRENCIA WHERE MOR_ID = ?MORADORID";
            IDbCommand cmd = ConexaoBD.Comando(sql, conn);
            cmd.Parameters.Add(ConexaoBD.Parametro("?MORADORID", moradorID));
            IDataAdapter adp = ConexaoBD.Adapter(cmd);
            adp.Fill(ds);
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
            return ds;
        }
        catch
        {
            return null;
        }

    }


}