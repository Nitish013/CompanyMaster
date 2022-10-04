<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyViewPage.aspx.cs" Inherits="CompanyMaster.CompanyViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="YourGridview_RowCommand">
    <Columns>
        <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownload" Text="Show" CommandArgument='<%# Eval("ID") %>' runat="server" CommandName="Download"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
        <asp:LinkButton ID="lnkApproval" Text="Approve/Disapprove" CommandArgument='<%# Eval("ID") %>' runat="server" CommandName="Download"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>
</asp:GridView>
    </form>
          
</body>
</html>
