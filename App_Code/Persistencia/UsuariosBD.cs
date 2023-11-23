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

        string sql = "select * from usu_usuarios where usu_email = ?email and usu_senha = ?senha";
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
        }

        conn.Close();
        conn.Dispose();
        cmd.Dispose();
        dr.Close();
        dr.Dispose();
        return usu;
    }

}