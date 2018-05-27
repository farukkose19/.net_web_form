<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand1">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="SendMail"
                            Text="Düzenle" CommandArgument='<%# Eval("KitapID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
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

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Kitap ekle" />

    </div>
        
</asp:Content>
