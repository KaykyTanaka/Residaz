using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Sindico_MasterPageS : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SINDICO"] != null)
        {
            Usuario usuario = (Usuario)Session["SINDICO"];
            usuNome.Text = usuario.nome;
            Session["SindicoURL"] = Request.RawUrl;
            if (Session["acessoinv"] != null && (bool)Session["acessoinv"] == true)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "alerta",
                "alert('Acesso indevido a uma página de morador, retorno a página anterior ');", true);
                Session.Remove("acessoinv");
            }
        }
        else
        {
            if (Session["MORADOR"] != null)
            {
                //Response.Write("<script>history.go(-1);</script>");
                //Response.Redirect(Request.UrlReferrer.ToString());
                Session["acessoinv"] = true;
                if (!string.IsNullOrWhiteSpace(Session["MoradorURL"].ToString()))
                    Response.Redirect(Session["MoradorURL"].ToString());
                //return;
            }
            Response.Redirect("../../Login.aspx");
        }
    }

    protected void sair_Click(object sender, EventArgs e)
    {
        Session.Remove("SINDICO");
        Session.Remove("SindicoURL");
    }
}
