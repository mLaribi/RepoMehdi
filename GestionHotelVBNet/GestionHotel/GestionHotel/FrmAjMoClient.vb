'******************************************************************************
'Programmeur : Mehdi Laribi
'Date de remise : 24/11/2014
'Ce même jour, je suis devenu Canadien. À 14h
'******************************************************************************
Imports System.Data.SqlClient
Public Class FrmAjMoClient
    ''' <summary>
    ''' Mode qui sera utilisé (modification ou ajout)
    ''' </summary>
    ''' <remarks></remarks>
    Private _mode As FrmPrincipal.ModeAjoutModif
    ''' <summary>
    ''' Client
    ''' </summary>
    ''' <remarks></remarks>
    Private _client As Client


#Region "Propriétés"
    ''' <summary>
    ''' Mode formulaire
    ''' </summary>
    ''' <value>Nouveau mode</value>
    ''' <returns>Mode du formulaire</returns>
    ''' <remarks>Modifier ou ajouter selon le cas</remarks>
    Public Property ModeClient As FrmPrincipal.ModeAjoutModif
        Get
            Return Me._mode
        End Get
        Set(value As FrmPrincipal.ModeAjoutModif)
            Me._mode = value
        End Set
    End Property
    ''' <summary>
    ''' Propriété client
    ''' </summary>
    ''' <value>Nouveau client</value>
    ''' <returns>Un client</returns>
    ''' <remarks></remarks>
    Public Property Client As Client
        Get
            Return Me._client
        End Get
        Set(value As Client)
            Me._client = value
        End Set
    End Property
#End Region

    ''' <summary>
    ''' COnstructeur par défaut
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
    End Sub
    ''' <summary>
    ''' Constructeur qui initialise les variable du client a modifier
    ''' </summary>
    ''' <param name="clientModif"></param>
    ''' <remarks></remarks>
    Public Sub New(clientModif As Client)
        InitializeComponent()
        _client = clientModif
    End Sub

    ''' <summary>
    ''' Au démarrage de la fenêtre
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmAjMoClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Me.ModeClient = FrmPrincipal.ModeAjoutModif.Ajout) Then
            Me.btnAjMo.Text = "Ajouter"
            Me.lblTitre.Text = "Ajout d'un client"
            Me.Text = "Ajout"
        Else
            Me.btnAjMo.Text = "Modifier"
            Me.lblTitre.Text = "Modifier le client"
            Me.Text = "Modification"
            Me.txtNom.Text = _client.Nom
            Me.txtNumGauche.Text = String.Format(_client.Telephone.Substring(0, 3))
            Me.txtNumMilieu.Text = String.Format(_client.Telephone.Substring(4, 3))
            Me.txtNumDroite.Text = String.Format(_client.Telephone.Substring(8, 4))
            Me.txtNote.Text = _client.Note
        End If

    End Sub
    ''' <summary>
    ''' Bouton ajouter ou modifier un client
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAjMo_Click(sender As Object, e As EventArgs) Handles btnAjMo.Click
        If (ModeClient = FrmPrincipal.ModeAjoutModif.Ajout) Then
            Try
                Using connexion As New SqlConnection(Bd.Source)
                    connexion.Open()
                    Dim commande As New SqlCommand(Bd.Client.Inserer, connexion)
                    commande.Parameters.AddWithValue("@nom", Me.txtNom.Text)
                    commande.Parameters.AddWithValue("@telephone", (txtNumGauche.Text & "-" & txtNumMilieu.Text & "-" & txtNumDroite.Text))
                    commande.Parameters.AddWithValue("@note", txtNote.Text)

                    Dim id As Integer = DirectCast(commande.ExecuteScalar(), Integer)
                    DialogResult = Windows.Forms.DialogResult.OK
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.ToString())

            End Try


        Else


            Try
                Using connexion As New SqlConnection(Bd.Source)
                    connexion.Open()
                    Dim commande As New SqlCommand(Bd.Client.MAJ, connexion)

                    commande.Parameters.AddWithValue("@nom", txtNom.Text)
                    commande.Parameters.AddWithValue("@telephone", (txtNumGauche.Text & "-" & txtNumMilieu.Text & "-" & txtNumDroite.Text))
                    commande.Parameters.AddWithValue("@note", txtNote.Text)
                    commande.Parameters.AddWithValue("@id", Me._client.Id)

                    commande.ExecuteNonQuery()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub
    ''' <summary>
    ''' Bouton annuler
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' Validation pour le nom du client
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtNom_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNom.Validating
        If (String.IsNullOrWhiteSpace(txtNom.Text)) Then
            gestErreur.SetError(txtNom, "Veuillez entrez un nom pour continuer")
        Else
            gestErreur.SetError(txtNom, "")
        End If
    End Sub
    ''' <summary>
    ''' Validation pour le numéro de téléphone
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtNumGauche_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNumGauche.Validating
        If (Char.IsLetter(txtNumGauche.Text) OrElse String.IsNullOrWhiteSpace(txtNumGauche.Text)) Then
            gestErreur.SetError(txtNumDroite, "Veuillez entrez un numéro valide")
        Else
            gestErreur.SetError(txtNumDroite, "")
        End If
    End Sub
    ''' <summary>
    ''' Validation pour le numéro de téléphone
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtNumMilieu_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNumMilieu.Validating
        If (Char.IsLetter(txtNumMilieu.Text) OrElse String.IsNullOrWhiteSpace(txtNumMilieu.Text)) Then
            gestErreur.SetError(txtNumDroite, "Veuillez entrez un numéro valide")
        Else
            gestErreur.SetError(txtNumDroite, "")
        End If
    End Sub
    ''' <summary>
    ''' Validation pour le numéro de téléphone
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtNumDroite_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNumDroite.Validating
        If (Char.IsLetter(txtNumDroite.Text) OrElse String.IsNullOrWhiteSpace(txtNumDroite.Text)) Then
            gestErreur.SetError(txtNumDroite, "Veuillez entrez un numéro valide")
        Else
            gestErreur.SetError(txtNumDroite, "")
        End If
    End Sub
End Class