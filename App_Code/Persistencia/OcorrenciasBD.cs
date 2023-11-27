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
    public static DataSet SelectAll()
    {

        try
        {
            DataSet ds = new DataSet();
            IDbConnection conn = ConexaoBD.Conexao();
            string sql = "SELECT * FROM OCO_OCORRENCIA";
            IDbCommand cmd = ConexaoBD.Comando(sql, conn);
            IDataAdapter adp = ConexaoBD.Adapter(cmd);
            adp.Fill(ds);
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
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

    public static int InsertOcorrencia(Ocorrencia ocorrencia)
    {
        int retorno = 0;
        try
        {
            IDbConnection conn;
            IDbCommand cmd;
            string sql = "INSERT INTO OCO_OCORRENCIA VALUES(0, ?categoria, ?titulo, ?descricao, ?data, ?providencias, 0, ?mor_id );";
            conn = ConexaoBD.Conexao();
            cmd = ConexaoBD.Comando(sql, conn);
            cmd.Parameters.Add(ConexaoBD.Parametro("?categoria", ocorrencia.categoria));
            cmd.Parameters.Add(ConexaoBD.Parametro("?titulo", ocorrencia.titulo));
            cmd.Parameters.Add(ConexaoBD.Parametro("?descricao", ocorrencia.descricao));
            cmd.Parameters.Add(ConexaoBD.Parametro("?data", ocorrencia.data));
            cmd.Parameters.Add(ConexaoBD.Parametro("?providencias", ocorrencia.providencias));
            cmd.Parameters.Add(ConexaoBD.Parametro("?mor_id", ocorrencia.mor_id));
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            retorno = -2;
        }
        return retorno;
    }


}