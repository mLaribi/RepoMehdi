'******************************************************************************
'Programmeur : Mehdi Laribi
'Date de remise : 24/11/2014
'Ce même jour, je suis devenu Canadien. À 14h
'******************************************************************************
Imports System.Data.SqlClient
Public Class FrmConnexion
    ''' <summary>
    ''' Démarrage du fomulaire
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmConnexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        txtCode.Focus()
        txtCode.Text = "666"
    End Sub

    ''' <summary>
    ''' Bouton quitter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub
    ''' <summary>
    ''' Bouton connexion
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnConnexion_Click(sender As Object, e As EventArgs) Handles btnConnexion.Click
        Dim codeAcces As String = txtCode.Text
        Dim usaConnecte As Usager
        GestionnaireErreur.SetError(txtCode, "")
        Try
            Using connexion As New SqlConnection(Bd.Source)
                Dim commande As New SqlCommand(Bd.Usager.SelectParCode, connexion)

                commande.Parameters.AddWithValue("@code", codeAcces)

                connexion.Open()
                Using reader As SqlDataReader = commande.ExecuteReader()
                    If (reader.Read()) Then
                        Dim id As UInteger = reader.GetInt32(0)
                        Dim nom As String = reader.GetString(1)
                        Dim acces As String = reader.GetString(2)
                        Dim estActif As Boolean = reader.GetBoolean(3)
                        Dim estGerant As Boolean = reader.GetBoolean(4)

                        If (estActif = False) Then
                            GestionnaireErreur.SetError(txtCode, "L'usager est inactif")
                        Else
                            usaConnecte = New Usager(id, nom, codeAcces, estActif, estGerant)
                            Dim frmPrincip As FrmPrincipal = New FrmPrincipal(usaConnecte)
                            frmPrincip.Show()
                            Me.Hide()
                        End If
                    Else
                        GestionnaireErreur.SetError(txtCode, "Code d'accès erroné")
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Connexion impossible")
        End Try

    End Sub
End Class