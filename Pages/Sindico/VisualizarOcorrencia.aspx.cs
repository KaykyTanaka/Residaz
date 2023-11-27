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
        lblLinhas.Text = "";
        LoadManualGrid(ds);
    }

    void LoadManualGrid(DataSet ds)
    {
        int qtd = Funcoes.CountDataSet(ds);
        if (qtd > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lblLinhas.Text += "<tr> <td>" + dr["oco_id"].ToString() + "</td>  <td>" + dr["oco_titulo"] + "</td> <td>" + dr["oco_categoria"] + "</td> <td>" + dr["oco_status"] + "</td></tr>";
            }

        }
    }

    protected void gdvOcorrencias_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gdvOcorrencias_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}