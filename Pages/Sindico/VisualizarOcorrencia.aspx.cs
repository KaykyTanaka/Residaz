using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Sindico_VisualizarOcorrencia : System.Web.UI.Page
{
    int codigo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadGrid();

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


    protected void gdvOcorrencias_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            LinkButton lbVisualizar = (LinkButton)e.Row.Cells[4].FindControl("lkbVisualizar");
            int statusValue;

            if (int.TryParse(e.Row.Cells[3].Text, out statusValue))
            {
                switch (statusValue)
                {
                    case 2:
                        e.Row.Cells[3].Text = "Solucionado";
                        break;
                    case 1:
                        e.Row.Cells[3].Text = "Em andamento";
                        break;
                    case 0:
                        e.Row.Cells[3].Text = "Pendente";
                        break;
                }
            }
            lbVisualizar.Text = "<i class = 'fa fa-circle-info text-default'></i>";
        }
    }

    protected void gdvOcorrencias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Contains("Visualizar"))
        {
            Ocorrencia o = OcorrenciasBD.SelectByID(Convert.ToInt32(e.CommandArgument));
            Page.ClientScript.RegisterStartupScript(GetType(), "modalVisualizar", "$(document).ready(function(){$('#modalVisualizar').modal('show');});", true);
            codigo = o.id;
            lblTitle.Text = o.titulo;
            lblCat.Text = o.categoria;
            lblDesc.Text = o.descricao;
            lblData.Text = o.data;
            txtProvidencias.Text = o.providencias;
        }

    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        string providencias = txtProvidencias.Text;
        OcorrenciasBD.UpdateProvidencias(providencias, codigo);
    }


}