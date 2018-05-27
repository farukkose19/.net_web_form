<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KitapDetay.aspx.cs" Inherits="pro2_kullanici.KitapDetay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div style="width:20%; padding:0px; float:left; height:100% " >
        <table  >
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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  >
            <Columns>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="100px" Width="50px"
                    ImageUrl='<%# "data:Image/png;base64,"
                    + Convert.ToBase64String((byte[])Eval("Resim")) %>' />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="KitapAdi" HeaderText="KitapAdi" />
                <asp:BoundField DataField="yazar adi" HeaderText="yazar adi" />
                <asp:BoundField DataField="yazar soyadı" HeaderText="yazar soyadı" />
                <asp:BoundField Datafield="YayinEvi" HeaderText="YayinEvi"/>
                <asp:BoundField Datafield="KitapTanitimBilgisi" HeaderText="KitapTanitimBilgisi"/>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Kitabın Puanı:" Width="150px"></asp:Label> &nbsp
        <asp:TextBox ID="TextBox1" runat="server" Width="250px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Kitabın Okunma Sayısı: " Width="150px" ></asp:Label> &nbsp
        <asp:TextBox ID="TextBox2" runat="server" Width="250px"></asp:TextBox>

        <br />
        <br />
        <div>

        <asp:Button ID="Button9" runat="server" Text="Okudum" OnClick="Button9_Click" />
        <br />

        <asp:Label ID="Label6" runat="server" Text="Incelemem: "  Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="Button8" runat="server" Text="Kaydet" OnClick="Button8_Click" />

        <br />
            <br />
        <asp:Label ID="Label7" runat="server" Text="Alıntım: "  Width="100px"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="SayfaNo: "  Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:Button ID="Button7" runat="server" Text="Kaydet" OnClick="Button7_Click" />
            <br />
            <br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <asp:Button ID="Button10" runat="server" Text="Puan Ver" OnClick="Button10_Click" />
        </div>
        <br />
        <br />
        
        <div style="width:50%; padding:0px; float:left; height:100% "> 

            <asp:Label ID="Label3" runat="server" Text="Incelemeler:"></asp:Label> &nbsp
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  >
                <Columns> 
                    <asp:BoundField DataField="adsoyad" HeaderText="ad soyad" />
                    <asp:BoundField DataField="Inceleme" HeaderText="Inceleme" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
        <div style="width:50%; padding:0px; float:right; height:100% "> 
            <asp:Label ID="Label4" runat="server" Text="Alıntılar:"></asp:Label> &nbsp
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"  >
                <Columns> 
                    <asp:BoundField DataField="adsoyad" HeaderText="ad soyad" />
                    <asp:BoundField DataField="Cumle" HeaderText="Cumle" />
                    <asp:BoundField DataField="SayfaNo" HeaderText="Sayfa no" />
                </Columns>
            </asp:GridView>
        </div>
        </div>


        </div>
</asp:Content>