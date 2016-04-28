'******************************************************************************
'Programmeur : Mehdi Laribi
'Date de remise : 24/11/2014
'Ce même jour, je suis devenu Canadien. À 14h
'******************************************************************************
Imports System.Data.SqlClient
Public Class frmAffichageReser
    ''' <summary>
    ''' Enumération pour le mode d'affichage 
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ModeClientChambre
        ParChambre
        ParClient
    End Enum
#Region "Données membres"
    ''' <summary>
    ''' Chambre sélectionnée
    ''' </summary>
    ''' <remarks></remarks>
    Private _seleChambre As Chambre
    ''' <summary>
    ''' Client sélectionné
    ''' </summary>
    ''' <remarks></remarks>
    Private _seleClients As Client
    ''' <summary>
    ''' Liste à afficher par client
    ''' </summary>
    ''' <remarks></remarks>
    Private _lstReserParClient As New ListeTriee(Of Reservation)
    ''' <summary>
    ''' Liste à afficher par chambre
    ''' </summary>
    ''' <remarks></remarks>
    Private _lstReserParChambre As New ListeTriee(Of Reservation)
    ''' <summary>
    ''' Liste complète des clients
    ''' </summary>
    ''' <remarks></remarks>
    Private _lstClient As New List(Of Client)
    ''' <summary>
    ''' Liste complète des usagers
    ''' </summary>
    ''' <remarks></remarks>
    Private _lstUsager As New List(Of Usager)
    ''' <summary>
    ''' Liste complète des chambres
    ''' </summary>
    ''' <remarks></remarks>
    Private _lstChambre As New List(Of Chambre)
    ''' <summary>
    ''' Mode d'ouverture
    ''' </summary>
    ''' <remarks></remarks>
    Public _modeClCh As ModeClientChambre
#End Region
#Region "Propriétés"
    ''' <summary>
    ''' Mode formulaire
    ''' </summary>
    ''' <value>Nouveau mode</value>
    ''' <returns>Mode du formulaire</returns>
    ''' <remarks>chambre ou client selon le cas</remarks>
    Public Property ModeCliCham As ModeClientChambre
        Get
            Return Me._modeClCh
        End Get
        Set(value As ModeClientChambre)
            Me._modeClCh = value
        End Set
    End Property
#End Region
#Region "Constructeurs"
    ''' <summary>
    ''' Constructeur permettant d'initialiser les données membres, pour une chambre sélectionnée
    ''' </summary>
    ''' <param name="chambreSelect">Chambre sélectionnée</param>
    ''' <param name="lstChambres">liste de chambre</param>
    ''' <param name="lstUsager">liste d'usager</param>
    ''' <param name="lstClient">Liste de clients</param>
    ''' <remarks></remarks>
    Public Sub New(chambreSelect As Chambre, lstChambres As List(Of Chambre),
                   lstUsager As List(Of Usager), lstClient As List(Of Client))

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        _seleChambre = chambreSelect
        _lstUsager = lstUsager
        _lstClient = lstClient
        _lstChambre = lstChambres


    End Sub


    ''' <summary>
    ''' Constructeur permettant d'initialiser les données membres, pour un client sélectionné
    ''' </summary>
    ''' <param name="clientSelec">Client sélectionné</param>
    ''' <param name="lstClient"></param>
    ''' <param name="lstUsager"></param>
    ''' <param name="lstChambres"></param>
    ''' <remarks></remarks>
    Public Sub New(clientSelec As Client, lstClient As List(Of Client),
                   lstUsager As List(Of Usager), lstChambres As List(Of Chambre))
        InitializeComponent()

        _seleClients = clientSelec
        _lstUsager = lstUsager
        _lstClient = lstClient
        _lstChambre = lstChambres

    End Sub

