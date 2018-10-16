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
    </div>
    </form>
</body>
</html>
