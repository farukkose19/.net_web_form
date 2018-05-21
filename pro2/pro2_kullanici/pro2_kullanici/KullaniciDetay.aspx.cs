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
    public partial class KullaniciDetay : System.Web.UI.Page
    {
        static int id;
        static string kadi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                LoadImage();
                LoadImage2();
                okuma();
                puan();
                inceleme();
                alinti();
            }
        }

        public void LoadImage()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Kullanici where KullaniciID='" + id + "'", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
                if (reader.Read())
                {
                    kadi = reader["KullaniciAdi"].ToString();
                }
                
            }

        }

        public void LoadImage2()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Kullanici where KullaniciID='" + id + "'", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    kadi = reader["KullaniciAdi"].ToString();
                }

            }

        }

        public void okuma()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT k.KitapAdi, k.Resim from KitapOkunma o inner Join Kitap k on o.KitapID=k.KitapID where o.KullaniciID='" + id + "'", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView2.DataSource = reader;
                GridView2.DataBind();
            }
        }

        public void puan()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT o.Puan, k.KitapAdi, k.Resim from KitapPuan o inner Join Kitap k on o.KitapID=k.KitapID where o.KullaniciID='" + id + "'", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView3.DataSource = reader;
                GridView3.DataBind();
            }
        }

        public void inceleme()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT o.Inceleme, k.KitapAdi, k.Resim from KullaniciInceleme o inner Join Kitap k on o.KitapID=k.KitapID where o.KullaniciID='" + id + "'", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView4.DataSource = reader;
                GridView4.DataBind();
            }
        }

        public void alinti()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT o.Cumle, o.SayfaNo, k.KitapAdi, k.Resim from KitapAlinti o inner Join Kitap k on o.KitapID=k.KitapID where o.KullaniciID='" + id + "'", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView5.DataSource = reader;
                GridView5.DataBind();
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("MesajGonder.aspx?KullaniciAdi=" + kadi);
        }
    }
}