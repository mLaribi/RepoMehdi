<%@ Page Title="Vagabones | Mon panier" MasterPageFile="~/GabGeneral.Master" Language="C#" AutoEventWireup="true" CodeBehind="Panier.aspx.cs" Inherits="TP3_Youyous_MLaribi.Panier" %>

<asp:Content ID="ContenuPanier" ContentPlaceHolderID="ContentPlaceHolderContenu" runat="server">

    <img id="logoPanier" src="images/panier.png" alt="Panier"/>
    <h1 id="titre">Votre Panier</h1>

    <div id="article">
        <div id="articlesHeader">
            <table>
                <tr>
                    <td id="premier">Articles du panier</td>
                    <td>Prix à l'unité</td>
                    <td>Quantité</td>
                    <td>Sous-Total</td>
                </tr>
            </table>
        </div>
<%--        <div id="articleObjet">
            <asp:DataList ID="objetPanier" runat="server">
                <ItemTemplate>

                </ItemTemplate>
            </asp:DataList>

         </div>--%>
    </div>

    <div id="sommaire">
        <div id="lblSommaire">
            <h2>Sommaire de la commande</h2>
            <ul>
                <li>Total des produits</li>
                <li>TPS (5%)</li>
                <li>TVQ (9.975%)</li>
                <li>Total</li>
            </ul>
            
        </div>
        <div id="lblAffSommaire">
            <ul>
                <li>Total des produits</li>
                <li>TPS (5%)</li>
                <li>TVQ (9.975%)</li>
                <li>Total</li>
                <li><asp:Label ID="lblAffTotal" runat="server" Text=""></asp:Label></li>
                <li><asp:Label ID="lblAffTPS" runat="server" Text=""></asp:Label></li>
                <li><asp:Label ID="lblAffTVQ" runat="server" Text=""></asp:Label></li>
                <li><asp:Label ID="lblAffTotalApres" runat="server" Text=""></asp:Label></li>
            </ul>
        </div>
        <asp:Button ID="btnCommander" runat="server" Text="Commander" />
    </div>

</asp:Content>
