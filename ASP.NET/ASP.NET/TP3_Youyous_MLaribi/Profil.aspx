<%@ Page Title="Vagabones | Modifier profil" MasterPageFile="~/GabGeneral.Master" Language="C#" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="TP3_Youyous_MLaribi.profil" %>


<asp:Content ID="ContenuProfil" ContentPlaceHolderID="ContentPlaceHolderContenu" runat="server">
     <div id="frmInscription">

        <%-- Formulaire de modification de profil--%>
        <a class="titre">Modification du profil : </a>
    <br />
    <br />
        <%--Nom de l'usager --%>
    <div>
        <asp:Label ID="LabelNom" runat="server" Text="Nom : " 
            AssociatedControlID="txtNom"></asp:Label>
        <asp:TextBox ID="txtNom" runat="server" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNom" runat="server" 
            ControlToValidate="txtNom" CssClass="msg_erreur" ValidationGroup="valideModif"
            ErrorMessage="Vous devez entrer un nom">*</asp:RequiredFieldValidator>
    </div>
         <br />
        <%-- Prénom de l'usager--%>
    <div>
        <asp:Label ID="LabelPrenom" runat="server" Text="Prénom : " 
            AssociatedControlID="txtPrenom"></asp:Label>
        <asp:TextBox ID="txtPrenom" runat="server" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrenom" runat="server" 
            ControlToValidate="txtPrenom" CssClass="msg_erreur" ValidationGroup="valideModif"
            ErrorMessage="Vous devez entrer un prénom">*</asp:RequiredFieldValidator>
    </div>
        <%-- adresse de l'usager--%>
        <div>
        <asp:Label ID="LabelAdresse" runat="server" Text="Adresse : " 
            AssociatedControlID="txtAdresse"></asp:Label>
        <asp:TextBox ID="txtAdresse" runat="server" MaxLength="70"></asp:TextBox>
        <asp:RequiredFieldValidator ID="requiredAdresse" runat="server" 
            ControlToValidate="txtAdresse" CssClass="msg_erreur" ValidationGroup="valideModif"
            ErrorMessage="Vous devez entrer une adresse">*</asp:RequiredFieldValidator>
    </div>

        <%-- code postal de l'usager--%>
        <div>
        <asp:Label ID="LabelCodePostal" runat="server" Text="Code Postal (A1A 1A1) : " 
            AssociatedControlID="txtCodeP"></asp:Label>
        <asp:TextBox ID="txtCodeP" runat="server" MaxLength="7"></asp:TextBox>
    &nbsp;</div>
         <asp:RequiredFieldValidator ID="RequiredCodePostal" runat="server" ValidationGroup="valideModif" ControlToValidate="txtCodeP"
            CssClass="msg_erreur" ErrorMessage="Vous devez rentrer un code postal"></asp:RequiredFieldValidator>

         <%-- Ville de l'usager--%>
         <div>

               <asp:Label ID="LabelVile" runat="server" Text="Ville : " 
            AssociatedControlID="txtVille"></asp:Label>
        <asp:TextBox ID="txtVille" runat="server" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredVille" runat="server" 
            ControlToValidate="txtVille" CssClass="msg_erreur" ValidationGroup="valideModif"
            ErrorMessage="Vous devez entrer une ville">*</asp:RequiredFieldValidator>
    </div>

          </div>

        <%-- Numéro de téléphone de l'usager--%>
         <div>

        <asp:Label ID="LabelTelephone" runat="server" 
            AssociatedControlID="txtTelephone" Text="Numéro de téléphone : "></asp:Label>
        <asp:TextBox ID="txtTelephone" runat="server" MaxLength="14"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredTelephone" runat="server" 
            ControlToValidate="txtTelephone" CssClass="msg_erreur" ValidationGroup="valideModif"
            ErrorMessage="Vous devez entrer un numéro de téléphone"></asp:RequiredFieldValidator>
    </div>

        

         <br />

        <div>
             <%-- Type de d'usager--%>
        <asp:Label ID="lblType" runat="server" 
            AssociatedControlID="drdType" Text="Type d'inscrit : "></asp:Label>
        <asp:DropDownList ID="drdType" runat="server" >
             <asp:ListItem Value="c">Client Vagabones</asp:ListItem> 
            <asp:ListItem Value="e">Employé Vagabones</asp:ListItem>
        </asp:DropDownList>

    </div>
         <br />
        <%--Pseudo de l'usager--%>
    <div>
        <asp:Label ID="lblPseudo" runat="server" Text="Pseudo (non modifiable): " 
            AssociatedControlID="txtPseudo"></asp:Label>
        <asp:TextBox ID="txtPseudo" runat="server" MaxLength="12" Enabled ="false"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="ValidePseudo" runat="server" 
            ControlToValidate="txtPseudo" CssClass="msg_erreur" ValidationGroup="valideModif"
            ErrorMessage="Vous devez entrer un pseudo">*</asp:RequiredFieldValidator>--%>
    </div>
        <br />
        <%--  Mot de passe--%>
        <asp:Label ID="LabelMotPasse" runat="server" 
            AssociatedControlID="TextBoxMotPasse" Text="Mot de passe:"></asp:Label>
        <asp:TextBox ID="TextBoxMotPasse" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidatorMotPasse" runat="server" 
            ControlToCompare="TextBoxConfirmerMotPasse" ControlToValidate="TextBoxMotPasse" 
           CssClass="msg_erreur" Display="Dynamic" 
            ErrorMessage="Les mots de passe entrés doivent être pareils" ValidationGroup="valideModif">*</asp:CompareValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMotPasse" runat="server" 
            ControlToValidate="TextBoxMotPasse" CssClass="msg_erreur"
            Display="Dynamic" ErrorMessage="Le mot de passe est obligatoire" ValidationGroup="valideModif">*</asp:RequiredFieldValidator>
        <br />
        <%--  Confirmer mot de passe--%>
        <asp:Label ID="LabelConfirmerMotPasse" runat="server" 
            AssociatedControlID="TextBoxConfirmerMotPasse" 
            Text="Confirmer le mot de passe:"></asp:Label>
        <asp:TextBox ID="TextBoxConfirmerMotPasse" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>

    <div>

    </div>

    <div id="affErreur">
    <asp:ValidationSummary ID="ValideModification" runat="server" 
            CssClass="msg_erreur" ValidationGroup="valideModif" HeaderText="Veuillez corriger les erreurs suivantes: " />
    </div>

    <div>
        <br /><br />
        <asp:Button ID="btnModifier" runat="server" ValidationGroup="valideModif" OnClick="btnModifier_Click" 
            Text="Modifier" />
                <asp:Label ID="messagePost" runat="server" CssClass="msg_valide"></asp:Label>

        <br />
        <br />
    </div>
</asp:Content>