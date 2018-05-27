using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace pro2_kullanici
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string MusteriEmail = TextBox1.Text;
            string MusteriSifresi = TextBox2.Text;
            string baglantiYolumuz = ConfigurationManager.ConnectionStrings["baglantiYolu"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolumuz);
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "select * from Kullanici where KullaniciAdi=@pkadi and Sifre=@psifre";
            komut.Parameters.AddWithValue("@pkadi", MusteriEmail);
            komut.Parameters.AddWithValue("@psifre", MusteriSifresi);
            baglanti.Open();

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.HasRows == true)
            {

                while (dr.Read())
                {
                    int ID = Convert.ToInt32(dr["KullaniciID"]);
                    Session["KullaniciAdi"] = MusteriEmail;
                    Session["ID"] = ID;
                    Session["Giris"] = true;


                    Response.Redirect("Default.aspx?KullaniID=" + ID);
                }
            }
            else
            {
                Response.Write("Yanlış Email veya Şifre");

            }

            baglanti.Close();

            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "aaaaa", "<script>alert('giriş yapılamıyor lütfen terkedin burayı');</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}