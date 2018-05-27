<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KullaniciDetay.aspx.cs" Inherits="pro2_kullanici.KullaniciDetay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div>
        <table style="width:20%; padding:0px; float:left "  >
            <tr >
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Kitap Ara" style="width:200px" />
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Kullanıcı Ara" style="width:200px"/>
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="Yazar Ara" style="width:200px" />
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="Popüler Kitaplar" style="width:200px"/>
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="Yüksek Puanlı Kitaplar" style="width:200px"/>
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button6" runat="server" Text="Popüler Yazarlar" style="width:200px"/>
                </td>
            </tr>
        </table>
    </div>

    <div style="width:80%; padding:0px; float:right; height:100% " >
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   >
            <Columns>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="50px"
                            ImageUrl='<%# "data:Image/png;base64,"
                            + Convert.ToBase64String((byte[])Eval("Resim")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="KullaniciAdi" HeaderText="Kullanıcı Adı" />
                <asp:BoundField DataField="Ad" HeaderText="Ad" />
                <asp:BoundField DataField="Soyad" HeaderText="Soyad" />
                <asp:BoundField DataField="Cinsiyet" HeaderText="Cinsiyet" />
                <asp:BoundField DataField="DogumTarihi" HeaderText="Doğum Tarihi" />

            </Columns>
        </asp:GridView>
    <br />
        <asp:Button ID="Button7" runat="server" Text="Mesaj Gönder" OnClick="Button7_Click" />
    <h1 style="align-content:center">Okuduğu Kitaplar</h1>
          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"   >
            <Columns>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="50px"
                            ImageUrl='<%# "data:Image/png;base64,"
                            + Convert.ToBase64String((byte[])Eval("Resim")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="KitapAdi" HeaderText="Kitap Adı" />

            </Columns>
        </asp:GridView>


     <h1 style="align-content:center">Kitaplara Verdiği Puanlar</h1>
          <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"   >
            <Columns>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="50px"
                            ImageUrl='<%# "data:Image/png;base64,"
                            + Convert.ToBase64String((byte[])Eval("Resim")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="KitapAdi" HeaderText="Kitap Adı" />
                <asp:BoundField DataField="Puan" HeaderText="Kitap Adı" />

            </Columns>
        </asp:GridView>
        
        <h1 style="align-content:center">Yaptığı incelemeler</h1>
          <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False"   >
            <Columns>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="50px"
                            ImageUrl='<%# "data:Image/png;base64,"
                            + Convert.ToBase64String((byte[])Eval("Resim")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="KitapAdi" HeaderText="Kitap Adı" />
                <asp:BoundField DataField="Inceleme" HeaderText="Kitap Adı" />

            </Columns>
        </asp:GridView>

        <h1 style="align-content:center">Yaptığı Alıntılar</h1>
          <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False"   >
            <Columns>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="50px"
                            ImageUrl='<%# "data:Image/png;base64,"
                            + Convert.ToBase64String((byte[])Eval("Resim")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="KitapAdi" HeaderText="Kitap Adı" />
                <asp:BoundField DataField="SayfaNo" HeaderText="Kitap Adı" />
                <asp:BoundField DataField="Cumle" HeaderText="Kitap Adı" />

            </Columns>
        </asp:GridView>
        </div>
    </asp:Content>