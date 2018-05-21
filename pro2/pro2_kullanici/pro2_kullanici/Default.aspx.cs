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
    public partial class _Default : Page
    {
        static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Convert.ToInt32( Session["ID"]);
                LoadImage();
                LoadImage2();
                LoadImage3();
            }
        }

        public void LoadImage()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select k.KullaniciAdi, k.Resim, k.KullaniciID, k.Ad, k.Soyad , COUNT(*) as ortakkitap from KitapOkunma o inner Join Kullanici k on o.KullaniciID=k.KullaniciID where  o.KullaniciID!='"+id+ "' and o.KitapID in (select h.KitapID From KitapOkunma h where h.KullaniciID='" + id + "') group by k.KullaniciID, k.Ad, k.Soyad, k.Resim, k.KullaniciAdi", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }

        }

        public void LoadImage2()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("truncate table ##t; insert into ##t(KitapPuanID,KullaniciID,KitapID, Puan)(select k.KitapPuanID,t.KullaniciID,k.KitapID,k.Puan from KitapPuan k left join (select * from KitapPuan where KullaniciID!='" + id + "') t on t.KitapID =k.KitapID and t.Puan=k.Puan where k.KullaniciID='" + id + "' and t.Puan is not null); select d.KitapPuanID,d.KitapID,t.KitapAdi,d.Puan,k.KullaniciID, k.KullaniciAdi,k.Resim as kullaniciResim,t.Resim as kitapResim from ##t d inner join Kullanici k on k.KullaniciID=d.KullaniciID inner join Kitap t on d.KitapID=t.KitapID;", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView2.DataSource = reader;
                GridView2.DataBind();
            }

        }

        public void LoadImage3()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("oneri3", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView3.DataSource = reader;
                GridView3.DataBind();

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("KitapAra.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("YazarAra.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("KullaniciAra.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("PopulerKitaplar.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("YuksekPuanliKitaplar.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("PopulerYazarlar.aspx");
        }
    }
}