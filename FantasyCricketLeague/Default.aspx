<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FantasyCricketLeague._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <table style="width: 100%;">
        <tr>
            <td>Team</td>
            <td> <asp:DropDownList ID="TeamDropDownList" runat="server" OnSelectedIndexChanged="TeamDropDownList_SelectedIndexChanged">
                <asp:ListItem>Kolkata Knight Riders</asp:ListItem>
                <asp:ListItem>Deccan Chargers</asp:ListItem>
                <asp:ListItem>Kings XI Punjab</asp:ListItem>
                <asp:ListItem>Rajasthan Royals</asp:ListItem>
                <asp:ListItem>Kochi Tuskers Kerala</asp:ListItem>
                <asp:ListItem>Chennai Super Kings</asp:ListItem>
                <asp:ListItem>Mumbai Indians</asp:ListItem>
                <asp:ListItem>Sunrisers Hyderabad</asp:ListItem>
                <asp:ListItem>Royal Challengers Bangalore</asp:ListItem>
                <asp:ListItem>Delhi Daredevils</asp:ListItem>
                <asp:ListItem>Pune Warriors</asp:ListItem>
                </asp:DropDownList></td>
            <td>Name</td>
            <td> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>Runs</td>
            <td> <asp:DropDownList ID="RunsDropDownList" runat="server" OnSelectedIndexChanged="RunsDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
            <td>Average</td>
            <td> <asp:DropDownList ID="AverageDropDownList" runat="server">
                <asp:ListItem>&gt;=0 &lt;10</asp:ListItem>
                <asp:ListItem>&gt;=10 &lt;20</asp:ListItem>
                <asp:ListItem>&gt;=20 &lt;30</asp:ListItem>
                <asp:ListItem>&gt;=30 &lt;40</asp:ListItem>
                <asp:ListItem>&gt;=40</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
         <tr>
            <td>Striker Rate</td>
            <td> <asp:DropDownList ID="StrikerRateDropDownList" runat="server">
                <asp:ListItem>&gt;=0 &lt;20</asp:ListItem>
                <asp:ListItem>&gt;=20 &lt;40</asp:ListItem>
                <asp:ListItem>&gt;=40 &lt;60</asp:ListItem>
                <asp:ListItem>&gt;=60 &lt;80</asp:ListItem>
                <asp:ListItem>&gt;=80 &lt;100</asp:ListItem>
                <asp:ListItem>&gt;=100 &lt;120</asp:ListItem>
                <asp:ListItem>&gt;=120 &lt;140</asp:ListItem>
                <asp:ListItem>&gt;=140 &lt;160</asp:ListItem>
                <asp:ListItem>&gt;=160 &lt;180</asp:ListItem>
                <asp:ListItem>&gt;=180 &lt;200</asp:ListItem>
                <asp:ListItem>&gt;=200</asp:ListItem>
                <asp:ListItem></asp:ListItem>
                </asp:DropDownList></td>
            <td>Balls Played</td>
            <td> <asp:DropDownList ID="BallsPlayedDropDownList" runat="server"></asp:DropDownList></td>
        </tr>
         <tr>
            <td>Half Centuries</td>
            <td> <asp:DropDownList ID="HCDropDownList" runat="server"></asp:DropDownList></td>
            <td>Centuries</td>
            <td> <asp:DropDownList ID="CentDropDownList" runat="server"></asp:DropDownList></td>
        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" CssClass="btn btn-primary"/>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    
</asp:Content>
