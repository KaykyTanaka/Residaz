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
            @"select *, 's' as tipo from usu_usuarios u inner join sin_sindico s on u.usu_id = s.usu_id where s.usu_id = ?id 
            union 
            select *, 'm' as tipo from usu_usuarios u inner join mor_morador m on u.usu_id = m.usu_id where m.usu_id = ?id;";
        using (var tempo = ConexaoBD.Comando(sql, conn))
        {
            tempo.Parameters.Add(ConexaoBD.Parametro("?id", id));
            var result = tempo.ExecuteReader();
            if (result.Read())
            {
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
            string sql = @"select s.usu_id, pes_nome, usu_email, pes_telefone,s.sin_status as stats, 'Sindico' as tipo 
from pes_pessoas inner join usu_usuarios u using (pes_id) inner join sin_sindico s on u.usu_id = s.usu_id
union
select  m.usu_id, pes_nome, usu_email, pes_telefone, m.mor_status as stats,'Morador' as tipo
from pes_pessoas inner join usu_usuarios u using(pes_id) inner join mor_morador m on u.usu_id = m.usu_id
union
select  z.usu_id, pes_nome, usu_email, pes_telefone, z.zel_status as stats,'Zelador' as tipo 
from pes_pessoas inner join usu_usuarios u using(pes_id) inner join zel_zelador z on u.usu_id = z.usu_id
union
select  p.usu_id, pes_nome, usu_email, pes_telefone, p.por_status as stats,'Porteiro' as tipo 
from pes_pessoas inner join usu_usuarios u using(pes_id) inner join por_porteiro p on u.usu_id = p.usu_id;";

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

    public static int InsertPessoa(Pessoa pessoa)
    {
        int retorno = 0;
        try
        {
            IDbConnection conn;
            IDbCommand cmd;
            string sql = "INSERT INTO PES_PESSOAS VALUES(0, ?nome, ?cpf, ?telefone);";
            conn = ConexaoBD.Conexao();
            cmd = ConexaoBD.Comando(sql, conn);
            cmd.Parameters.Add(ConexaoBD.Parametro("?nome", pessoa.nome));
            cmd.Parameters.Add(ConexaoBD.Parametro("?cpf", pessoa.cpf));
            cmd.Parameters.Add(ConexaoBD.Parametro("?telefone", pessoa.telefone));
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


    public static int InsertUsuario(Usuario usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection conn;
            IDbCommand cmd;
            string sql = "INSERT INTO USU_USUARIOS VALUES(0, ?email, ?senha, ?idPessoa);";
            conn = ConexaoBD.Conexao();
            cmd = ConexaoBD.Comando(sql, conn);
            cmd.Parameters.Add(ConexaoBD.Parametro("?email", usuario.email));
            cmd.Parameters.Add(ConexaoBD.Parametro("?senha", usuario.senha));
            cmd.Parameters.Add(ConexaoBD.Parametro("?idPessoa", usuario.idPessoa));
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


    public static DataSet SelectPessoas()
    {
        try
        {
            DataSet ds = new DataSet();
            IDbConnection conn = ConexaoBD.Conexao();
            string sql = "select * from pes_pessoas;";
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

    public static int ObterIdUsuarioPorEmail(string email)
    {
        int retorno = 0;
        try
        {
            using (IDbConnection conn = ConexaoBD.Conexao())
            {
                string sql = "SELECT usu_id FROM USU_USUARIOS WHERE usu_email = ?email;";
                using (IDbCommand cmd = ConexaoBD.Comando(sql, conn))
                {
                    cmd.Parameters.Add(ConexaoBD.Parametro("?email", email));

                    // ExecuteScalar é usado para obter um valor único do banco de dados
                    object result = cmd.ExecuteScalar();

                    // Se o resultado não for nulo, convertemos para inteiro
                    if (result != null)
                    {
                        retorno = Convert.ToInt32(result);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            retorno = -2;
        }
        return retorno;
    }

    public static int InsertSindico(Sindico sindico)
    {
        int retorno = 0;
        try
        {
            IDbConnection conn;
            IDbCommand cmd;
            string sql = "INSERT INTO SIN_SINDICO VALUES(0, 1, null, ?usu_id);";
            conn = ConexaoBD.Conexao();
            cmd = ConexaoBD.Comando(sql, conn);
            cmd.Parameters.Add(ConexaoBD.Parametro("?usu_id", sindico.usu_id));
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

    public static int InsertMorador(Morador morador)
    {
        int retorno = 0;
        try
        {
            IDbConnection conn;
            IDbCommand cmd;
            string sql = "INSERT INTO MOR_MORADOR VALUES(0, ?apto ,1, ?usu_id);";
            conn = ConexaoBD.Conexao();
            cmd = ConexaoBD.Comando(sql, conn);
            cmd.Parameters.Add(ConexaoBD.Parametro("?apto", morador.apto));
            cmd.Parameters.Add(ConexaoBD.Parametro("?usu_id", morador.usu_id));
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

    public static int InsertPorteiro(Porteiro porteiro)
    {
        int retorno = 0;
        try
        {
            IDbConnection conn;
            IDbCommand cmd;
            string sql = "INSERT INTO por_porteiro VALUES(0, 1, null, ?usu_id);";
            conn = ConexaoBD.Conexao();
            cmd = ConexaoBD.Comando(sql, conn);
            cmd.Parameters.Add(ConexaoBD.Parametro("?usu_id", porteiro.usu_id));
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
    public static int InsertZelador(Zelador zelador)
    {
        int retorno = 0;
        try
        {
            IDbConnection conn;
            IDbCommand cmd;
            string sql = "INSERT INTO zel_zelador VALUES(0, 1, null, ?usu_id);";
            conn = ConexaoBD.Conexao();
            cmd = ConexaoBD.Comando(sql, conn);
            cmd.Parameters.Add(ConexaoBD.Parametro("?usu_id", zelador.usu_id));
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