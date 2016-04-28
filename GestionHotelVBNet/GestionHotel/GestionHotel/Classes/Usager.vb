'******************************************************************************
'Programmeur : Mehdi Laribi
'Date de remise : 24/11/2014
'Ce même jour, je suis devenu Canadien. À 14h
'******************************************************************************
Public Class Usager

#Region "Données membres"
    ''' <summary>
    ''' Identifiant de l'usager
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly _id As Integer
    ''' <summary>
    ''' Nom de l'usager
    ''' </summary>
    ''' <remarks></remarks>
    Private _nom As String
    ''' <summary>
    ''' Code d'accès 
    ''' </summary>
    ''' <remarks></remarks>
    Private _codeAcces As String
    ''' <summary>
    ''' Est actif ou non
    ''' </summary>
    ''' <remarks></remarks>
    Private _estActif As Boolean
    ''' <summary>
    ''' Est gérant ou non
    ''' </summary>
    ''' <remarks></remarks>
    Private _estGerant As Boolean
#End Region

#Region "Constructeur"
    ''' <summary>
    ''' Constructeur qui initialise les données membre de la classe
    ''' </summary>
    ''' <param name="pId"></param>
    ''' <param name="pNom"></param>
    ''' <param name="pCodeAcces"></param>
    ''' <param name="pActif"></param>
    ''' <param name="pGerant"></param>
    ''' <remarks></remarks>
    Public Sub New(pId As Integer, pNom As String, pCodeAcces As String, pActif As Boolean, pGerant As Boolean)
        _id = pId
        Nom = pNom
        CodeAcces = pCodeAcces
        EstActif = pActif
        EstGerant = pGerant
    End Sub
#End Region

#Region "Propriétés"
    ''' <summary>
    ''' Identifiant de l'usager ( est unique)
    ''' </summary>
    ''' <value></value>
    ''' <returns>Un id unique</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Id As Integer
        Get
            Return _id
        End Get
    End Property
    ''' <summary>
    ''' Nom de l'usager
    ''' </summary>
    ''' <value>Nouveau nom</value>
    ''' <returns>le nom de l'usager</returns>
    ''' <remarks>Retourne une exception si invalide</remarks>
    Public Property Nom As String
        Get
            Return _nom
        End Get
        Set(value As String)
            If (String.IsNullOrWhiteSpace(value)) Then
                Throw New ArgumentNullException("Le nom est invalide")
            End If
            _nom = value
        End Set
    End Property
    ''' <summary>
    ''' Code d'accès au compte
    ''' </summary>
    ''' <value>Le nouveau code</value>
    ''' <returns>le code d'accès</returns>
    ''' <remarks>Retourne une exception si invalide</remarks>
    Public Property CodeAcces As String
        Get
            Return _codeAcces
        End Get
        Set(value As String)
            If (String.IsNullOrWhiteSpace(value)) Then
                Throw New ArgumentNullException("Le code d'accès est invalide")
            End If
            _codeAcces = value
        End Set
    End Property
    ''' <summary>
    ''' Le compte est actif
    ''' </summary>
    ''' <value>Nouvel état</value>
    ''' <returns>Vrai si actif, faux dans le cas contraire</returns>
    ''' <remarks></remarks>
    Public Property EstActif As Boolean
        Get
            Return _estActif
        End Get
        Set(value As Boolean)
            _estActif = value
        End Set
    End Property
    ''' <summary>
    ''' Est gérant
    ''' </summary>
    ''' <value>nouvel état</value>
    ''' <returns>Vrai si gérant, faux dans le cas contraire</returns>
    ''' <remarks></remarks>
    Public Property EstGerant As Boolean
        Get
            Return _estGerant
        End Get
        Set(value As Boolean)
            _estGerant = value
        End Set
    End Property
#End Region

#Region "Méthodes"
    ''' <summary>
    ''' Réécriture de la fonction ToString() de classe Chambre 
    ''' pour l'affichage graphique
    ''' </summary>
    ''' <returns>Le nom</returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return String.Format(_nom)
    End Function
#End Region
End Class
