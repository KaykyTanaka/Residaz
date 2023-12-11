using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Morador_MasterPageM : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MORADOR"] != null)
        {
            Usuario usuario = (Usuario)Session["MORADOR"];
            usuNome.Text = usuario.nome;
            Session["MoradorURL"] = Request.RawUrl;
            if (Session["acessoinv"] != null && (bool)Session["acessoinv"] == true)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "alerta",
                "alert('Acesso indevido a uma página de síndico, retorno a página anterior ');", true);
                Session.Remove("acessoinv");
            }
        }
        else
        {
            if (Session["SINDICO"] != null)
            {

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                //"alert('Acesso indevido a uma página de síndico, retornando a página anterior')", true);
                //Response.Write("<script>history.go(-1);</script>");
                Session["acessoinv"] = true;
                if (!string.IsNullOrWhiteSpace(Session["SindicoURL"].ToString()))
                    Response.Redirect(Session["SindicoURL"].ToString());
                //Page.Response.Redirect(Page.Request.Url.ToString(), true);
                //Response.Redirect(Request.UrlReferrer.ToString());
                Response.Redirect("../../Login.aspx");
            }
        }
    }

    protected void sair_Click(object sender, EventArgs e)
    {
        Session.Remove("MORADOR");
        Session.Remove("MoradorURL");
    }
}
