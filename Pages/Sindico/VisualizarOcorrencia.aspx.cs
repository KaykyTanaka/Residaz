using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Sindico_VisualizarOcorrencia : System.Web.UI.Page
{
    static Boolean IsPageRefresh;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["SINDICO"] != null)
            {
                LoadGrid();
            }
            ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
            Session["SessionId"] = ViewState["ViewStateId"].ToString();
        }else
        {
            if (ViewState["ViewStateId"].ToString() != Session["SessionId"].ToString())
            {
                IsPageRefresh = true;
            }
            else
            {
                IsPageRefresh = false;
            }

            Session["SessionId"] = System.Guid.NewGuid().ToString();
            ViewState["ViewStateId"] = Session["SessionId"].ToString();
        }

        if (gdvOcorrencias.Rows.Count > 0)
        {
            gdvOcorrencias.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    void LoadGrid()
    {
        DataSet ds = OcorrenciasBD.SelectAll();
        Funcoes.FillGrid(gdvOcorrencias, ds, lblMsg);
    }

    static Boolean geral;
    protected void gdvOcorrencias_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbVisualizar = (LinkButton)e.Row.Cells[4].FindControl("lkbVisualizar");
            LinkButton lbeditar = (LinkButton)e.Row.Cells[4].FindControl("lbeditar");
            int statusValue;
            lbeditar.CommandName = "Neutro";
            if (int.TryParse(e.Row.Cells[3].Text, out statusValue))
            {
                switch (statusValue)
                {
                    case 2:
                        e.Row.Cells[3].Text = "Solucionado";
                        lbeditar.CommandName = "Solucionado";
                        lbeditar.Text = "<i class = 'fa fa-check text-success'></i>";
                        break;
                    case 1:
                        e.Row.Cells[3].Text = "Em andamento";
                        lbeditar.CommandName = "Solucionar";
                        lbeditar.Text = "<i class = 'fa fa-solid fa-gear'></i>";
                        break;
                    case 0:
                        e.Row.Cells[3].Text = "Pendente";
                        lbeditar.CommandName = "Iniciar";
                        lbeditar.Text = "<i class = 'fa fa-solid fa-hourglass-start'></i>";
                        break;
                }
            }
            lbVisualizar.Text = "<i class = 'fa fa-circle-info text-default'></i>";
            if (e.Row.Cells[2].Text == "0")
            {
                e.Row.Cells[2].Text = "<i class='fa fa-times'></i>";

            }
            
        }

    }

    int codigoU;
    protected void gdvOcorrencias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (IsPageRefresh == false)
        {
            int codigo = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName.Contains("Visualizar"))
            {
                Ocorrencia o = OcorrenciasBD.SelectByID(codigo);
                Page.ClientScript.RegisterStartupScript(GetType(), "modalVisualizar", "$(document).ready(function(){$('#modalVisualizar').modal('show');});", true);
                codigoU = o.id;
                lblTitle.Text = o.titulo;
                lblCat.Text = o.categoria;
                lblDesc.Text = o.descricao;
                lblData.Text = o.data;
                txtProvidencias.Text = o.providencias;
            }

            if (e.CommandName.Contains("Solucionado"))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "alerta", "alert('Ocorrência já resolvida! ');", true);
                LoadGrid();
            }
            if (e.CommandName.Contains("Solucionar"))
            {
                OcorrenciasBD.StatusOcorrencia(codigo, 2);
                LoadGrid();
                //Page.ClientScript.RegisterStartupScript(GetType(), "alerta", "alert('Ocorrência solucionada! ');", true);
            }
            if (e.CommandName.Contains("Iniciar"))
            {
                OcorrenciasBD.StatusOcorrencia(codigo, 1);
                LoadGrid();
                //Page.ClientScript.RegisterStartupScript(GetType(), "alerta", "alert('Ocorrência iniciada. ');", true);
            }
            if (e.CommandName.Contains("Neutro"))
            {

            }
        }
        /*if (UsuariosBD.ActiveInUser(codigo, 1) == 0)
        {

        }*/
    }

protected void btnRegistrar_Click(object sender, EventArgs e)
{
    string providencias = txtProvidencias.Text;
    OcorrenciasBD.UpdateProvidencias(providencias, codigoU);
}


}