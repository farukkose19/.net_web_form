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
    public partial class YuksekPuanliKitaplar : System.Web.UI.Page
    {
        static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["Giris"]) == true)
            {
                if (IsPostBack == false)
                {
                    if (!IsPostBack)
                    {
                        id = Convert.ToInt32(Session["ID"]);
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
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select top 10 p.KitapID,k.Resim,Sum(Puan) as puan,count(*) as puanlanmasayisi, cast(sum(Puan) as float)/count(*) as ort,k.KitapAdi  from KitapPuan p inner join Kitap k on p.KitapID = k.KitapID group by p.KitapID,k.KitapAdi,k.Resim order by ort desc", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("KitapDetay.aspx?id=" + id);
        }
    }
}