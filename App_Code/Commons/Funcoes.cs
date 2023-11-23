using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Descrição resumida de Funcoes
/// </summary>
public class Funcoes
{
    // <summary>
    /// Método responsável por criptografar um texto na base SHA 
    /// </summary>
    /// <param name="texto">Texto a ser criptografado</param>
    /// <returns>Retorna o texto na base 512</returns>
    public static string HashSHA512(string texto)
    {
        HashAlgorithm hashAlgoritmo = HashAlgorithm.Create("SHA-512");
        //if (hashAlgoritmo==null) -> gerar excessão
        byte[] hash = hashAlgoritmo.ComputeHash(Encoding.UTF8.GetBytes(texto));
        return Convert.ToBase64String(hash);
    }

    /// <summary>
    /// Método para criptografar um texto na base64
    /// </summary>
    /// <param name="texto">Texto que será criptografado</param>
    /// <returns>Retorna um texto na base64</returns>
    public static string HashBase64(string texto)
    {
        byte[] byteBase64 = new byte[texto.Length];
        byteBase64 = Encoding.UTF8.GetBytes(texto);
        string codifica = Convert.ToBase64String(byteBase64);
        return codifica;
    }

    /// <summary>
    /// Método para descriptografar base64
    /// </summary>
    /// <param name="textoBase64">Texto em base64 que será descriptografado</param>
    /// <returns>Retorna o texto descriptografado</returns>
    public static string HashBase64Return(string textoBase64)
    {
        var encode = new UTF8Encoding(); //abstraindo propriedades de uma classe (estamos expandindo a classe encode)
        var utf8Decode = encode.GetDecoder(); // metodo do encode

        byte[] stringTextoBase64 = Convert.FromBase64String(textoBase64); //vetor recebendo o texto em base64
        int contador = utf8Decode.GetCharCount(stringTextoBase64, 0, stringTextoBase64.Length); //utilizado para descobrir as partições(indices) do vetor byte que recebe a base64
        char[] decodeContador = new char[contador]; //cria o vetor com o contador, agora em um vetor padrão e não mais de bytes

        utf8Decode.GetChars(stringTextoBase64, 0, stringTextoBase64.Length, decodeContador, 0); //pegar todos os valores e automaticamente passa um foreach
        string resultado = new String(decodeContador); //forçar o char para string 

        return resultado;
    }

    public static int CountDataSet(DataSet ds)
    {
        if (ds != null)
            return ds.Tables[0].Rows.Count;
        else return 0;
    }

    public static void FillGrid(GridView gdv, DataSet ds, Label lbl)
    {
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                gdv.DataSource = ds.Tables[0].DefaultView;
                gdv.DataBind();
                gdv.HeaderRow.TableSection = TableRowSection.TableHeader;
                gdv.Visible = true;
            }
            else
            {
                // lbl.Text = "Não há registros!";
            }
        }
        else
        {
            gdv.Visible = false;
            //lbl.Text = "Erro ao buscar registros!";

        }
    }

}