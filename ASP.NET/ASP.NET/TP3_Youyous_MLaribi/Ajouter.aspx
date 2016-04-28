<%@ Page Title="Vagabones | Ajouter" MasterPageFile="~/GabGeneral.Master" Language="C#" AutoEventWireup="true" CodeBehind="Ajouter.aspx.cs" Inherits="TP3_Youyous_MLaribi.Ajouter" %>

<asp:Content ID="ContenuAjouter" ContentPlaceHolderID="ContentPlaceHolderContenu" runat="server">
    <h1>Ajouter un item</h1>
    
    <!--Courte description -->
    <div id="frmAjout">
        <asp:Label ID="lblCourteDesc" runat="server" Text="Courte Description :" AssociatedControlID="txtCourteDesc"></asp:Label>
        <asp:TextBox ID="txtCourteDesc" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCourte" runat="server" ErrorMessage="Vous devez entrer une description"
           ControlToValidate="txtCourteDesc" CssClass="msg_erreur" ValidationGroup="ValidAjout" ></asp:RequiredFieldValidator>

        <!--Ajout image-->
        <asp:FileUpload ID="uploadImg" runat="server" />

        <!--Description detaillée-->
        <asp:Label ID="lblDescDet" runat="server" Text="Description détaillée :"
            associatedControlID="txtDescDetail"></asp:Label>
        <textarea id="txtDescDetail" runat="server" cols="20" rows="2"></textarea>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDetail" runat="server" ErrorMessage="Vous devez entrez une description"
            controltovalidate="txtDescDetail" CssClass="msg_erreur" ValidationGroup="ValidAjout"></asp:RequiredFieldValidator>

        <!--Prix-->
        <asp:Label ID="lblPrix" runat="server" Text="Prix :" AssociatedControlID="txtPrix"></asp:Label>
        <asp:TextBox ID="txtPrix" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrix" runat="server" ErrorMessage="Vous devez entrer un prix"
            ControlToValidate="txtPrix" CssClass="msg_erreur" ValidationGroup="ValidAjout"></asp:RequiredFieldValidator>

        <!-- Ajout -->
        <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" />

    </div>

</asp:Content>
