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

namespace WebApplication1
{
    public partial class _Default : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["Giris"]) == true)
            {
                if (IsPostBack == false)
                {
                    
                    if (!IsPostBack)
                    {
                        LoadImage();
                    }

                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        public void LoadImage()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using(SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT k.KitapID, k.KitapAdi, k.Resim, y.Adi as 'yazar adi', y.Soyadi as 'yazar soyadı', k.YayinEvi, k.KitapTanitimBilgisi FROM Kitap k inner join Yazar y on k.YazarID = y.YazarID",con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();


            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("KitapEkle.aspx");
        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("KitapDuzenle.aspx?id="+id);
        }
    }

   
}