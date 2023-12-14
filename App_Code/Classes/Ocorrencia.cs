using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Ocorrencia
/// </summary>
public class Ocorrencia
{

    public int id { get; set; }
    public string categoria { get; set; }
    public string titulo { get; set; }
    public string descricao { get; set; }
    public string data { get; set; }
    public string providencias { get; set; }
    public int status { get; set; }
    public int mor_id { get; set; }

    static string[] allcategorias = { "Barulhos", "Areas comuns", "Lixo", "Manutenções", "AVCB (Auto de Vistoria do Corpo de Bombeiros)", "Pessoas Externas", "Areas alugadas", "Segurança", "Obras do condominio", "Obras de moradores" };

    public string[] ChamarCategorias()
    {
        return allcategorias;
    }

}