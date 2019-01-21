<%@ Page Title="OEM Certifications" Language="C#" MasterPageFile="~/MasterPage/MainMaster.Master"
    AutoEventWireup="true" CodeBehind="Certifications.aspx.cs" Inherits="SummitShopApp.Certifications" %>

<%@ MasterType VirtualPath="~/MasterPage/MainMaster.Master" %>
<%@ Register Src="~/Controls/SecurityCheck.ascx" TagName="Security" TagPrefix="SummitSecurity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <SummitSecurity:Security ID="SecurityCheck1" runat="server" />
    <asp:Panel ID="pnlVehicleStatusSetting" runat="server" Width="860">
        <table border="0" cellpadding="0" cellspacing="0" width="860" style="margin-top: 10px;
            margin-bottom: 20px;">
            <tr>
                <td align="left" valign="middle" style="padding: 5px;">
                    <span class="pageTitle">OEM Certifications</span>
                </td>
            </tr>
            <tr>
                <td align="left" valign="middle" style="padding: 10px 5px;">
                    <div class="contentText" style="float: left;">
                        This will include names and logos for programs that this is certified to repair
                        their vehicles. (BMW, Mercedes, etc)</div>
                    <div align="right">
                        <asp:ImageButton ID="btnCompanyInfo" runat="server" AlternateText="Back to Company Info"
                            ImageUrl="~/Images/BackCompInfp.jpg" OnClick="btnCompanyInfo_Click" />
                    </div>
                </td>
            </tr>
            <tr>
                <td align="left" valign="middle">
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tr>
                            <td colspan="3">
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td style="height: 13px; width: 13px; background: url(Images/tble_outline_top_lhs.gif) no-repeat;">
                                        </td>
                                        <td style="height: 13px; width: 97%; vertical-align: top;">
                                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                <tr>
                                                    <td style="height: 4px;width: 97%; background-color: #E0E0E0; vertical-align: top;">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="height: 13px; width: 13px; background: url(Images/tble_outline_top_rhs.gif) no-repeat;">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width: 4px; background-color: #E0E0E0">
                                        </td>
                                        <td>
                                            <asp:Panel ID="pnlVehicles" runat="server" Width="99%">
                                                <asp:CheckBoxList ID="chkVehicles" runat="server" RepeatColumns="3" CssClass="labelNormal"
                                                    Style="padding-left: 20px; width: 90%;" RepeatDirection="Vertical" OnDataBound="chkVehicles_DataBound">
                                                </asp:CheckBoxList>
                                            </asp:Panel>
                                        </td>
                                        <td style="width: 4px; background-color: #E0E0E0">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td style="height: 13px; width: 13px; background: url(Images/tble_outline_btm_lhs.gif) no-repeat;">
                                        </td>
                                        <td style="height: 13px; width: 97%; vertical-align: bottom;">
                                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                <tr>
                                                    <td style="height: 4px;width: 97%; background-color: #E0E0E0;">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="height: 13px; width: 13px; background: url(Images/tble_outline_btm_rhs.gif) no-repeat;">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 20px;">
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-left: 20px;">
                    <asp:Button ID="btnSave" runat="server" CssClass="inputButton" Text="Save" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
