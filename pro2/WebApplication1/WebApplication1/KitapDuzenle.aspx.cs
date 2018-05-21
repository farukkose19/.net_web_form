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
    public partial class KitapDuzenle : System.Web.UI.Page
    {
        static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["Giris"]) == true)
            {
                if (!IsPostBack)
                {
                    id =Convert.ToInt32( Request.QueryString["id"]);

                    LoadImage();
                    bilgileriGetir();

                    DataSet yazarlar = YazarCek();
                    DropDownList1.DataTextField = "adsoyad";
                    DropDownList1.DataValueField = "YazarID";

                    ArrayList aList = new ArrayList();

                    DropDownList1.DataSource = yazarlar.Tables[0];
                    DropDownList1.DataBind();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }


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

        public void LoadImage()
        {
            string cs = ConfigurationManager.ConnectionStrings["baglantiYolu"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT k.KitapAdi, k.Resim, y.Adi as 'yazar adi', y.Soyadi as 'yazar soyadı', k.YayinEvi, k.KitapTanitimBilgisi FROM Kitap k inner join Yazar y on k.YazarID = y.YazarID where k.KitapID='"+ id + "'", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }
        }

        public void bilgileriGetir()
        {
            GridViewRow row = GridView1.Rows[0];
            TextBox1.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
            TextBox2.Text = HttpUtility.HtmlDecode(row.Cells[2].Text + " " + row.Cells[3].Text);
            TextBox3.Text = HttpUtility.HtmlDecode(row.Cells[4].Text);
            TextBox4.Text = HttpUtility.HtmlDecode(row.Cells[5].Text.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           

            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);
            int fileSize = postedFile.ContentLength;

            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

          
                int YazarID = Convert.ToInt32( DropDownList1.SelectedValue);
                string kitapAdi = TextBox1.Text;
                string YayinEvi = TextBox3.Text;
                string ktb = TextBox4.Text;

                string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolu"].ToString();
                SqlConnection baglanti = new SqlConnection(baglantiYolu);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Kitap SET KitapAdi = @KitapAdi, Resim = @Resim, YazarID = @YazarID, YayinEvi = @YayinEvi, KitapTanitimBilgisi = @KitapTanitimBilgisi where KitapID = @KitapID", baglanti);
#pragma warning disable CS0618 // Tür veya üye eski
                komut.Parameters.Add("@Resim", bytes);
#pragma warning restore CS0618 // Tür veya üye eski

#pragma warning disable CS0618 // Tür veya üye eski
                komut.Parameters.Add("@KitapID", id);
#pragma warning restore CS0618 // Tür veya üye eski

#pragma warning disable CS0618 // Tür veya üye eski
                komut.Parameters.Add("@KitapAdi", kitapAdi);
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
            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();
                LoadImage();
                bilgileriGetir();
            }
            catch(Exception exception)
            {
                string s = exception.ToString();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiYolu"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from Kitap where KitapID = @KitapID", baglanti);
#pragma warning disable CS0618 // Tür veya üye eski
            komut.Parameters.Add("@KitapID", id);
#pragma warning restore CS0618 // Tür veya üye eski

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();
                Response.Redirect("Default.aspx");
            }
            catch (Exception exception)
            {
                string s = exception.ToString();
            }
        }
    }
}