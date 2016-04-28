Public Class FrmRecherche
    Dim _listeClients As New List(Of Client)

    Public Sub New(lstClient As List(Of Client))
        InitializeComponent()
        _listeClients = lstClient
    End Sub
    Private Sub FrmRecherche_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub BtnRecherche_Click(sender As Object, e As EventArgs) Handles BtnRecherche.Click

        Dim tabMot As String() = txtMotsCles.Text.Split(" ")
        Dim listeClientTrouves As New List(Of Client)


        For i As Integer = 0 To tabMot.Length - 1
            tabMot(i) = tabMot(i).Trim()
            For Each c As Client In _listeClients

                If c.Contient(tabMot) Then
                    listeClientTrouves.Add(c)
                End If
            Next
        Next
        Dim bindRecherche As BindingSource = New BindingSource
        bindRecherche.ResetBindings(True)
        bindRecherche.DataSource = listeClientTrouves
        dgvRecherche.DataSource = bindRecherche

        Me.dgvRecherche.ReadOnly = True
        Me.dgvRecherche.MultiSelect = False
        Me.dgvRecherche.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecherche.RowHeadersVisible = False
        Me.dgvRecherche.AllowUserToAddRows = False
        Me.dgvRecherche.AllowUserToResizeRows = False
        Me.dgvRecherche.AllowUserToDeleteRows = False
        For Each col As DataGridViewColumn In dgvRecherche.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next

        Me.dgvRecherche.Columns(0).Visible = False


    End Sub

End Class