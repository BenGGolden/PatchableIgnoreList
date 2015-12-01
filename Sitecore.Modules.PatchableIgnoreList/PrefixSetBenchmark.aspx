<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrefixSetBenchmark.aspx.cs" Inherits="Sitecore.Modules.PatchableIgnoreList.PrefixSetBenchmark" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label>Prefix Set Size:
                <asp:TextBox runat="server" ID="PrefixSetSizeTextBox" Text="10"></asp:TextBox></asp:Label>
        </div>
        <div>
            <asp:Label>Test Set Size:
                <asp:TextBox runat="server" ID="TestSetSizeTextBox" Text="1000"></asp:TextBox></asp:Label>
        </div>
        <div>
            <asp:Button runat="server" ID="RunButton" OnClick="RunButton_OnClick" Text="Run Test" /><br />
            <br />
        </div>
        <% if (ListTime > 0 && TrieTime > 0) { %>
        <div>
            <b>List Time:</b>
            <%= ListTime.ToString("N0") %> ns
        </div>
        <div>
            <b>Trie Time:</b>
            <%= TrieTime.ToString("N0") %> ns
        </div>
        <div>
            <b>Winner:</b> <%= TrieTime > ListTime ? "List" : "Trie" %>
            by <%= Math.Abs(ListTime - TrieTime).ToString("N0") %> ns
            (<%= (Math.Abs(ListTime - TrieTime)/Math.Max(ListTime, TrieTime)).ToString("P2") %>)
        </div>
        <% } %>
    </form>
</body>
</html>
