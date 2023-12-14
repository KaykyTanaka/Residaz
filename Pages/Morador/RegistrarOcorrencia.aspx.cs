using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Morador_Ocorrencia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["MORADOR"] != null)
            {
                // Adiciona os itens à DropDownList apenas se a página não estiver sendo carregada por um postback
                string[] categorias = { "Barulhos", "Areas comuns", "Lixo", "Manutenções", "AVCB (Auto de Vistoria do Corpo de Bombeiros)", "Pessoas Externas", "Areas alugadas", "Segurança", "Obras do condominio", "Obras de moradores" };
                ddCategoria.Items.Insert(0, new ListItem("Selecione uma Categoria", ""));
                foreach (string categoria in categorias)
                {

                    ddCategoria.Items.Add(new ListItem(categoria, categoria));
                }
            }
        }
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        if (ddCategoria.SelectedValue != "" && txtDescricao.Text != "")
        {
            Usuario usuario = (Usuario)Session["MORADOR"];
            Ocorrencia ocorrencia = new Ocorrencia();
            ocorrencia.descricao = txtDescricao.Text;
            ocorrencia.categoria = ddCategoria.SelectedValue;
            ocorrencia.data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ocorrencia.providencias = "Aguardando...";
            ocorrencia.mor_id = usuario.id;

            OcorrenciasBD.InsertOcorrencia(ocorrencia);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "alerta", "alert('Preencha os campos corretamente!');", true);
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert2", "Swal.fire({ title: 'Bom Trabalho!', text: 'Ocorrência Cadastrado!', icon: 'success' });", true);
    }
}