using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Sindico_VisualizarOcorrencia : System.Web.UI.Page
{
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
        }
    }

    protected void gdvOcorrencias_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}