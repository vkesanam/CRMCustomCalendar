<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomEntityCalendar.aspx.cs" Inherits="CRMCustomCalendar.CustomEntityCalendar" %>

<%@ Register TagPrefix="EXXRM" Namespace="ExtendedCalendar" Assembly="ExtendedCalendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Exploring XRM - Custom Entity Calendar</title>
    <style type="text/css">
    .aspbutton
    {
        background-color:Black;
        color:White;
        font-weight:bold;
    }
    </style>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=TextBox1.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%Y/%m/%d %H:%M",
            daFormat: "%l;%M %p, %e %m,  %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
</script>
    <script type="text/javascript">
    $(document).ready(function () {
        $("#<%=TextBox2.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%Y/%m/%d %H:%M",
            daFormat: "%l;%M %p, %e %m,  %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <EXXRM:ExtCalendar ID="CCGlobalCalendar" runat="server" BackColor="White" 
        BorderWidth="2px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="400px"
        Width="80%" FirstDayOfWeek="Sunday" NextMonthText="Next &gt;" PrevMonthText="&lt; Prev"
        ShowDescriptionAsToolTip="True" EventDateColumnName="" EventDescriptionColumnName=""
        EventHeaderColumnName="" CellPadding="2" DayNameFormat="Full" 
        EventBackColorName="" EventEndDateColumnName="" EventForeColorName="" 
        EventStartDateColumnName="">
        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
        <OtherMonthDayStyle ForeColor="#999999" BackColor="Silver"/>
        <SelectedDayStyle BackColor="#E6EDF7" Font-Bold="True" ForeColor="#CCFF99" />
        <SelectorStyle BorderColor="#E6EDF7" BorderStyle="Solid" BackColor="#99CCCC" 
            ForeColor="#336666" />
        <DayStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"/>
        <DayHeaderStyle BorderWidth="1px" Font-Bold="True" Font-Size="8pt" 
            BackColor="#A5BFE1" ForeColor="#336666" Height="1px" />
        <TitleStyle BackColor="SteelBlue" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
            Font-Size="10pt" ForeColor="White" HorizontalAlign="Center" 
            VerticalAlign="Middle" Height="25px" />
        <TodayDayStyle BackColor="#FFDC6D" ForeColor="White" />
        <WeekendDayStyle BackColor="AliceBlue" />
    </EXXRM:ExtCalendar>
        <asp:HiddenField ID="hdnLeadNo" runat="server" />
         <asp:HiddenField ID="hdnFullName" runat="server" />
         <asp:HiddenField ID="hdnLeadGuid" runat="server" />
        </br>
        <asp:Label ID="Label1" runat="server" Text="Start Date & Time"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" ReadOnly = "true"></asp:TextBox><img src="calender.png" />
<asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="TextBox1" errormessage="Please select the date!" />
        

        </br>
                <asp:Label ID="Label2" runat="server" Text="End Date & Time"></asp:Label>
          <asp:TextBox ID="TextBox2" runat="server" ReadOnly = "true"></asp:TextBox><img src="calender.png" />
        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="TextBox2" errormessage="Please select the date!" />

        </br>
<asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" /></div>
    </form>
</body>
</html>
