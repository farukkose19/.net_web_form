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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            
            string ad = TextBox1.Text;
            string soyad = TextBox2.Text;
            string kAdi = TextBox3.Text;
            string sifre = TextBox4.Text;
            string cinsiyet = TextBox5.Text;
            DateTime dogum = Calendar1.SelectedDate;

            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);
            int fileSize = postedFile.ContentLength;

            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

            string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolu"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);

            SqlCommand komut = new SqlCommand("insert into Kullanici (Ad,Soyad,Cinsiyet,KullaniciAdi,Sifre,Resim,DogumTarihi)values(@Ad,@Soyad,@Cinsiyet,@KullaniciAdi,@Sifre,@Resim,@DogumTarihi)", baglanti);
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@Ad", ad);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@Resim", bytes);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@Soyad", soyad);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@KullaniciAdi", kAdi);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@Sifre", sifre);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@Cinsiyet", cinsiyet);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@DogumTarihi", dogum);
#pragma warning restore CS0618 // Tür veya üye eski
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet tablo = new DataSet();
            baglanti.Open();
            adaptor.Fill(tablo);
            baglanti.Close();
        }
    }
}