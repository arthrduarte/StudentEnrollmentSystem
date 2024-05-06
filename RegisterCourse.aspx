<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Course</title>
    <link href="App_Themes/Style/Stylesheet1.css" rel="stylesheet" />    
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap"
    rel="stylesheet">
</head>
<body>
    <h1>Enroll Students</h1>
    <form id="form1" runat="server">

        <div id="infoSection">
            <div>
                <asp:Label ID="studentLabel" runat="server" Text="Student:" CssClass="label">
                    <asp:DropDownList id="studentDropdownList" runat="server" CssClass="input" AutoPostBack="true" OnSelectedIndexChanged="StudentDropdownDifferentSelection"></asp:DropDownList>
                </asp:Label>
                <asp:Label id="studentDropdownError" CssClass="error label" runat="server" Text="You must select a student"></asp:Label>
            </div>
        </div>
        
        <div id="selectedCoursesSection">
            <asp:Label ID="selectedCoursesInfo" runat="server" Visible="false"></asp:Label>
        </div>
        
        <asp:Panel ID="availableCourses" runat="server">
            <asp:Label ID="availableCoursesLabel" text="The following courses are currently available for registration:" runat="server">
                <asp:CheckBoxList ID="availableCoursesList" runat="server"></asp:CheckBoxList>
            </asp:Label>
        </asp:Panel>
        <asp:Button ID="submitButton" text="Submit" runat="server" OnClick="SubmitButton_Click" CssClass="button"/>
    </form>
    <a href="AddStudent.aspx"><p>Add Students</p></a>
</body>
</html>
