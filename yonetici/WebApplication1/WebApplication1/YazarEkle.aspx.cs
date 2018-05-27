using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace WebApplication1
{
    public partial class YazarEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime Olum = Calendar1.SelectedDate;
            DateTime dogum = Calendar2.SelectedDate;
            string YazarAdi = TextBox1.Text;
            string Soyad = TextBox2.Text;
            string DogumYeri = TextBox3.Text;
            string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolu"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);

            if (Calendar1.SelectedDate.Date != DateTime.MinValue)
            {
                SqlCommand komut = new SqlCommand("insert into Yazar (Adi,Soyadi,DogumTarihi,DogumYeri,OlumTarihi)values(@Adi,@Soyadi,@DogumTarihi,@DogumYeri,@OlumTarihi)", baglanti);
#pragma warning disable CS0618 // Tür veya üye eski
                komut.Parameters.Add("@Adi", YazarAdi);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
                komut.Parameters.Add("@Soyadi", Soyad);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
                komut.Parameters.Add("@DogumTarihi", dogum);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
                komut.Parameters.Add("@DogumYeri", DogumYeri);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
                komut.Parameters.Add("@OlumTarihi", Olum);
#pragma warning restore CS0618 // Tür veya üye eski
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                DataSet tablo = new DataSet();
                baglanti.Open();
                adaptor.Fill(tablo);
                baglanti.Close();
                Response.Redirect("KitapEkle.aspx");
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into Yazar (Adi,Soyadi,DogumTarihi,DogumYeri)values(@Adi,@Soyadi,@DogumTarihi,@DogumYeri)", baglanti);
#pragma warning disable CS0618 // Tür veya üye eski
                komut.Parameters.Add("@Adi", YazarAdi);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
                komut.Parameters.Add("@Soyadi", Soyad);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
                komut.Parameters.Add("@DogumTarihi", dogum);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
                komut.Parameters.Add("@DogumYeri", DogumYeri);
#pragma warning restore CS0618 // Tür veya üye eski
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                DataSet tablo = new DataSet();
                baglanti.Open();
                adaptor.Fill(tablo);
                baglanti.Close();
                Response.Redirect("KitapEkle.aspx");
            }



        }
    }
}