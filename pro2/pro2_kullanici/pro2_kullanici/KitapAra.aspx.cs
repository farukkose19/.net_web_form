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
    public partial class KitapAra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                if (!IsPostBack)
                {
                    LoadImage();
                }

            }
        }

        public void LoadImage()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT k.KitapID, k.KitapAdi, k.Resim, y.Adi as 'yazar adi', y.Soyadi as 'yazar soyadı', k.YayinEvi, k.KitapTanitimBilgisi FROM Kitap k inner join Yazar y on k.YazarID = y.YazarID", con);
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
                SqlCommand cmd = new SqlCommand("SELECT k.KitapID, k.KitapAdi, k.Resim, y.Adi as 'yazar adi', y.Soyadi as 'yazar soyadı', k.YayinEvi, k.KitapTanitimBilgisi FROM Kitap k inner join Yazar y on k.YazarID = y.YazarID where KitapAdi like @pKitapAdi", con);
                cmd.Parameters.AddWithValue("@pKitapAdi",TextBox1.Text);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();


            }

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("KitapDetay.aspx?id=" + id);
        }
    }
}