'******************************************************************************
'Programmeur : Mehdi Laribi
'Date de remise : 24/11/2014
'Ce même jour, je suis devenu Canadien. À 14h
'******************************************************************************

Imports System.Data.SqlClient

Public Class FrmPrincipal
#Region "Énumérations"
    ''' <summary>
    ''' Enumération pour le mode d'ouverture du formulaire
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ModeAjoutModif
        Modification
        Ajout
    End Enum


#End Region
#Region "Données membres"
    ''' <summary>
    ''' Mode du formulaire
    ''' </summary>
    ''' <remarks></remarks>
    Public _modeAJMOD As ModeAjoutModif
    Private _usagerConnecte As Usager
    Private _lstClients As New List(Of Client)
    Private _lstChambres As New List(Of Chambre)
    Private _lstUsagers As New List(Of Usager)


#End Region

#Region "Propriétés"
    ''' <summary>
    ''' Mode formulaire
    ''' </summary>
    ''' <value>Nouveau mode</value>
    ''' <returns>Mode du formulaire</returns>
    ''' <remarks>Modifier ou ajouter selon le cas</remarks>
    Public Property ModeAM As ModeAjoutModif
        Get
            Return Me._modeAJMOD
        End Get
        Set(value As ModeAjoutModif)
            Me._modeAJMOD = value
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
    ''' Constructeur qui initialise les données
    ''' </summary>
    ''' <param name="pUsager"></param>
    ''' <remarks></remarks>
    Public Sub New(pUsager As Usager)
        InitializeComponent()
        _usagerConnecte = pUsager

    End Sub
    ''' <summary>
    ''' Au démarrage de la fenêtre
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        Me.txtRecherche.Focus()
        btnAjoutRes.Enabled = False
        btnAffResClient.Enabled = False
        btnAffResChambre.Enabled = False

        Me.Show()
        lblNomUtilisateur.Text += _usagerConnecte.Nom
        If (_usagerConnecte.EstGerant = False) Then
            tabPrincipal.TabPages.RemoveAt(1)
            tabPrincipal.TabPages.RemoveAt(1)

        Else
            ChargerUsagers()
            ChargerChambres()
        End If
        ChargerClients()
    End Sub
    ''' <summary>
    ''' Évènement qui ferme toute les fenêtres à la fermeture du principal
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    ''' <summary>
    ''' Bouton fermeture de l'application
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FermerApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FermerApplicationToolStripMenuItem.Click
        Application.Exit()
    End Sub
    ''' <summary>
    ''' Bouton fermeture de la session
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FermerSessionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FermerSessionToolStripMenuItem.Click
        Me.Hide()
        Dim frmConnex As FrmConnexion = New FrmConnexion
        frmConnex.ShowDialog()
    End Sub
    ''' <summary>
    ''' Bouton de recherche 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRecherche_Click(sender As Object, e As EventArgs) Handles btnRecherche.Click
        ChargerClients()

        Dim tabMot As String() = txtRecherche.Text.Split(" ")
        Dim listeClientTrouves As New List(Of Client)

        For Each c As Client In _lstClients
            If (c.Contient(tabMot)) Then
                listeClientTrouves.Add(c)
            End If

        Next
        dgvClients.Rows.Clear()
        Dim bindRecherche As BindingSource = New BindingSource
        bindRecherche.ResetBindings(True)
        bindRecherche.DataSource = listeClientTrouves
        dgvClients.DataSource = bindRecherche


    End Sub
