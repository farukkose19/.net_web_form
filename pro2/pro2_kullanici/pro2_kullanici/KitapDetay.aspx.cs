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
    public partial class KitapDetay : System.Web.UI.Page
    {
        static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                Search();
                Puan();
                Okunma();
                inceleme();
                alinti();
            }
        }

        public void Search()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT k.KitapID, k.KitapAdi, k.Resim, y.Adi as 'yazar adi', y.Soyadi as 'yazar soyadı', k.YayinEvi, k.KitapTanitimBilgisi FROM Kitap k inner join Yazar y on k.YazarID = y.YazarID where KitapID =@KitapID", con);
                cmd.Parameters.AddWithValue("@KitapID",id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
                con.Close();
            }

        }
        public void Puan()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) as sayi ,sum(Puan) as toplam from KitapPuan where KitapID =@KitapID", con);
                cmd.Parameters.AddWithValue("@KitapID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string sayi = (reader["sayi"].ToString());
                    string toplam= (reader["toplam"].ToString());
                    if (Convert.ToInt32(sayi) != 0)
                        TextBox1.Text = (Convert.ToDouble(toplam) / Convert.ToDouble(sayi)).ToString();
                    else
                        TextBox1.Text = "Kitaba Henüz Puan Verilmemiş...";

                }
                con.Close();
            }

        }

        public void Okunma()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) as sayi from KitapOkunma where KitapID =@KitapID", con);
                cmd.Parameters.AddWithValue("@KitapID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string sayi = (reader["sayi"].ToString());

                    TextBox2.Text = sayi;

                }
                con.Close();
            }

        }

        public void inceleme()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT i.Inceleme, CONCAT(k.Ad,' ', k.Soyad) as adsoyad from KullaniciInceleme i inner join Kullanici k on i.KullaniciID=k.KullaniciID where KitapID =@KitapID", con);
                cmd.Parameters.AddWithValue("@KitapID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView2.DataSource = reader;
                GridView2.DataBind();
                con.Close();
            }
        }

        public void alinti()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT i.Cumle, i.SayfaNo, CONCAT(k.Ad,' ', k.Soyad) as adsoyad from KitapAlinti i inner join Kullanici k on i.KullaniciID=k.KullaniciID where KitapID =@KitapID", con);
                cmd.Parameters.AddWithValue("@KitapID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView3.DataSource = reader;
                GridView3.DataBind();
                con.Close();
            }
        }

        public void Okudum()
        {
            int KullaniciId =Convert.ToInt32( Session["ID"]); 
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("insert into KitapOkunma (KullaniciID, KitapID) values (@KullaniciID,@KitapID)", con);
                cmd.Parameters.AddWithValue("@KitapID", id);
                cmd.Parameters.AddWithValue("@KullaniciID", KullaniciId);
                con.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(cmd);
                DataSet tablo = new DataSet();
                adaptor.Fill(tablo);
                con.Close();
            }
        }

        public void Incelemem()
        {
            int KullaniciId = Convert.ToInt32(Session["ID"]);
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("insert into KullaniciInceleme (KullaniciID, KitapID, Inceleme) values (@KullaniciID,@KitapID,@Inceleme)", con);
                cmd.Parameters.AddWithValue("@KitapID", id);
                cmd.Parameters.AddWithValue("@KullaniciID", KullaniciId);
                cmd.Parameters.AddWithValue("@Inceleme", TextBox3.Text);
                con.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(cmd);
                DataSet tablo = new DataSet();
                adaptor.Fill(tablo);
                con.Close();
            }
        }

        public void Alintim()
        {
            int KullaniciId = Convert.ToInt32(Session["ID"]);
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("insert into KitapAlinti (KullaniciID, KitapID, SayfaNo, Cumle) values (@KullaniciID,@KitapID,@SayfaNo,@Cumle)", con);
                cmd.Parameters.AddWithValue("@KitapID", id);
                cmd.Parameters.AddWithValue("@KullaniciID", KullaniciId);
                cmd.Parameters.AddWithValue("@SayfaNo", TextBox5.Text);
                cmd.Parameters.AddWithValue("@Cumle", TextBox4.Text);
                con.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(cmd);
                DataSet tablo = new DataSet();
                adaptor.Fill(tablo);
                con.Close();
            }
        }

        public void PuanVer()
        {
            int KullaniciId = Convert.ToInt32(Session["ID"]);
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("insert into KitapPuan (KullaniciID, KitapID, Puan) values (@KullaniciID,@KitapID,@Puan)", con);
                cmd.Parameters.AddWithValue("@KitapID", id);
                cmd.Parameters.AddWithValue("@KullaniciID", KullaniciId);
                cmd.Parameters.AddWithValue("@Puan", TextBox6.Text);
                con.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(cmd);
                DataSet tablo = new DataSet();
                adaptor.Fill(tablo);
                con.Close();
            }
        } 

        protected void Button9_Click(object sender, EventArgs e)
        {
            Okudum();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Alintim();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Incelemem();
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            PuanVer();
        }
    }
}