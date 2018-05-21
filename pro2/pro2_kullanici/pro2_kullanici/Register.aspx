<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="pro2_kullanici.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <asp:Label ID="Label1" runat="server" Text="Ad:" Width="100px"></asp:Label> &nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="Label2" runat="server" Text="Soyad:" Width="100px"></asp:Label> &nbsp;
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="Label3" runat="server" Text="Kullanıcı Adı:" Width="100px"></asp:Label> &nbsp;
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="Label4" runat="server" Text="Şifre:" Width="100px"></asp:Label> &nbsp;
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="Label6" runat="server" Text="Cinsiyet:" Width="100px"></asp:Label> &nbsp;
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="Label5" runat="server" Text="Doğum Tarihi:" Width="100px"></asp:Label> &nbsp;
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    <br /><br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br /><br />
    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"  />
    <br /><br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br /><br />

</asp:Content>