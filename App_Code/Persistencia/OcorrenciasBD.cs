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

    public static Ocorrencia SelectByID(int id)
    {
        Ocorrencia oco = null;
        IDbConnection conn = ConexaoBD.Conexao();
        IDataReader dr;

        string sql = "select * from oco_ocorrencia where oco_id = ?id";
        IDbCommand cmd = ConexaoBD.Comando(sql, conn);
        cmd.Parameters.Add(ConexaoBD.Parametro("?id", id));


        dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            oco = new Ocorrencia();
            oco.id = Convert.ToInt32(dr["oco_id"].ToString());
            oco.categoria = dr["oco_categoria"].ToString();
            oco.titulo = dr["oco_titulo"].ToString();
            oco.descricao = dr["oco_descricao"].ToString();
            oco.data = dr["oco_data"].ToString();
            oco.providencias = dr["oco_providencias"].ToString();
            oco.mor_id = Convert.ToInt32(dr["oco_id"].ToString());
        }

        conn.Close();
        conn.Dispose();
        cmd.Dispose();
        dr.Close();
        dr.Dispose();
        return oco;
    }


    public static int UpdateProvidencias(string providencias, int id)
    {
        int error = 0;

        try
        {
            IDbConnection conn = ConexaoBD.Conexao();
            string sql = "UPDATE OCO_OCORRENCIA SET OCO_PROVIDENCIAS=?PROVIDENCIAS WHERE OCO_ID = ?ID ";
            IDbCommand cmd = ConexaoBD.Comando(sql, conn);
            cmd.Parameters.Add(ConexaoBD.Parametro("?PROVIDENCIAS", providencias));;
            cmd.Parameters.Add(ConexaoBD.Parametro("?ID", id));
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            error = -2;
        }
        return error;

    }

    public static int InsertOcorrencia(Ocorrencia ocorrencia)
    {
        int retorno = 0;
        try
        {
            IDbConnection conn;
            IDbCommand cmd;
            string sql = "INSERT INTO OCO_OCORRENCIA VALUES(0, ?categoria, 'Ocorrencia', ?descricao, ?data, ?providencias, 0, ?mor_id );";
            conn = ConexaoBD.Conexao();
            cmd = ConexaoBD.Comando(sql, conn);
            cmd.Parameters.Add(ConexaoBD.Parametro("?categoria", ocorrencia.categoria));
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

    public static int StatusOcorrencia(int codeUser, int value)
    {
        int error = 0;

        try
        {
            IDbConnection conn = ConexaoBD.Conexao();
            string sql = "UPDATE OCO_OCORRENCIA SET OCO_STATUS= ?VALUE WHERE OCO_ID = ?CODIGO";
            IDbCommand cmd = ConexaoBD.Comando(sql, conn);
            cmd.Parameters.Add(ConexaoBD.Parametro("?VALUE", value));
            cmd.Parameters.Add(ConexaoBD.Parametro("?CODIGO", codeUser));
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            error = -2;
        }
        return error;
    }
    public static List<int> ObterDados()
    {
        // Simula a obtenção de dados do banco de dados
        Random random = new Random();
        List<int> dados = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            dados.Add(random.Next(1, 100));
        }

        return dados;
    }

}