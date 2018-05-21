<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pro2_kullanici._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div>
        <table style="width:20%; padding:0px; float:left "  >
            <tr >
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Kitap Ara" style="width:200px" OnClick="Button1_Click"/>
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Kullanıcı Ara" style="width:200px" OnClick="Button2_Click"/>
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="Yazar Ara" style="width:200px" OnClick="Button3_Click" />
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="Popüler Kitaplar" style="width:200px" OnClick="Button4_Click"/>
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="Yüksek Puanlı Kitaplar" style="width:200px" OnClick="Button5_Click"/>
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button6" runat="server" Text="Popüler Yazarlar" style="width:200px" OnClick="Button6_Click"/>
                </td>
            </tr>
        </table>
    </div>

    <div style="width:80%; padding:0px; float:right; height:100% " >
        <h1>Kullanıcı Öneri 1:</h1>
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
                <asp:BoundField DataField="ortakkitap" HeaderText="ortak kitap sayısı" />
            </Columns>
        </asp:GridView>

         <h1>Kullanıcı Öneri 2:</h1>
         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"   >
            <Columns>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="50px"
                            ImageUrl='<%# "data:Image/png;base64,"
                            + Convert.ToBase64String((byte[])Eval("kitapResim")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="KitapAdi" HeaderText="Kitap Adı" />

                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="50px"
                            ImageUrl='<%# "data:Image/png;base64,"
                            + Convert.ToBase64String((byte[])Eval("kullaniciResim")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="KullaniciAdi" HeaderText="Kullanıcı Adı" />
                <asp:BoundField DataField="Puan" HeaderText="Ortak Puan" />
            </Columns>
        </asp:GridView>

                 <h1>Kullanıcı Öneri 3:</h1>
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
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
