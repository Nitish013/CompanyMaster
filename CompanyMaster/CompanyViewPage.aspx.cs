using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Configuration;

namespace CompanyMaster
{
    public partial class CompanyViewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    //string query = "INSERT INTO FileMaster (FileName,CompanyId) VALUES (@FileName,@CompanyId)";
                    string query = "dbo.GetCompanyDetails";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        GridView1.EmptyDataText = "No Records Found";

                        GridView1.DataSource = cmd.ExecuteReader();

                        GridView1.DataBind();
                        //cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        protected void YourGridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Download"))
            {
                string QueryString = e.CommandArgument.ToString();
                Page.ClientScript.RegisterStartupScript(GetType(), "", "window.open('DisplayDocument.aspx?QS=" + QueryString + "','','width=500,height=500');", true);
            }
        }
    }
}