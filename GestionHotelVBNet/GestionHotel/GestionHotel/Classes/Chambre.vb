'******************************************************************************
'Programmeur : Mehdi Laribi
'Date de remise : 24/11/2014
'Ce même jour, je suis devenu Canadien. À 14h
'******************************************************************************
Public Class Chambre

#Region "Énumérations"
    ''' <summary>
    ''' Énumération contenant les 3 types de chambres
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum TypeChambre
        Normal = 0
        Supérieur = 1
        Suite = 2
    End Enum
#End Region

#Region "Données membres"

    ''' <summary>
    ''' Numéro de la chambre
    ''' </summary>
    ''' <remarks>unique</remarks>
    Private ReadOnly _numChambre As Integer
    ''' <summary>
    ''' Type de chambre 
    ''' </summary>
    ''' <remarks>type enum</remarks>
    Private _typeChambre As TypeChambre
    ''' <summary>
    ''' Détermine si la chambre possède une cuisine ou non
    ''' </summary>
    ''' <remarks></remarks>
    Private _aUneCuisine As Boolean
    ''' <summary>
    ''' Nombre de place
    ''' </summary>
    ''' <remarks></remarks>
    Private _nbPlaces As Byte
#End Region

#Region "Constructeur"
    ''' <summary>
    '''Constructeur qui initialise les données membre de la classe
    ''' </summary>
    ''' <param name="pNumChambre">Numéro de chambre</param>
    ''' <param name="pTypeChambre">Type de chambre</param>
    ''' <param name="pCuisine">Possède cuisine</param>
    ''' <param name="pNbPlaces">Nombre de place</param>
    ''' <remarks></remarks>
    Public Sub New(pNumChambre As Integer, pTypeChambre As TypeChambre, pCuisine As Boolean,
                   pNbPlaces As Byte)
        _numChambre = pNumChambre
        _typeChambre = pTypeChambre
        _aUneCuisine = pCuisine
        _nbPlaces = pNbPlaces

    End Sub
#End Region

#Region "Propriétés"
    ''' <summary>
    ''' Numéro de chambre
    ''' </summary>
    ''' <value></value>
    ''' <returns>Le numéro de chambre</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property NumeroChambre As Integer
        Get
            Return _numChambre
        End Get
    End Property
    ''' <summary>
    ''' Le type de chambre
    ''' </summary>
    ''' <value>Nouveau type de chambre</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TypeDeChambre As TypeChambre
        Get
            Return _typeChambre
        End Get
        Set(value As TypeChambre)
            If (String.IsNullOrWhiteSpace(value)) Then
                Throw New ArgumentNullException("Le type de chambre est invalide")
            End If
            _typeChambre = value
        End Set
    End Property
    ''' <summary>
    ''' Possède une cuisine
    ''' </summary>
    ''' <value>Nouvelle information sur a cuisine</value>
    ''' <returns>True si possède une cuisine, false dans le cas contraire</returns>
    ''' <remarks></remarks>
    Public Property PossedeCuisine As Boolean
        Get
            Return _aUneCuisine
        End Get
        Set(value As Boolean)
            If (String.IsNullOrWhiteSpace(value)) Then
                Throw New ArgumentNullException("")
            End If
            _aUneCuisine = value
        End Set
    End Property
    ''' <summary>
    ''' Nombre de places
    ''' </summary>
    ''' <value>Nouveau nombre de places</value>
    ''' <returns>Le nombre de places</returns>
    ''' <remarks></remarks>
    Public Property NombrePlaces As Byte
        Get
            Return _nbPlaces
        End Get
        Set(value As Byte)
            If (String.IsNullOrWhiteSpace(value)) Then
                Throw New ArgumentNullException("Le nombre de places est invalide")
            End If
            _nbPlaces = value
        End Set
    End Property
#End Region

#Region "Méthodes"
    ''' <summary>
    ''' Réécriture de la fonction ToString() de classe Chambre 
    ''' pour l'affichage graphique
    ''' </summary>
    ''' <returns>Le numéro de chambre</returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return NumeroChambre
    End Function
#End Region
End Class
