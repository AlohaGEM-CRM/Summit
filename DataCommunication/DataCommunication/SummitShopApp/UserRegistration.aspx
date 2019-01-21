<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="SummitShopApp.UserRegistration" %>



<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
  <link rel="stylesheet" media="handheld,screen" href="../App_Themes/Theme1/Style1.css" type="text/css" />
</asp:Content> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Label runat="server" ID="lblStatus" ForeColor="Red"></asp:Label>

    <p runat="server" id ="tilteText" class="TitleTextBack">
        List of Rental Car Companies
    </p>
</asp:Content>
 