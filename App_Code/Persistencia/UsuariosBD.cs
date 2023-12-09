using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Activities;
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

        string sql = 
            "select *, 's' as tipo from usu_usuarios u inner join sin_sindico s on u.usu_id = s.usu_id where s.usu_id = ?id "+
            "union " +
            "select *, 'm' as tipo from usu_usuarios u inner join mor_morador m on u.usu_id = m.usu_id where m.usu_id = ?id;";
        using (var tempo = ConexaoBD.Comando(sql, conn))
        {
            tempo.Parameters.Add(ConexaoBD.Parametro("?id", id));
            var result = tempo.ExecuteReader();
            if(result.Read()){
                usu = new Usuario
                {
                    tipo = result["tipo"].ToString()
                };
            }
        }

        if (usu.tipo == "s")
        {
            usu.redirecionar = "Pages/Sindico/VisualizarOcorrencia.aspx";
        }
        else
        if (usu.tipo == "m")
        {
            usu.redirecionar = "Pages/Morador/HistoricoOcorrencia.aspx";
        }

        conn.Close();
        conn.Dispose();
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
    public static DataSet SelectAll()
    {

        try
        {
            DataSet ds = new DataSet();
            IDbConnection conn = ConexaoBD.Conexao();
            string sql = @"select s.usu_id, pes_nome, usu_email, pes_telefone,s.sin_status as stats, 'Sindico' as tipo from usu_usuarios u inner join sin_sindico s on u.pes_id = s.usu_id inner join pes_pessoas using (pes_id)
union 
select  m.usu_id, pes_nome, usu_email, pes_telefone, m.mor_status as stats,'Morador' as tipo from usu_usuarios u inner join mor_morador m on u.pes_id = m.usu_id inner join pes_pessoas using (pes_id)
union 
select  z.usu_id, pes_nome, usu_email, pes_telefone, z.zel_status as stats,'Zelador' as tipo from usu_usuarios u inner join zel_zelador z on u.pes_id = z.usu_id inner join pes_pessoas using (pes_id)
union
select  p.usu_id, pes_nome, usu_email, pes_telefone, p.por_status as stats,'Porteiro' as tipo from usu_usuarios u inner join por_porteiro p on u.pes_id = p.usu_id inner join pes_pessoas using (pes_id);";
            
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
}