<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/EmailMaster.Master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="SummitShopApp.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlMarketingGrid" runat="server" Width="860">
        <asp:GridView ID="gridviewMarketingCenter" runat="server" AllowSorting="True" AllowPaging="true" BorderColor="White"
            PageSize="5" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" BorderWidth="0px"
            GridLines="Both" CaptionAlign="Top" CellSpacing="2" Width="100%" HorizontalAlign="Left"
            OnPageIndexChanging="gridviewMarketingCenter_PageIndexChanging" OnRowCommand="gridviewMarketingCenter_RowCommand"
            OnSorting="gridviewMarketingCenter_Sorting">
            <RowStyle BackColor="White" CssClass="tableText" />
            <FooterStyle BackColor="#D6DAE2" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#D6DAE2" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#D6DAE2" CssClass="columnHeading" />
            <EditRowStyle BackColor="#D6DAE2" />
            <AlternatingRowStyle BackColor="#F2F4F8" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Width="30">
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="chkboxHeader" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkboxItem" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" SortExpression="Date" HeaderStyle-Width="60">
                    <ItemTemplate>
                        <div style="clear: both; float: left; width: 100%; text-align: left">
                            <%# getAppdownloadDate(DataBinder.Eval(Container.DataItem, "AppDownLoadDate"))%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Time" HeaderStyle-Width="55">
                    <ItemTemplate>
                        <div style="clear: both; float: left; width: 100%; text-align: left">
                            <%# getAppdownloadTime(DataBinder.Eval(Container.DataItem, "AppDownLoadDate"))%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" SortExpression="Name" HeaderStyle-Width="155">
                    <ItemTemplate>
                        <div style="clear: both; float: left; width: 100%; text-align: left">
                            <%# DataBinder.Eval(Container.DataItem, "UserName")%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Year Make Model">
                    <ItemTemplate>
                        <div style="clear: both; float: left; width: 100%; text-align: left">
                            <%# getVehicleInfo(DataBinder.Eval(Container.DataItem, "Year"), DataBinder.Eval(Container.DataItem, "Make"), DataBinder.Eval(Container.DataItem, "Model"))%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone" SortExpression="Phone" HeaderStyle-Width="100">
                    <ItemTemplate>
                        <div style="clear: both; float: left; width: 100%; text-align: left">
                            <asp:LinkButton ID="lnkbtnPhone" CommandName="SendSMS" runat="server"><%# DataBinder.Eval(Container.DataItem, "Phone") %></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" SortExpression="Email" HeaderStyle-Width="140">
                    <ItemTemplate>
                        <div style="clear: both; float: left; width: 100%; text-align: left">
                            <%# DataBinder.Eval(Container.DataItem, "Email")%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Zip Code" SortExpression="Zip" HeaderStyle-Width="60">
                    <ItemTemplate>
                        <div style="clear: both; float: left; width: 100%; text-align: left">
                            <%# DataBinder.Eval(Container.DataItem, "Zip")%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
