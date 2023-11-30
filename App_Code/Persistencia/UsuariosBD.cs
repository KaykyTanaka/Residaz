using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de UsuariosBD
/// </summary>
public class UsuariosBD
{
    public static Usuario Login(String email, String senha)
    {
        Usuario usu = null;
        IDbConnection conn = ConexaoBD.Conexao();
        IDataReader dr;

        string sql = "select * from usu_usuarios inner join pes_pessoas using(pes_id) where usu_email = ?email and usu_senha = ?senha";
        IDbCommand cmd = ConexaoBD.Comando(sql, conn);
        cmd.Parameters.Add(ConexaoBD.Parametro("?email", email));
        cmd.Parameters.Add(ConexaoBD.Parametro("?senha", senha));

        dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            usu = new Usuario();
            usu.id = Convert.ToInt32(dr["usu_id"].ToString());
            usu.email = dr["usu_email"].ToString();
            usu.senha = dr["usu_senha"].ToString();
            usu.nome = dr["pes_nome"].ToString();
        }

        conn.Close();
        conn.Dispose();
        cmd.Dispose();
        dr.Close();
        dr.Dispose();
        return usu;
    }

    public static Usuario TipoLogin(int id)
    {
        Usuario usu = null;
        IDbConnection conn = ConexaoBD.Conexao();
        //IDataReader dr;
        //IDataReader dr2;
        Boolean verificarSindico = false;
        Boolean verificarMorador = false;

        string sql = "select if( exists( select * from usu_usuarios u inner join sin_sindico s on ?id = s.usu_id), true , false ) as sla;";
        string sql2 = "select if( exists( select * from usu_usuarios u inner join mor_morador m on ?id = m.usu_id), true , false ) as sla;";
        IDbCommand cmd = ConexaoBD.Comando(sql, conn);
        IDbCommand cmd2 = ConexaoBD.Comando(sql2, conn);
        cmd.Parameters.Add(ConexaoBD.Parametro("?id", id));
        cmd2.Parameters.Add(ConexaoBD.Parametro("?id", id));

        using (var tempo = ConexaoBD.Comando(sql, conn))
        {
            tempo.Parameters.Add(ConexaoBD.Parametro("?id", id));
            //tempo.Parameters.Add(ConexaoBD.Parametro("sla", MySqlDbType.Bit));

            //object result = null;
            // try
            //{
            var result = tempo.ExecuteScalar().ToString();
            //}
            /*catch (Exception ex)
            {
                throw new ArgumentNullException("Não foi possível realizar a busca");
            }*/
            if (result == "1")
            {
                verificarSindico = true;
            }
        }

        using (var tempo = ConexaoBD.Comando(sql2, conn))
        {
            tempo.Parameters.Add(ConexaoBD.Parametro("?id", id));
            //tempo.Parameters.Add(ConexaoBD.Parametro("sla", MySqlDbType.Bit));

            //object result = null;
            //try
            //{
            var result = tempo.ExecuteScalar().ToString();
            //}
            /*catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }*/
            if (result == "1" && verificarSindico == false)
            {
                verificarMorador = true;
            }
        }

        //dr = cmd.ExecuteReader();
        //dr2 = cmd2.ExecuteReader();

        usu = new Usuario();
        if (verificarSindico == true)
        {
            usu.redirecionar = "Pages/Sindico/VisualizarOcorrencia.aspx";
        }
        else
        if (verificarMorador == true)
        {
            usu.redirecionar = "Pages/Morador/HistoricoOcorrencia.aspx";
        }


        conn.Close();
        conn.Dispose();
        cmd.Dispose();
        //dr.Close();
        //dr.Dispose();
        return usu;
    }
    
    public static int ActiveInUser(int codeUser, int value)
    {
        int error = 0;

        try
        {
            IDbConnection conn = ConexaoBD.Conexao();
            string sql = "UPDATE USU_USUARIOS SET USU_ATIVO = ?VALUE WHERE USU_CODIGO = ?CODIGO";
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
}