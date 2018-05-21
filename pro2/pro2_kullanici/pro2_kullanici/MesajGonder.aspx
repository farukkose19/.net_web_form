<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MesajGonder.aspx.cs" Inherits="pro2_kullanici.MesajGonder" %>

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
                    <asp:Button ID="Button2" runat="server" Text="Kullanıcı Ara" style="width:200px" />
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="Yazar Ara" style="width:200px"  />
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
        <asp:Label ID="Label1" runat="server" Text="Alıcı Kullanıcı Adi:" Width="150px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="Mesaj başlığı:" Width="150px"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label3" runat="server" Text="Mesaj:" Width="150px"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Height="100px"></asp:TextBox>
        <br /><br />
        <asp:Button ID="Button7" runat="server" Text="Gonder" OnClick="Button7_Click" />
    </div>
</asp:Content>