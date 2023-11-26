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
            LoadCard();
        }
    }

    void LoadCard()
    {
        DataSet ds = OcorrenciasBD.SelectOcorrencias(13); //substituir o numero pelo codigo do morador que estará na session;

        if (ds != null)
        {
            lblCard.DataSource = ds;
            lblCard.DataBind();
        }
    }

   
}