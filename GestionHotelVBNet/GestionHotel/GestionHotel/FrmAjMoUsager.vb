'******************************************************************************
'Programmeur : Mehdi Laribi
'Date de remise : 24/11/2014
'Ce même jour, je suis devenu Canadien. À 14h
'******************************************************************************
Imports System.Data.SqlClient
Public Class FrmAjMoUsager
    ''' <summary>
    ''' Mode qui sera utilisé (modification ou ajout)
    ''' </summary>
    ''' <remarks></remarks>
    Private _mode As FrmPrincipal.ModeAjoutModif
    ''' <summary>
    ''' Usager
    ''' </summary>
    ''' <remarks></remarks>
    Private _usager As Usager
#Region "Propriétés"
    ''' <summary>
    ''' Mode formulaire
    ''' </summary>
    ''' <value>Nouveau mode</value>
    ''' <returns>Mode du formulaire</returns>
    ''' <remarks>Modifier ou ajouter selon le cas</remarks>
    Public Property ModeUsager As FrmPrincipal.ModeAjoutModif
        Get
            Return Me._mode
        End Get
        Set(value As FrmPrincipal.ModeAjoutModif)
            Me._mode = value
        End Set
    End Property
    ''' <summary>
    ''' Propriété usager
    ''' </summary>
    ''' <value>Nouvel usager</value>
    ''' <returns>usager</returns>
    ''' <remarks></remarks>
    Public Property Usager As Usager
        Get
            Return _usager
        End Get
        Set(value As Usager)
            Me._usager = value
        End Set
    End Property
#End Region
    ''' <summary>
    ''' Constructeur par défaut 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub
    ''' <summary>
    ''' Constructeur qui initialise l'usager a modifier
    ''' </summary>
    ''' <param name="usagerModif"></param>
    ''' <remarks></remarks>
    Public Sub New(usagerModif As Usager)

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        _usager = usagerModif
    End Sub
    ''' <summary>
    ''' Au démarrage du formulaire
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmAjMoUsager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Me.ModeUsager = FrmPrincipal.ModeAjoutModif.Ajout) Then
            Me.btnAjMoUsager.Text = "Ajouter"
            Me.lblTitre.Text = "Ajout d'un usager"
            Me.Text = "Ajout"
        Else
            Me.btnAjMoUsager.Text = "Modifier"
            Me.lblTitre.Text = "Modifier l'usager"
            Me.Text = "Modification"
            Me.txtNom.Text = Me._usager.Nom
            Me.txtCode.Text = Me._usager.CodeAcces
            If (Me._usager.EstActif) Then
                Me.chkActif.Checked = True
            End If
            If (Me._usager.EstGerant) Then
                Me.chkGerant.Checked = True
            End If
        End If
    End Sub
    ''' <summary>
    ''' Bouton  ajouter modifier usager
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAjMoUsager_Click(sender As Object, e As EventArgs) Handles btnAjMoUsager.Click
        If (ModeUsager = FrmPrincipal.ModeAjoutModif.Ajout) Then
            Try
                Using connexion As New SqlConnection(Bd.Source)
                    connexion.Open()
                    Dim commande As New SqlCommand(Bd.Usager.Inserer, connexion)
                    commande.Parameters.AddWithValue("@nom", Me.txtNom.Text)
                    commande.Parameters.AddWithValue("@code", Me.txtCode.Text)
                    Dim actif As Boolean
                    If (Me.chkActif.Checked) Then
                        actif = True
                    End If
                    commande.Parameters.AddWithValue("@estActif", actif)
                    Dim gerant As Boolean
                    If (Me.chkGerant.Checked) Then
                        gerant = True
                    End If
                    commande.Parameters.AddWithValue("@estGerant", gerant)
                    commande.ExecuteNonQuery()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End Using
            Catch ex As Exception
                MessageBox.Show("Ajout impossible!", "Attention!", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        Else
            Try
                Using connexion As New SqlConnection(Bd.Source)
                    connexion.Open()
                    Dim commande As New SqlCommand(Bd.Usager.MAJ, connexion)
                    commande.Parameters.AddWithValue("@nom", Me.txtNom.Text)
                    commande.Parameters.AddWithValue("@code", Me.txtCode.Text)
                    Dim actif As Boolean
                    If (Me.chkActif.Checked) Then
                        actif = True
                    End If
                    commande.Parameters.AddWithValue("@estActif", actif)
                    Dim gerant As Boolean
                    If (Me.chkGerant.Checked) Then
                        gerant = True
                    End If
                    commande.Parameters.AddWithValue("@estGerant", gerant)
                    commande.Parameters.AddWithValue("@id", Me._usager.Id)
                    commande.ExecuteNonQuery()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End Using
            Catch ex As Exception
                MessageBox.Show("Modification impossible!", "Attention!", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub txtNom_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNom.Validating
        If (String.IsNullOrWhiteSpace(txtNom.Text)) Then
            gestErreur.SetError(txtNom, "Veuillez entrez un nom pour continuer")
        Else
            gestErreur.SetError(txtNom, "")
        End If
    End Sub
End Class