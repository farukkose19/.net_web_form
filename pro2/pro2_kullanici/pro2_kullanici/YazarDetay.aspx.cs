using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.Services.Description;
using System.Collections;
using System.IO;
using System.Drawing;

namespace pro2_kullanici
{
    public partial class YazarDetay : System.Web.UI.Page
    {
        static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                LoadImage();
                Search();
            }
        }


        public void LoadImage()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Yazar where YazarID='"+id+"'", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();


            }

        }

        public void Search()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT k.KitapID, k.KitapAdi, k.Resim, k.YayinEvi, k.KitapTanitimBilgisi FROM Kitap k where YazarID like @YazarID", con);
                cmd.Parameters.AddWithValue("@YazarID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView2.DataSource = reader;
                GridView2.DataBind();


            }

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("KitapDetay.aspx?id=" + id);
        }
    }
}