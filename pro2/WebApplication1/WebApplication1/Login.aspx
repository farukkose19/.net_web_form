<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <br />
      <div>
        <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı:" Width="100px"></asp:Label>

        <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Şifre:" Width="100px"></asp:Label>

        <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
        <br />
          <br />
          <span style="margin-left: 104px"></span>
        <asp:Button ID="Button1" runat="server"  Text="Giriş" OnClick="Button1_Click" Width="200px"   />
        </div>



</asp:Content>