#Region "Charger les clients"
    ''' <summary>
    ''' Permet de charger les clients à partir de la base de données
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChargerClients()
        _lstClients.Clear()

        Me.dgvClients.ReadOnly = True
        Me.dgvClients.MultiSelect = False
        Me.dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvClients.RowHeadersVisible = False
        Me.dgvClients.AllowUserToAddRows = False
        Me.dgvClients.AllowUserToResizeRows = False
        Me.dgvClients.AllowUserToDeleteRows = False

        Try
            Using connexion As New SqlConnection(Bd.Source)
                connexion.Open()
                Dim commandeClients As New SqlCommand(Bd.Client.SelectTout, connexion)
                Using readerClient As SqlDataReader = commandeClients.ExecuteReader()
                    While (readerClient.Read())
                        Dim id As UInteger = readerClient.GetInt32(0)
                        Dim nom As String = readerClient.GetString(1)
                        Dim telephone As String = readerClient.GetString(2)
                        Dim note As String = readerClient.GetString(3)
                        Dim nouvClient As Client = New Client(id, nom, telephone, note)
                        _lstClients.Add(nouvClient)
                    End While
                End Using

                Dim bindSourceClient As BindingSource = New BindingSource()
                bindSourceClient.DataSource = _lstClients
                Me.dgvClients.DataSource = bindSourceClient

                dgvClients.Columns(0).Visible = False

                For Each col As DataGridViewColumn In dgvClients.Columns
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Next

            End Using
        Catch ex As Exception
            MessageBox.Show("Chargement des clients impossible", "Erreur chargement", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Charger les chambres"
    ''' <summary>
    ''' Permet de charger les chambres à partir de la base de données
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ChargerChambres()
        _lstChambres.Clear()
        Try
            Me.dgvChambres.ReadOnly = True
            Me.dgvChambres.MultiSelect = False
            Me.dgvChambres.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.dgvChambres.RowHeadersVisible = False
            Me.dgvChambres.AllowUserToAddRows = False
            Me.dgvChambres.AllowUserToResizeRows = False
            Me.dgvChambres.AllowUserToDeleteRows = False

            Using connexion As New SqlConnection(Bd.Source)
                connexion.Open()
                Dim commandeChambre As New SqlCommand(Bd.Chambre.SelectTout, connexion)

                Using reader As SqlDataReader = commandeChambre.ExecuteReader()

                    While reader.Read()
                        Dim numChambre As Integer = reader.GetInt32(0)
                        Dim typeChambre As Integer = reader.GetInt32(1)
                        Dim cuisine As Boolean = reader.GetBoolean(2)
                        Dim nbPlaces As Integer = reader.GetInt32(3)
                        Dim nouvChambre As Chambre = New Chambre(numChambre, typeChambre, cuisine, nbPlaces)
                        _lstChambres.Add(nouvChambre)
                        '_dictChambre.Add(numChambre, nouvChambre)
                    End While
                End Using

                Dim bindingSourceChambre As BindingSource = New BindingSource()
                bindingSourceChambre.DataSource = _lstChambres
                Me.dgvChambres.DataSource = bindingSourceChambre


                dgvChambres.Columns(0).HeaderText = "numéro de chambre"
                dgvChambres.Columns(1).HeaderText = "Type de chambre"
                dgvChambres.Columns(2).HeaderText = "Possède une cuisine"
                dgvChambres.Columns(3).HeaderText = "nombre de places "

                For Each col As DataGridViewColumn In dgvChambres.Columns
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("Chargement des chambres impossible!", "Erreur chargement", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Charger les usagers"
    ''' <summary>
    ''' Permet de charger les usagers à partir de la base de données
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ChargerUsagers()
        _lstUsagers.Clear()

        Me.dgvUsagers.ReadOnly = True
        Me.dgvUsagers.MultiSelect = False
        Me.dgvUsagers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsagers.RowHeadersVisible = False
        Me.dgvUsagers.AllowUserToAddRows = False
        Me.dgvUsagers.AllowUserToResizeRows = False
        Me.dgvUsagers.AllowUserToDeleteRows = False
        Try
            Using connexion As New SqlConnection(Bd.Source)
                connexion.Open()
                Dim commandeUsagers As New SqlCommand(Bd.Usager.SelectTout, connexion)
                Using reader As SqlDataReader = commandeUsagers.ExecuteReader()
                    While reader.Read()
                        Dim id As Integer = reader.GetInt32(0)
                        Dim nom As String = reader.GetString(1)
                        Dim codeAcces As String = reader.GetString(2)
                        Dim estActif As Boolean = reader.GetBoolean(3)
                        Dim estGerant As Boolean = reader.GetBoolean(4)
                        Dim usager As Usager = New Usager(id, nom, codeAcces, estActif, estGerant)
                        _lstUsagers.Add(usager)
                    End While
                End Using

                Dim bindingUsager As BindingSource = New BindingSource()
                bindingUsager.DataSource = _lstUsagers
                Me.dgvUsagers.DataSource = bindingUsager

                dgvUsagers.Columns(0).Visible = False
                dgvUsagers.Columns(1).HeaderText = "Nom employé"
                dgvUsagers.Columns(2).HeaderText = "Code d'accès"
                dgvUsagers.Columns(3).HeaderText = "Est actif?"
                dgvUsagers.Columns(4).HeaderText = "Est gérant?"




                For Each col As DataGridViewColumn In dgvUsagers.Columns
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("Chargement des usagers impossible!", "Erreur chargement", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
#End Region

    ''' <summary>
    ''' Bouton ajout d'un client
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAjouterClient_Click(sender As Object, e As EventArgs) Handles btnAjouterClient.Click
        Dim frmAjoutClient As FrmAjMoClient = New FrmAjMoClient()
        frmAjoutClient.ModeClient = ModeAjoutModif.Ajout
        Dim action As DialogResult = frmAjoutClient.ShowDialog()

        Select Case (action)
            Case DialogResult.OK
                Dim nouvClient As Client = frmAjoutClient.Client()
                Me._lstClients.Add(nouvClient)
                ChargerClients()
            Case DialogResult.Cancel
                'Rien a faire
        End Select

        frmAjoutClient.Dispose()
    End Sub
    ''' <summary>
    ''' Bouton qui rafraichi la liste des clients
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReinistialis_Click(sender As Object, e As EventArgs) Handles btnReinitialiserLst.Click
        ChargerClients()
        txtRecherche.Text = ""
    End Sub
    ''' <summary>
    ''' Bouton modification d'un client
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnModifierClient_Click(sender As Object, e As EventArgs) Handles btnModifierClient.Click

        If (dgvClients.CurrentCell Is Nothing) Then
            MessageBox.Show("Veuillez sélectionner un client pour modifier sa fiche.", "Attention",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            Dim clientSel As Client = dgvClients.CurrentRow.DataBoundItem
            Dim frmModifClient As FrmAjMoClient = New FrmAjMoClient(clientSel)
            frmModifClient.ShowDialog()
            frmModifClient.ModeClient = ModeAjoutModif.Modification
            ChargerClients()

        End If
    End Sub

    ''' <summary>
    ''' Bouton ajout d'une chambre
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAjoutChambre_Click(sender As Object, e As EventArgs) Handles btnAjoutChambre.Click
        Dim frmAjChambre As New frmAjMoChambre()
        frmAjChambre.ModeChambre = ModeAjoutModif.Ajout
        Dim action As DialogResult = frmAjChambre.ShowDialog()

        Select Case (action)
            Case Windows.Forms.DialogResult.OK
                Dim nouvChambre As Chambre = frmAjChambre.Chambre
                _lstChambres.Add(nouvChambre)
                ChargerChambres()
            Case Windows.Forms.DialogResult.Cancel
                'Rien a faire
        End Select
        frmAjChambre.Dispose()
    End Sub
    ''' <summary>
    ''' Bouton modification d'une chambre
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnModifChambre_Click(sender As Object, e As EventArgs) Handles btnModifChambre.Click

        If (dgvChambres.CurrentCell Is Nothing) Then
            MessageBox.Show("Veuillez sélectionner une chambre pour modifier sa fiche.", "Attention",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim chambreSel As Chambre = dgvChambres.CurrentRow.DataBoundItem
            Dim frmModifChambre As New frmAjMoChambre(chambreSel)
            frmModifChambre.ShowDialog()
            frmModifChambre.ModeChambre = ModeAjoutModif.Modification
            ChargerChambres()
        End If
    End Sub
    ''' <summary>
    ''' Bouton ajout d'un usager
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAjoutUsager_Click(sender As Object, e As EventArgs) Handles btnAjoutUsager.Click
        Dim frmAjoutUsager As New FrmAjMoUsager()
        frmAjoutUsager.ModeUsager = ModeAjoutModif.Ajout
        Dim action As DialogResult = frmAjoutUsager.ShowDialog()

        Select Case (action)
            Case Windows.Forms.DialogResult.OK
                Dim nouvUsager As Usager = frmAjoutUsager.Usager
                _lstUsagers.Add(nouvUsager)
                ChargerUsagers()
            Case Windows.Forms.DialogResult.Cancel
                'Rien a faire
        End Select
        frmAjoutUsager.Dispose()
    End Sub
    ''' <summary>
    ''' Bouton modification d'un usager
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnModifierUsager_Click(sender As Object, e As EventArgs) Handles btnModifierUsager.Click
        If (dgvUsagers.CurrentCell Is Nothing) Then
            MessageBox.Show("Veuillez sélectionner un usager pour le modifier.", "Attention",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim usagerSelec As Usager = dgvUsagers.CurrentRow.DataBoundItem
            Dim frmModifUsager As New FrmAjMoUsager(usagerSelec)
            Dim action As DialogResult = frmModifUsager.ShowDialog()
            frmModifUsager.ModeUsager = ModeAjoutModif.Modification
            ChargerUsagers()
        End If
    End Sub
    ''' <summary>
    ''' Bouton affichage des réservations d'un client
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAffResClient_Click(sender As Object, e As EventArgs) Handles btnAffResClient.Click
        Dim clientSel As Client = dgvClients.CurrentRow.DataBoundItem
        Dim frmAfficResClient As frmAffichageReser = New frmAffichageReser(clientSel, _lstClients, _lstUsagers, _lstChambres)
        frmAfficResClient.ModeCliCham = frmAffichageReser.ModeClientChambre.ParClient

        frmAfficResClient.ShowDialog()
    End Sub
    ''' <summary>
    ''' Bouton ajout d'une réservation
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAjoutRes_Click(sender As Object, e As EventArgs) Handles btnAjoutRes.Click
        Dim clientSel As Client = dgvClients.CurrentRow.DataBoundItem
        Dim frmAjoutReservation As FrmAjReservation = New FrmAjReservation(clientSel, _lstChambres, _usagerConnecte,
                                                                           _lstClients, _lstUsagers)
        Dim action As DialogResult = frmAjoutReservation.ShowDialog()
    End Sub
    ''' <summary>
    ''' Bouton d'affichage des réservation d'une chambre
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAffResChambre_Click(sender As Object, e As EventArgs) Handles btnAffResChambre.Click
        Dim chambreSelect As Chambre = dgvChambres.CurrentRow.DataBoundItem
        Dim frmAffichageReservationChambre As frmAffichageReser = New frmAffichageReser(chambreSelect, _lstChambres, _lstUsagers, _lstClients)
        frmAffichageReservationChambre.ModeCliCham = frmAffichageReser.ModeClientChambre.ParChambre
        frmAffichageReservationChambre.ShowDialog()
    End Sub
    ''' <summary>
    ''' Évènement qui se produit au click dans une cellule du dataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Rend possible le click du bouton affichage des clients
    ''' par chambre</remarks>
    Private Sub dgvClients_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClients.CellClick
        If (dgvClients.CurrentRow.Index >= 0) Then
            btnAffResClient.Enabled = True
            btnAjoutRes.Enabled = True
        End If
    End Sub
    ''' <summary>
    ''' Évènement qui se produit au click dans une cellule du dataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Rend possible le click du bouton affichage des reservation
    ''' par chambre</remarks>
    Private Sub dgvChambres_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvChambres.CellClick
        If (dgvChambres.CurrentRow.Index >= 0) Then
            btnAffResChambre.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Active ou désactive un usager selon le cas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnActDesUsa_Click(sender As Object, e As EventArgs) Handles btnActDesUsa.Click
        Dim usagerSel As Usager = dgvUsagers.CurrentRow.DataBoundItem
        Dim actif As Boolean
        If (usagerSel.EstActif) Then
            actif = False
        Else
            actif = True
        End If

        Try

            Using connexion As New SqlConnection(Bd.Source)
                connexion.Open()
                Dim commande As New SqlCommand(Bd.Usager.MAJ, connexion)
                commande.Parameters.AddWithValue("@nom", usagerSel.Nom)
                commande.Parameters.AddWithValue("@code", usagerSel.CodeAcces)

                commande.Parameters.AddWithValue("@estActif", actif)
                commande.Parameters.AddWithValue("@estGerant", usagerSel.EstGerant)
                commande.Parameters.AddWithValue("@id", usagerSel.Id)
                commande.ExecuteNonQuery()
                ChargerUsagers()
            End Using
        Catch ex As Exception
            MessageBox.Show("Modification impossible!", "Attention!", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

    End Sub
    ''' <summary>
    ''' Validation du bouton de recherche, si le textbox est vide
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRecherche_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles btnRecherche.Validating
        If (String.IsNullOrWhiteSpace(txtRecherche.Text)) Then
            GestErreur.SetError(txtRecherche, "Veuillez remplir le champ de recherche")
        Else
            GestErreur.SetError(txtRecherche, "")
        End If
    End Sub

    Private Sub dgvClients_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClients.CellContentClick

    End Sub
End Class
