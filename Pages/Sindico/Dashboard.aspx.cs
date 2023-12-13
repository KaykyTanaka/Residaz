using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Sindico_Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Chama a função para obter dados do banco de dados
            var dados = OcorrenciasBD.ObterDados();

            // Converte os dados para uma string JSON para ser utilizada no JavaScript
            string dadosJson = "[" + string.Join(",", dados) + "]";

            // Executa o script JavaScript para inicializar o gráfico
            ScriptManager.RegisterStartupScript(this, GetType(), "ExibirRosquinha", $"ExibirRosquinha({dadosJson});", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "ExibirGrafico", $"ExibirGrafico({dadosJson});", true);
        }
    }
}