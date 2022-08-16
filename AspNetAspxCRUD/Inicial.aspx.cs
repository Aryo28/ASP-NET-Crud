using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetAspxCRUD
{
    public partial class Inicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropList();
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            string name = txbNome.Text.Trim();
            string lastName = txbLastName.Text.Trim();
            string age = txbIdade.Text.Trim();
            string height = txbAltura.Text.Trim();


                // fields content
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(lastName) || !string.IsNullOrEmpty(age)
                     || !string.IsNullOrEmpty(height))
                {
                   
                    try
                    {
                        Alumnos p = new Alumnos();
                        p.nome = name;
                        p.idade = int.Parse(age);
                        p.altura = int.Parse(height);
                        p.last_name = lastName;
    
                        
                        p.gravarPessoa();
                        lblGravou.Visible = true;
                        lblGravou.ForeColor = System.Drawing.Color.Green;
                        lblGravou.Text = "New User Added!";
                    }
                     catch(InvalidCastException error)
                    {
                        lblGravou.Visible = true;
                        lblGravou.ForeColor = System.Drawing.Color.Red;
                        lblGravou.Text = error.Message;
                        throw;
                    }
                }
            else
            {
                lblGravou.Visible = true;
                lblGravou.ForeColor = System.Drawing.Color.Red;
                lblGravou.Text = "All fields must be filled";
            }        
        }

        // Table Select and datatable 
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            lblExcluiu.Visible = false;
            lblGravou.Visible = false;
            lblAlterou.Visible = false;
            txbNome.Text = "";
            txbLastName.Text = "";
            txbAltura.Text = "";
            txbIdade.Text = "";

            txbIdAlt.Text = "";
            txbNomeAlt.Text = "";
            txbIdadeAlt.Text = "";
            txbLastAlt.Text = "";
            txbAlturaAlt.Text = "";

            DataTable dt = new DataTable();
            Conex bd = new Conex();

            dt = bd.executeQuery("select * from students2");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        // Delete
        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            Alumnos p = new Alumnos();
            p.id = int.Parse(DropDownListUsers.SelectedValue);

            if (p.excluirPessoa())
            {
                lblExcluiu.Visible = true;
                lblExcluiu.ForeColor = System.Drawing.Color.OrangeRed;
                lblExcluiu.Text = "User Deleted";
            }
            else
            {
                lblExcluiu.ForeColor = System.Drawing.Color.Red;
                lblExcluiu.Text = "Error";
            }
        }

        // Update
        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            Alumnos p = new Alumnos();
            p.id = int.Parse(txbIdAlt.Text);
            p.nome = txbNomeAlt.Text.Trim();
            p.last_name = txbLastAlt.Text.Trim();
            p.idade = int.Parse(txbIdadeAlt.Text.Trim());
            p.altura = int.Parse(txbAlturaAlt.Text.Trim());

            if (p.alterarPessoa())
            {
                lblAlterou.ForeColor = System.Drawing.Color.Green;
                lblAlterou.Text = "User Updated";
            }
            else
            {
                lblAlterou.ForeColor = System.Drawing.Color.Red;
                lblAlterou.Text = "Error";
            }
        }

        protected void btnDataReader_Click(object sender, EventArgs e)
        {
            Alumnos p = new Alumnos();
            p = p.retornaPessoa(1);
            //lblDataReader.Text = p.nome;
        }


        public void DropList()
        {
            
            Conex conn = new Conex();

            using (SqlConnection con = conn.abrirconexion())
            {
                SqlCommand cmd = new SqlCommand("select id, name from students2", con);
                DropDownListUsers.DataSource = cmd.ExecuteReader();
                DropDownListUsers.DataBind();
                con.Close();
            }
            DropDownListUsers.ClearSelection();

        }



        protected void txbNome_Load(object sender, EventArgs e)
        {

        }

        protected void txbNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}