<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyMaster.aspx.cs" Inherits="CompanyMaster.CompanyMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<style>
    button 
    {
        background-color: red;
        color: white;
        padding: 14px 20px;
        margin: 8px 0;
        border: none;
        cursor: pointer;
    }
</style>
    <form id="form1" runat="server">
        <div>
             <b><label for="name">Enter your name :</label></b>
             <asp:TextBox ID="name" runat="server" ></asp:TextBox>  
              
             <br><br>

             <b><asp:FileUpload id="fileupLoad" runat="server" /></b><br /><br />
             <asp:Button id="button" Text="Submit" runat="server" Width="100px" OnClick="btnLogin_Click" /><br><br>
             
             <hr />
             <asp:Label ID="lblMessage" ForeColor="Green" runat="server" />

        </div>
    </form>
</body>
</html>
