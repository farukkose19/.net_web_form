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
    public partial class Mesaj : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("select m.MesajID, m.GonderenID, k.KullaniciAdi, m.Mesaj,m.Tarih,m.Baslik from Mesaj m inner join Kullanici k on m.GonderenID=k.KullaniciID where m.AliciID=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string kadi = e.CommandArgument.ToString();
            Response.Redirect("MesajGonder.aspx?KullaniciAdi="+ kadi);
        }
    }
}