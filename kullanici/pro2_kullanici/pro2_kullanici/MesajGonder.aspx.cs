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
    public partial class MesajGonder : System.Web.UI.Page
    {
        static int id;
        static string kadi = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Session["ID"]);
            kadi= Request.QueryString["KullaniciAdi"];
            TextBox1.Text = kadi;

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string kid = "";
                SqlCommand cmd = new SqlCommand("select KullaniciID from Kullanici where KullaniciAdi=@AliciAdi", con);
                cmd.Parameters.AddWithValue("@AliciAdi", TextBox1.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    kid = dr["KullaniciID"].ToString();
                }
                con.Close();

                SqlCommand cmd2 = new SqlCommand("insert into Mesaj (GonderenID, AliciID,Baslik,Mesaj,Tarih) values (@GonderenID,@AliciAdi,@Baslik,@Mesaj,@tarih)", con);
                cmd2.Parameters.AddWithValue("@GonderenID", id);
                cmd2.Parameters.AddWithValue("@Baslik", TextBox2.Text);
                cmd2.Parameters.AddWithValue("@Mesaj", TextBox3.Text);
                cmd2.Parameters.AddWithValue("@AliciAdi", kid);
                cmd2.Parameters.AddWithValue("@tarih", DateTime.Now);
                
                con.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                Response.Redirect("Default.aspx");
            }
        }
    }
}