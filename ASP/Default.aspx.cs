using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=MATT-LAPTOP;Initial Catalog=test;User ID=sa;Password=ntws4074");
    SqlCommand cmd;
    SqlDataAdapter adpt;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        adpt = new SqlDataAdapter("SELECT * FROM users", con);
        dt = new DataTable();
        adpt.Fill(dt);
        gridView.DataSource = dt;
        gridView.DataBind();
        con.Close();
        txtFirstname.Text = "WOW";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        con.Open();
        cmd = new SqlCommand("INSERT INTO users VALUES('" + txtFirstname.Text + "','" + txtLastname.Text + "','" + txtPhone.Text + "')", con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}