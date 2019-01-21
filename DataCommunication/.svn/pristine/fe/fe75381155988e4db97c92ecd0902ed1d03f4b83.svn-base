<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxCallBack.aspx.cs" Inherits="SummitShopApp.AjaxCallBack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Script Callback Sample</title>
    <script type="text/javascript">
        function RateContent(result, context)
    {debugger;
        document.getElementById('Result').innerHTML = result;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer runat="server" id="UpdateTimer" interval="5000" ontick="UpdateTimer_Tick" />
        <asp:UpdatePanel runat="server" id="TimedPanel" updatemode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="UpdateTimer" eventname="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label runat="server" id="DateStampLabel" />
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    </form>
</body>
</html>
