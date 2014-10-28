<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    Search film information by name<br />
    <asp:TextBox ID="TextBox1" runat="server" Width="323px" ></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="Confirm" OnClick="Button2_Click" />
    <br />
    <asp:TextBox ID="TextBox4" runat="server" Height="126px" Width="697px" Rows="10" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <br />
    Rate a film by name<br />
    <asp:Literal ID="Literal11" runat="server" Text="Film Name"></asp:Literal>
    <asp:TextBox ID="TextBox5" runat="server" ></asp:TextBox>
    <br />
    <asp:Literal ID="Literal12" runat="server" Text="Your Score"></asp:Literal>
    <asp:TextBox ID="TextBox19" runat="server" ></asp:TextBox>
    <br />
    <asp:Button ID="Button3" runat="server" Text="Confirm" OnClick="Button3_Click" />
    <br />
    <asp:TextBox ID="TextBox6" runat="server" Height="29px" Width="426px"></asp:TextBox>
    <br />
    <br />
    <br />

    Search a film through director name<br />
    <asp:TextBox ID="TextBox7" runat="server" ></asp:TextBox>
    <asp:Button ID="Button4" runat="server" Text="Confirm" OnClick="Button4_Click" />
    <br />
    <asp:TextBox ID="TextBox8" runat="server" Height="108px" Width="426px" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <br />

    Search a film through actor name<br />
    <asp:TextBox ID="TextBox9" runat="server" ></asp:TextBox>
    <asp:Button ID="Button5" runat="server" Text="Confirm" OnClick="Button5_Click" />
    <br />
    <asp:TextBox ID="TextBox10" runat="server" Height="87px" Width="426px" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <br />
    Seach through actors and directors<br />
    <asp:Literal ID="Literal16" runat="server" Text="Actor"></asp:Literal>
    <asp:TextBox ID="TextBox26" runat="server"></asp:TextBox>
    <br />
    <asp:Literal ID="Literal17" runat="server" Text="Director"></asp:Literal>
    <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button9" runat="server" Text="Confirm" OnClick="Button9_Click" />
    <br />
    <asp:TextBox ID="TextBox28" runat="server" Height="87px" Width="426px" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    Search a film through type<br />
    <asp:TextBox ID="TextBox23" runat="server" ></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Confirm" OnClick="Button1_Click" />
    <br />
    <asp:TextBox ID="TextBox24" runat="server" Height="87px" Width="426px" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    Order by IMDB score<asp:Button ID="Button8" runat="server" Text="Confirm" OnClick="Button8_Click" />
    <br />
    <asp:TextBox ID="TextBox25" runat="server" Height="103px" TextMode="MultiLine" Width="410px" ></asp:TextBox>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    Add a review to a film<br />
    <asp:Literal ID="Literal1" runat="server" Text="Film name"></asp:Literal>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:Literal ID="Literal2" runat="server" Text="Your review"></asp:Literal>
    <asp:TextBox ID="TextBox11" runat="server" Width="792px"></asp:TextBox>
    <br />
    <asp:Button ID="Button7" runat="server" Text="Confirm" OnClick="Button7_Click" />

    <br />
    <br />
    <br />
    Film information after review<br />
    <asp:TextBox ID="TextBox3" runat="server" Height="119px" Width="784px" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Literal ID="Literal3" runat="server" Text="Add a film"></asp:Literal>
    <br />
    <asp:Literal ID="Literal4" runat="server" Text="Film name      "></asp:Literal>
    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
    <br />
    <asp:Literal ID="Literal5" runat="server" Text="Year          "></asp:Literal>
    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
    <br />
    <asp:Literal ID="Literal6" runat="server" Text="Actors          "></asp:Literal>
    <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
    <br />
    <asp:Literal ID="Literal7" runat="server" Text="Director          "></asp:Literal>
    <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
    <br />
    <asp:Literal ID="Literal8" runat="server" Text="IMDB NO          "></asp:Literal>
    <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
    <br />
    <asp:Literal ID="Literal9" runat="server" Text="IMDB SCORE          "></asp:Literal>
    <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
    
    <br />
    <asp:Literal ID="Literal15" runat="server" Text="Type                  "></asp:Literal>
    <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
    
    <br />
    <asp:Literal ID="Literal13" runat="server" Text="Storyline           "></asp:Literal>
    <asp:TextBox ID="TextBox20" runat="server" Width="794px" TextMode="MultiLine"></asp:TextBox>
    
    <br />
    <asp:Literal ID="Literal14" runat="server" Text="Review               "></asp:Literal>
    <asp:TextBox ID="TextBox21" runat="server" Width="828px" TextMode="MultiLine"></asp:TextBox>
    
    <br />
    <br />
    <asp:Button ID="Button6" runat="server" Text="Confirm" OnClick="Button6_Click" />

    <br />
    <br />
    <br />

    <br />
    <asp:Literal ID="Literal10" runat="server" Text="result          "></asp:Literal>
    <asp:TextBox ID="TextBox18" runat="server" Height="111px" TextMode="MultiLine" Width="874px"></asp:TextBox>
    <br />
    <br />
    <br />
    <br />
    <br />
    
</asp:Content>
