using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mime;
using System.Data;

namespace CompanyMaster
{
    public partial class CompanyMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Name = name.Text.ToString();
            string fileName = System.IO.Path.GetFileName(fileupLoad.PostedFile.FileName);
            using (Stream fs = fileupLoad.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        //string query = "INSERT INTO FileMaster (FileName,CompanyId) VALUES (@FileName,@CompanyId)";
                        string query = "dbo.InsertCompanyDetails";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", Name);
                            cmd.Parameters.AddWithValue("@FileData", bytes);
                            cmd.Parameters.AddWithValue("@FileName", fileName);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            lblMessage.Text = "File uploaded successfully.";
            Response.Redirect("CompanyViewPage.aspx");
        }
    }
}