<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="lab8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Students</title>
    <link href="App_Themes/Style/Stylesheet1.css" rel="stylesheet" />    
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap"
    rel="stylesheet">
</head>
<body>
    <h1>Students</h1>
    <form id="form1" runat="server">
        <div id="infoSection">
            <div>
                <asp:Label ID="studentNameLabel" text="Student name:" runat="server" CssClass="label" ></asp:Label>
                <asp:TextBox ID="studentNameBox" runat="server" CssClass="input"></asp:TextBox>
                <asp:Label ID="studentNameError" CssClass="error" runat="server" Text="Type the student's name"></asp:Label>

            </div>
            <div>
                <asp:Label ID="studentTypeLabel" text="Student type:" runat="server" CssClass="label"></asp:Label>
                <asp:DropDownList ID="studentTypeDropdown" runat="server" CssClass="input">
                    <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                    <asp:ListItem Text="Full-time" Value="fulltime"></asp:ListItem>
                    <asp:ListItem Text="Part-time" Value="parttime"></asp:ListItem>
                    <asp:ListItem Text="Co-op" Value="coop"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="studentTypeDropdownError" CssClass="error" runat="server" Text="Select the type for the student"></asp:Label>
            </div>
            <div>
                <asp:Button ID="addButton" text="Add" runat="server" OnClick="AddButton_Click" CssClass="button" />
            </div>
        </div>
    </form>
    <div id="tableSection">
        <asp:Table ID="studentTable" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableCell>ID</asp:TableCell>
                <asp:TableCell>Name</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <a href="RegisterCourse.aspx"><p>Register Courses</p></a>
</body>
</html>
