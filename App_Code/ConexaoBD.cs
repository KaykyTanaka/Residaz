using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de ConexaoBD
/// </summary>
public class ConexaoBD
{
    // CONEXÃO AO BD -> MYSQL
    // STRING DE CONEXÃO 
    /// <summary>
    /// 
    /// Método responsável por abrir a conexão com o BD MySQL, utilizando 
    /// a string de conexão presente no WEBCONFIG (AppSettings)
    /// 
    /// 
    /// </summary>
    /// <returns>
    /// 
    /// Conexão válida com o SQL ABERTA!
    /// 
    /// </returns>

    public static IDbConnection Conexao()
    {
        MySqlConnection conexaoMySQL = new MySqlConnection(ConfigurationManager.AppSettings
            ["stringConexaoBD"]);
        conexaoMySQL.Open();
        return conexaoMySQL;
    }

    /// <summary>
    /// Método responsável por executar um comando SQL 
    /// </summary>
    /// <param name="sql">Comando a ser executado</param>
    /// <param name="conexao">Conexão válida para a execução</param>
    /// <returns>Retornar um comando válido SQL </returns>


    // EXECUTAR COMANDOS (SQL)
    public static IDbCommand Comando(string sql, IDbConnection conexao)
    {
        IDbCommand comando = conexao.CreateCommand();
        comando.CommandText = sql;
        return comando;
    }
    /// <summary>
    ///  Método responsável por coletar uma lista do BD e "passar" a um con. de dados(ex, DS)
    /// </summary>
    /// <param name="comando">Comando válido para ser executado</param>
    /// <returns>Retorna o obj para preenchimento dos dados</returns>

    public static IDataAdapter Adapter(IDbCommand comando)
    {
        IDbDataAdapter adapter = new MySqlDataAdapter();
        adapter.SelectCommand = comando;
        return adapter;
    }

    // PARAM -> SQL INJ / XSS 
    /// <summary>
    /// Método responsável por "ajudar" na prevenção de SQL Injection e XSS
    /// </summary>
    /// <param name="nomeParametro">Nome do par, que virá do método</param>
    /// <param name="valorParametro">Valor a ser constatado</param>
    /// <returns>True ou False para o Par</returns>

    public static IDbDataParameter Parametro(string nomeParametro, object valorParametro)
    {
        return new MySqlParameter(nomeParametro, valorParametro);
    }
}