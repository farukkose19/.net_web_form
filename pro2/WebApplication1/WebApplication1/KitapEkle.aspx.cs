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
    public partial class KitapEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                DataSet yazarlar = YazarCek();
                DropDownList1.DataTextField = "adsoyad";
                DropDownList1.DataValueField = "YazarID";

                ArrayList aList = new ArrayList();

                DropDownList1.DataSource = yazarlar.Tables[0];
                DropDownList1.DataBind();


            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string YazarID = DropDownList1.SelectedValue;
            string kitapAdi = TextBox1.Text;
            string YayinEvi = TextBox2.Text;
            string ktb = TextBox3.Text;

            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);
            int fileSize = postedFile.ContentLength;

            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

            string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolu"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);

            SqlCommand komut = new SqlCommand("insert into Kitap (KitapAdi,Resim,YazarID,YayinEvi,KitapTanitimBilgisi)values(@KitapAdi,@Resim,@YazarID,@YayinEvi,@KitapTanitimBilgisi)", baglanti);
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@KitapAdi", kitapAdi);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@Resim", bytes);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@YazarID", YazarID);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@YayinEvi", YayinEvi);
#pragma warning restore CS0618 // Tür veya üye eski
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@KitapTanitimBilgisi", ktb);
#pragma warning restore CS0618 // Tür veya üye eski
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet tablo = new DataSet();
            baglanti.Open();
            adaptor.Fill(tablo);
            baglanti.Close();
        }

        public DataSet YazarCek()
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolu"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "select YazarID , CONCAT(Adi,' ', Soyadi) AS adsoyad from Yazar";
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            baglanti.Open();
            DataSet yazarlar = new DataSet();
            adaptor.Fill(yazarlar);
            baglanti.Close();

            return yazarlar;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("YazarEkle.aspx");
        }
    }
}