#End Region



    ''' <summary>
    ''' Au lancement du formulaire
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmAffichageReser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.btnModifier.Enabled = False
        Me.btnSupprimer.Enabled = False
        Dim frmPrinc As New FrmPrincipal()
        If Me.ModeCliCham = ModeClientChambre.ParChambre Then
            ChargerReservationChambre()
            Me.lblTitre.Text = "Réservations de la chambre" & _seleChambre.ToString()
        Else
            ChargerReservationClient()
            Me.lblTitre.Text = "Réservations de " & _seleClients.ToString()

        End If
        Me.lblTitre.TextAlign = ContentAlignment.TopCenter
    End Sub

    ''' <summary>
    ''' Méthode qui charge les réservation d'un clients à partir de la base de données
    ''' Affiche aussi la liste dans le dataGridView
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChargerReservationClient()

        _lstReserParClient.Vider()

        Me.dgvAffichage.ReadOnly = True
        Me.dgvAffichage.MultiSelect = False
        Me.dgvAffichage.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvAffichage.RowHeadersVisible = False
        Me.dgvAffichage.AllowUserToAddRows = False
        Me.dgvAffichage.AllowUserToResizeRows = False
        Me.dgvAffichage.AllowUserToDeleteRows = False

        Try
            Using connexion As New SqlConnection(Bd.Source)
                connexion.Open()

                Dim commande As New SqlCommand(Bd.Reservation.SelectParClient, connexion)
                commande.Parameters.AddWithValue("@idClient", _seleClients.Id)
                Using reader As SqlDataReader = commande.ExecuteReader()

                    While reader.Read()
                        Dim numChambre As Integer = reader.GetInt32(0)
                        Dim dateDebut As DateTime = reader.GetDateTime(1)
                        Dim nbNuits As Integer = reader.GetInt32(2)
                        Dim idClient As Integer = reader.GetInt32(3)
                        Dim idUsager As Integer = reader.GetInt32(4)


                        Dim clientRes As Client = Nothing
                        Dim usagerRes As Usager = Nothing

                        For Each e As Client In _lstClient
                            If (e.Id = idClient) Then
                                clientRes = New Client(e.Nom, e.Telephone, e.Note)
                            End If
                        Next

                        For Each elemt As Usager In _lstUsager
                            If elemt.Id = idUsager Then
                                usagerRes = New Usager(elemt.Id, elemt.Nom, elemt.CodeAcces, elemt.EstActif,
                                                       elemt.EstGerant)
                            End If
                        Next

                        _lstReserParClient.Ajouter(New Reservation(numChambre, dateDebut, nbNuits, clientRes, usagerRes))
                    End While
                    If (_lstReserParClient.NbElements > 0) Then
                        Dim binding As BindingSource = New BindingSource
                        binding.DataSource = _lstReserParClient
                        dgvAffichage.DataSource = binding


                        dgvAffichage.Columns(0).HeaderText = "Numéro de la chambre"
                        dgvAffichage.Columns(1).HeaderText = "Date de début"
                        dgvAffichage.Columns(2).HeaderText = "Nombre de nuits"
                        dgvAffichage.Columns(3).Visible = False
                        dgvAffichage.Columns(4).HeaderText = "Usager ayant fait la réservation"
                        For Each col As DataGridViewColumn In dgvAffichage.Columns
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        Next
                    End If
                End Using

            End Using
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Méthode qui charge les réservation d'une chambre à partir de la base de données
    ''' Affiche aussi la liste dans le dataGridView   
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChargerReservationChambre()
        _lstReserParChambre.Vider()
        Me.dgvAffichage.ReadOnly = True
        Me.dgvAffichage.MultiSelect = False
        Me.dgvAffichage.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvAffichage.RowHeadersVisible = False
        Me.dgvAffichage.AllowUserToAddRows = False
        Me.dgvAffichage.AllowUserToResizeRows = False
        Me.dgvAffichage.AllowUserToDeleteRows = False

        Try
            Using connexion As New SqlConnection(Bd.Source)
                connexion.Open()
                Dim commande As New SqlCommand(Bd.Reservation.SelectParChambre, connexion)
                commande.Parameters.AddWithValue("@numChambre", _seleChambre.NumeroChambre)
                Using reader As SqlDataReader = commande.ExecuteReader()
                    While reader.Read()

                        Dim numChambre As Integer = reader.GetInt32(0)
                        Dim dateDebut As DateTime = reader.GetDateTime(1)
                        Dim nbNuits As Integer = reader.GetInt32(2)
                        Dim idClient As Integer = reader.GetInt32(3)
                        Dim idUsager As Integer = reader.GetInt32(4)


                        Dim clientRes As Client = Nothing
                        Dim usagerRes As Usager = Nothing

                        For Each e As Client In _lstClient
                            If (e.Id = idClient) Then
                                clientRes = New Client(e.Nom, e.Telephone, e.Note)
                            End If
                        Next

                        For Each elemt As Usager In _lstUsager
                            If elemt.Id = idUsager Then
                                usagerRes = New Usager(elemt.Id, elemt.Nom, elemt.CodeAcces, elemt.EstActif,
                                                       elemt.EstGerant)
                            End If
                        Next
                        _lstReserParChambre.Ajouter(New Reservation(numChambre, dateDebut, nbNuits, clientRes, usagerRes))
                    End While
                End Using
                If (_lstReserParChambre.NbElements > 0) Then
                    Dim bindingReser As BindingSource = New BindingSource()
                    bindingReser.DataSource = _lstReserParChambre
                    Me.dgvAffichage.DataSource = bindingReser

                    For Each col As DataGridViewColumn In dgvAffichage.Columns
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Next
                    dgvAffichage.Columns(0).HeaderText = "Numéro de la chambre"
                    dgvAffichage.Columns(1).HeaderText = "Date début"
                    dgvAffichage.Columns(2).HeaderText = "Nombre de nuits"
                    dgvAffichage.Columns(3).HeaderText = "Nom du Client"
                    dgvAffichage.Columns(4).HeaderText = "Usager ayant fait la réservation"

                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        End Try
    End Sub


    ''' <summary>
    ''' Bouton qui permet de modifier une réservation sélectionnée
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnModifier_Click(sender As Object, e As EventArgs) Handles btnModifier.Click
    End Sub

    ''' <summary>
    ''' Bouton qui permettra de supprimer une réservation sélectionnée
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSupprimer_Click(sender As Object, e As EventArgs) Handles btnSupprimer.Click
        Dim reserSelect As Reservation = dgvAffichage.CurrentRow.DataBoundItem
        Try
            Using connexion As New SqlConnection(Bd.Source)
                connexion.Open()
                Dim commande As New SqlCommand(Bd.Reservation.Supprimer, connexion)
                commande.Parameters.AddWithValue("@numChambre", reserSelect.NumChambre)
                commande.Parameters.AddWithValue("@debut", reserSelect.DateDebut)
                commande.ExecuteNonQuery()
                If (ModeCliCham = ModeClientChambre.ParChambre) Then
                    ChargerReservationChambre()
                Else
                    ChargerReservationClient()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Suppression impossible")
        End Try
    End Sub
    ''' <summary>
    ''' Evénement quand on clique sur un élément du DataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvAffichage_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAffichage.CellClick
        Me.btnSupprimer.Enabled = True
        Me.btnModifier.Enabled = True
    End Sub

End Class