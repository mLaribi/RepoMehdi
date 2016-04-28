'******************************************************************************
'Programmeur : Mehdi Laribi
'Date de remise : 24/11/2014
'Ce même jour, je suis devenu Canadien. À 14h
'******************************************************************************
Imports System.Collections
Public Class Reservation
    'Implémentation de la comparaison
    Implements IComparable(Of Reservation)

#Region "Données membres"
    ''' <summary>
    ''' Numéro de chambre
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly _numChambre As Integer
    ''' <summary>
    ''' Date de début de la réservation
    ''' </summary>
    ''' <remarks></remarks>
    Private _debut As DateTime
    ''' <summary>
    ''' Nombre de nuits
    ''' </summary>
    ''' <remarks></remarks>
    Private _nbNuits As Integer
    ''' <summary>
    ''' Le client ayant fait la réservation
    ''' </summary>
    ''' <remarks></remarks>
    Private _uclient As Client
    ''' <summary>
    ''' L'usager ayant fait la réservation
    ''' </summary>
    ''' <remarks></remarks>
    Private _usager As Usager
#End Region

#Region "Constructeurs"
    ''' <summary>
    ''' Constructeur qui initialise les données membre de la classe
    ''' </summary>
    ''' <param name="pNumChambre"></param>
    ''' <param name="pDate"></param>
    ''' <param name="pNbNuit"></param>
    ''' <param name="pIdClient"></param>
    ''' <param name="pIdUsager"></param>
    ''' <remarks></remarks>
    Public Sub New(pNumChambre As Integer, pDate As DateTime, pNbNuit As Integer,
                   pIdClient As Client, pIdUsager As Usager)
        _numChambre = pNumChambre
        DateDebut = pDate
        NombreNuits = pNbNuit
        _uclient = pIdClient
        _usager = pIdUsager

    End Sub
#End Region

#Region "Propriétés"
    ''' <summary>
    ''' Numéro de chambre
    ''' </summary>
    ''' <returns>le numéro de chambre</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property NumChambre As Integer
        Get
            Return _numChambre
        End Get
    End Property
    ''' <summary>
    ''' Date de début
    ''' </summary>
    ''' <value>Nouvelle date</value>
    ''' <returns>la date de réservation</returns>
    ''' <remarks></remarks>
    Public Property DateDebut As DateTime
        Get
            Return _debut
        End Get
        Set(value As DateTime)
            _debut = value
        End Set
    End Property
    ''' <summary>
    ''' Le nombre de nuits
    ''' </summary>
    ''' <value>Nouveau nombre</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NombreNuits As Integer
        Get
            Return _nbNuits
        End Get
        Set(value As Integer)
            _nbNuits = value
        End Set
    End Property
    ''' <summary>
    ''' Le client à qui appartient la réservation
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IdClient As Client
        Get
            Return _uclient
        End Get
    End Property
    ''' <summary>
    ''' L'usager qui a fait la réservation
    ''' </summary>
    ''' <value>Nouvel usager</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IdUsager As Usager
        Get
            Return _usager
        End Get
        Set(value As Usager)
            _usager = value
        End Set
    End Property
#End Region

#Region "Méthodes"
    ''' <summary>
    ''' CompareTo qui fera le tri par date des réservations
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns>1, 0 ou -1 qui représente le résultat</returns>
    ''' <remarks></remarks>
    Public Function CompareTo(other As Reservation) As Integer Implements IComparable(Of Reservation).CompareTo
        Return Me.DateDebut.CompareTo(other.DateDebut)
       

        'If (Me.DateDebut.Year < other.DateDebut.Year) Then
        '    comparaison = -1
        'ElseIf (Me.DateDebut.Year = other.DateDebut.Year) Then
        '    comparaison = 0
        'Else
        '    comparaison = 1
        'End If
    End Function
#End Region
End Class
