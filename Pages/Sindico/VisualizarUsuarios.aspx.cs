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
                LoadDropDown();
            }
        }

        if (gdvUsuarios.Rows.Count > 0)
        {
            gdvUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    private void LoadDropDown()
    {
        DataSet dsPessoas = UsuariosBD.SelectPessoas();

        if (dsPessoas != null && dsPessoas.Tables.Count > 0 && dsPessoas.Tables[0].Rows.Count > 0)
        {
            ddPessoa.DataSource = dsPessoas;
            ddPessoa.DataTextField = "pes_nome";
            ddPessoa.DataValueField = "pes_id";
            ddPessoa.DataBind();
        }
        else
        {

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

    protected void btnNewUsuario_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(GetType(), "modalNovoUsu", "$(document).ready(function(){$('#modalNovoUsu').modal('show');});", true);

    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        Pessoa pessoa = new Pessoa();
        pessoa.nome = txtNome.Text;
        pessoa.cpf = txtCpf.Text;
        pessoa.telefone = txtTelefone.Text;
        UsuariosBD.InsertPessoa(pessoa);
        LoadDropDown();

        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert2", "Swal.fire({ title: 'Bom trabalho!', text: 'Pessoa Cadastrada!', icon: 'success' });", true);

    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        Usuario usuario = new Usuario();
        usuario.email = txtEmail.Text;
        usuario.senha = txtSenha.Text;
        usuario.idPessoa = int.Parse(ddPessoa.SelectedValue);
        UsuariosBD.InsertUsuario(usuario);

        string tipoUsuario = rbTipoUsuario.SelectedValue;
        switch (tipoUsuario)
        {
            case "Sindico":
                Sindico sindico = new Sindico();
                int idSindico = UsuariosBD.ObterIdUsuarioPorEmail(txtEmail.Text);
                sindico.usu_id = idSindico;
                UsuariosBD.InsertSindico(sindico);
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert2", "Swal.fire({ title: 'Bom Trabalho!', text: 'Usuário Cadastrado!', icon: 'success' });", true);

                break;
            case "Morador":
                Morador morador = new Morador();
                int idMorador = UsuariosBD.ObterIdUsuarioPorEmail(txtEmail.Text);
                morador.usu_id = idMorador;
                morador.apto = txtApartamento.Text;
                UsuariosBD.InsertMorador(morador);
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert2", "Swal.fire({ title: 'Bom Trabalho!', text: 'Usuário Cadastrado!', icon: 'success' });", true);
                break;
            case "Porteiro":
                Porteiro porteiro = new Porteiro();
                int idPorteiro = UsuariosBD.ObterIdUsuarioPorEmail(txtEmail.Text);
                porteiro.usu_id = idPorteiro;
                UsuariosBD.InsertPorteiro(porteiro);
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert2", "Swal.fire({ title: 'Bom Trabalho!', text: 'Usuário Cadastrado!', icon: 'success' });", true);
                break;
            case "Zelador":
                Zelador zelador = new Zelador();
                int idZelador = UsuariosBD.ObterIdUsuarioPorEmail(txtEmail.Text);
                zelador.usu_id = idZelador;
                UsuariosBD.InsertZelador(zelador);
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert2", "Swal.fire({ title: 'Bom Trabalho!', text: 'Usuário Cadastrado!', icon: 'success' });", true);
                break;
        }
        LoadGrid();
    }
}