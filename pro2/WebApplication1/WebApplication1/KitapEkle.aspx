<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KitapEkle.aspx.cs" Inherits="WebApplication1.KitapEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Kitap adı: " Width="100px"></asp:Label> &nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Yayin Evi: " Width="100px"></asp:Label> &nbsp;
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Kitap Tanıtım Bilgisi: " Width="100px"></asp:Label> &nbsp;
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Yazar seçimi: " Width="100px"></asp:Label> &nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
    </asp:DropDownList> &nbsp;
    <asp:Label ID="Label5" runat="server" Text="Eğer Yazar ekli değilse: "></asp:Label> &nbsp;
    <asp:Button ID="Button1" runat="server" Text="Tıklayın!" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br /><br />
    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
    <br /><br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br /><br />
  


</asp:Content>