using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Morador_Historico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["MORADOR"] != null)
            {
                LoadCard();
            }
        }
    }

    void LoadCard()
    {
        Usuario usuario = (Usuario)Session["MORADOR"];
        DataSet ds = OcorrenciasBD.SelectOcorrencias(usuario.id); //substituir o numero pelo codigo do morador que estará na session;

        if (ds != null)
        {
            lblCard.DataSource = ds;
            lblCard.DataBind();
        }
    }


}