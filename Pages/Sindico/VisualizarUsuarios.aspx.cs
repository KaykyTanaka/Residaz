using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Sindico_VisualizarUsuarios : System.Web.UI.Page
{
    //gdvUsuarios
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["SINDICO"] != null)
            {
                LoadGrid();
            }
        }

        if (gdvUsuarios.Rows.Count > 0)
        {
            gdvUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    void LoadGrid()
    {
        DataSet ds = UsuariosBD.SelectAll();
        Funcoes.FillGrid(gdvUsuarios, ds, lblMsg);
    }
    protected void gdvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int statusValue;
            if (int.TryParse(e.Row.Cells[4].Text, out statusValue))
            {
                switch (statusValue)
                {
                    case 1:
                        e.Row.Cells[4].Text = "Ativo";

                        break;
                    case 0:
                        e.Row.Cells[4].Text = "Inativo";
                        break;
                }
            }
        }

    }
    protected void gdvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
}