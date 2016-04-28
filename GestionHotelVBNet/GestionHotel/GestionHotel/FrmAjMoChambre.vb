'******************************************************************************
'Programmeur : Mehdi Laribi
'Date de remise : 24/11/2014
'Ce même jour, je suis devenu Canadien. À 14h
'******************************************************************************
Imports System.Data.SqlClient
Public Class frmAjMoChambre

#Region "Données membres"
    ''' <summary>
    ''' Mode qui sera utilisé (modification ou ajout)
    ''' </summary>
    ''' <remarks></remarks>
    Private _mode As FrmPrincipal.ModeAjoutModif
    ''' <summary>
    ''' Client
    ''' </summary>
    ''' <remarks></remarks>
    Private _chambre As Chambre
#End Region

#Region "Propriétés"
    ''' <summary>
    ''' Mode formulaire
    ''' </summary>
    ''' <value>Nouveau mode</value>
    ''' <returns>Mode du formulaire</returns>
    ''' <remarks>Modifier ou ajouter selon le cas</remarks>
    Public Property ModeChambre As FrmPrincipal.ModeAjoutModif
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
    Public Property Chambre As Chambre
        Get
            Return Me._chambre
        End Get
        Set(value As Chambre)
            Me._chambre = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    ''' <summary>
    ''' Constructeur par défaut, pour l'ajout
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
    End Sub
    ''' <summary>
    ''' Constructeur qui initialise les donnée membre, une chambre a modifier
    ''' </summary>
    ''' <param name="chambreModif"></param>
    ''' <remarks></remarks>
    Public Sub New(chambreModif As Chambre)
        InitializeComponent()
        Chambre = chambreModif
    End Sub
#End Region

    ''' <summary>
    ''' Au lancement du formulaire
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmAjMoChambre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each element In [Enum].GetValues(GetType(Chambre.TypeChambre))
            cboType.Items.Add(element)
        Next
        For i As Integer = 1 To 50
            cboNbPlaces.Items.Add(i)
        Next

        'Actions dépendamment du mode (ajout ou modification)
        If Me.ModeChambre = FrmPrincipal.ModeAjoutModif.Ajout Then
            Me.btnAjMo.Text = "Ajouter"
            Me.lblTitre.Text = "Ajout d'un chambre"
            Me.Text = "Ajout"
            Me.cboType.SelectedIndex = 0
            Me.cboNbPlaces.SelectedIndex = 0
            Me.rdbNon.Checked = True
        Else
            Me.txtNum.Enabled = False
            Me.btnAjMo.Text = "Modifier"
            Me.lblTitre.Text = "Modifier la chambre"
            Me.Text = "Modification"
            Me.txtNum.Text = Chambre.NumeroChambre
            Me.cboType.SelectedIndex = Me.Chambre.TypeDeChambre
            Me.cboNbPlaces.SelectedIndex = Chambre.NombrePlaces - 1
            If Chambre.PossedeCuisine Then
                rdbOui.Checked = True
            Else
                rdbNon.Checked = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' Bouton ajouter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Ajoute une chambre</remarks>
    Private Sub btnAjMo_Click(sender As Object, e As EventArgs) Handles btnAjMo.Click
        If (ModeChambre = FrmPrincipal.ModeAjoutModif.Ajout) Then
            Try
                Using connexion As New SqlConnection(Bd.Source)
                    connexion.Open()
                    Dim commande As New SqlCommand(Bd.Chambre.Inserer, connexion)
                    commande.Parameters.AddWithValue("@numero", Me.txtNum.Text)
                    commande.Parameters.AddWithValue("@type", Me.cboType.SelectedIndex)
                    Dim cuisine As Boolean
                    If rdbOui.Checked Then
                        cuisine = True
                    End If
                    commande.Parameters.AddWithValue("@aUneCuisine", cuisine)
                    commande.Parameters.AddWithValue("@nbPlaces", cboNbPlaces.SelectedIndex + 1)

                    commande.ExecuteScalar()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        Else
            Try
                Using connexion As New SqlConnection(Bd.Source)
                    connexion.Open()
                    Dim commande As New SqlCommand(Bd.Chambre.MAJ, connexion)
                    commande.Parameters.AddWithValue("@numero", Me.txtNum.Text)
                    commande.Parameters.AddWithValue("@type", Me.cboType.SelectedIndex)
                    Dim cuisine As Boolean
                    If rdbOui.Checked Then
                        cuisine = True
                    End If
                    commande.Parameters.AddWithValue("@aUneCuisine", cuisine)
                    commande.Parameters.AddWithValue("@nbPlaces", cboNbPlaces.SelectedIndex + 1)

                    commande.ExecuteNonQuery()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Bouton annuler ou quitter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Quitte la fenêtre sans rien faire</remarks>
    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Validation du numéro de chambre, si c'est un numéro ou c'est en lettres
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtNum_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNum.Validating
        If (Char.IsLetter(txtNum.Text)) Then
            gestErreur.SetError(txtNum, "Veuillez entrer des chiffre pour le numéro")
        Else
            gestErreur.SetError(txtNum, "")
        End If
    End Sub
End Class