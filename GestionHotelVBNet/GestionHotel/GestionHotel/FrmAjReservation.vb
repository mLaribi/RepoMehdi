'******************************************************************************
'Programmeur : Mehdi Laribi
'Date de remise : 24/11/2014
'Ce même jour, je suis devenu Canadien. À 14h
'******************************************************************************
Imports System.Data.SqlClient

Public Class FrmAjReservation
    ''' <summary>
    ''' Données membres
    ''' </summary>
    ''' <remarks></remarks>
    Private _clientSelec As Client

    ''' <summary>
    ''' Liste des chambres
    ''' </summary>
    ''' <remarks></remarks>
    Private _lstchambres As New List(Of Chambre)
    ''' <summary>
    ''' Liste de suggestion des chambres après le filtrage
    ''' </summary>
    ''' <remarks></remarks>
    Private _lstSugg As New List(Of Chambre)
    ''' <summary>
    ''' Usager connecté
    ''' </summary>
    ''' <remarks></remarks>
    Private _usagerCourant As Usager
    ''' <summary>
    ''' Liste des clients
    ''' </summary>
    ''' <remarks></remarks>
    Private _lstClient As List(Of Client)
    ''' <summary>
    ''' Liste des usagers
    ''' </summary>
    ''' <remarks></remarks>
    Private _lstUsagers As List(Of Usager)


    ''' <summary>
    ''' Constructeur qui initialise le client sélectionné
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(pClientSele As Client, pLstChambre As List(Of Chambre), pUsager As Usager,
                   pListeClient As List(Of Client), pLstUsagers As List(Of Usager))

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        _clientSelec = pClientSele
        _lstchambres = pLstChambre
        _usagerCourant = pUsager
        _lstClient = pListeClient
        _lstUsagers = pLstUsagers
    End Sub
    ''' <summary>
    ''' Au lancement du formulaire
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmAjReservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        For i As Integer = 1 To 365
            cboNbNuits.Items.Add(i)
        Next


    End Sub
    ''' <summary>
    ''' Bouton ajout d'une réservation
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAjouter_Click(sender As Object, e As EventArgs) Handles btnAjouter.Click

        Try
            Dim chambreChoisi As Chambre = dgvSuggeChambre.CurrentRow.DataBoundItem
            Using connexion As New SqlConnection(Bd.Source)
                connexion.Open()
                Dim commande As New SqlCommand(Bd.Reservation.Inserer, connexion)
                commande.Parameters.AddWithValue("@numChambre", chambreChoisi.NumeroChambre)
                commande.Parameters.AddWithValue("@debut", dtpDate.Value)
                commande.Parameters.AddWithValue("@nbNuits", cboNbNuits.SelectedIndex)
                Dim idUsager As Integer
                Dim idClient As Integer
                For Each c As Client In _lstClient
                    If (c.Nom = _clientSelec.Nom) Then
                        idClient = c.Id
                    End If
                Next
                For Each us As Usager In _lstUsagers
                    If (us.Nom = _usagerCourant.Nom) Then
                        idUsager = us.Id
                    End If
                Next
                commande.Parameters.AddWithValue("@idClient", idClient)
                commande.Parameters.AddWithValue("idUsager", idUsager)
                commande.ExecuteNonQuery()

                Me.DialogResult = Windows.Forms.DialogResult.OK
            End Using
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' Méthode qui filtre les chambres données en suggestion
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FiltrageListeChambre()
        Try
        _lstSugg.Clear()

        Me.dgvSuggeChambre.ReadOnly = True
        Me.dgvSuggeChambre.MultiSelect = False
        Me.dgvSuggeChambre.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvSuggeChambre.RowHeadersVisible = False
        Me.dgvSuggeChambre.AllowUserToAddRows = False
        Me.dgvSuggeChambre.AllowUserToResizeRows = False
        Me.dgvSuggeChambre.AllowUserToDeleteRows = False

        Dim dateRech As Date = dtpDate.Value
        Dim nbNuits As Integer = cboNbNuits.SelectedIndex
        Dim nbPlaces As Integer = numNbPlaces.Value
        Dim cuisine As Boolean = chkCuisine.Checked
        For Each e As Chambre In _lstchambres
            If (e.NombrePlaces >= nbPlaces AndAlso e.PossedeCuisine = cuisine) Then
                _lstSugg.Add(e)
            End If
        Next
        If (_lstSugg.Count > 0) Then
            Dim binding As BindingSource = New BindingSource
            binding.DataSource = _lstSugg
            dgvSuggeChambre.DataSource = binding


            For Each col As DataGridViewColumn In dgvSuggeChambre.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Next
            End If
                  Catch ex As Exception
            MessageBox.Show("Impossible de trouver une chambre à vos exigences", "Erreur", MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub numNbPlaces_ValueChanged(sender As Object, e As EventArgs) Handles numNbPlaces.ValueChanged
        FiltrageListeChambre()
    End Sub
    ''' <summary>
    ''' Pour l'affichage de suggestion des chambres
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkCuisine_CheckedChanged(sender As Object, e As EventArgs) Handles chkCuisine.CheckedChanged
        FiltrageListeChambre()
    End Sub
End Class