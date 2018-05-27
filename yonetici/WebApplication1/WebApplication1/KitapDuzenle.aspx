<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KitapDuzenle.aspx.cs" Inherits="WebApplication1.KitapDuzenle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>

    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
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
        <asp:Label ID="Label5" runat="server" Text="Resmi değiştirmek için: " Width="300px"></asp:Label> 
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br /><br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br /><br />

        <asp:Label ID="Label1" runat="server" Text="Kitap Adı: " Width="100px"></asp:Label> &nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        <br />

        <asp:Label ID="Label2" runat="server" Text="Yazari: " Width="100px"></asp:Label> &nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> &nbsp; <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>

        <br />

        <asp:Label ID="Label3" runat="server" Text="Yayin Evi: " Width="100px"></asp:Label> &nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label4" runat="server" Text="içerik: " Width="100px"></asp:Label> &nbsp;
        <asp:TextBox ID="TextBox4" runat="server" Width="5000px" Height="300px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Düzenle" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Sil" OnClick="Button2_Click" />
</div>
</asp:Content>