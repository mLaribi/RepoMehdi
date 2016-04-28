'******************************************************************************
'Programmeur : Mehdi Laribi
'Date de remise : 24/11/2014
'Ce même jour, je suis devenu Canadien. À 14h
'******************************************************************************
Public Class Client

#Region "Données membres"


    ''' <summary>
    ''' Id du client
    ''' </summary>
    ''' <remarks>Unique</remarks>
    Private ReadOnly _id As Integer
    ''' <summary>
    ''' Nom du client
    ''' </summary>
    ''' <remarks></remarks>
    Private _nom As String
    ''' <summary>
    ''' Numéro de téléphone du client
    ''' </summary>
    ''' <remarks></remarks>
    Private _telephone As String
    ''' <summary>
    ''' Note sur le client
    ''' </summary>
    ''' <remarks></remarks>
    Private _note As String
#End Region


#Region "Constructeurs"
    ''' <summary>
    '''Constructeur qui initialise les données membre de la classe
    ''' </summary>
    ''' <param name="pNom">Nom du client</param>
    ''' <param name="pTelephone">Numéro de téléphone</param>
    ''' <param name="pNote">Note sur le client</param>
    ''' <remarks></remarks>
    Public Sub New(pNom As String, pTelephone As String, pNote As String)
        Nom = pNom
        Telephone = pTelephone
        Note = pNote
    End Sub
    ''' <summary>
    ''' Constructeur qui initialise les données membre de la classe
    ''' </summary>
    ''' <param name="Pid"></param>
    ''' <param name="pNom"></param>
    ''' <param name="pTelephone"></param>
    ''' <param name="pNote"></param>
    ''' <remarks>Reçois un paramètre de plus, l'identifiant du client</remarks>
    Public Sub New(Pid As Integer, pNom As String, pTelephone As String, pNote As String)
        _id = Pid
        Nom = pNom
        Telephone = pTelephone
        Note = pNote
    End Sub
#End Region

#Region "Propriétés"
    ''' <summary>
    ''' Identifiant du client
    ''' </summary>
    ''' <value></value>
    ''' <returns>Un identifiant</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Id As Integer
        Get
            Return _id
        End Get
    End Property
    ''' <summary>
    ''' Nom du client
    ''' </summary>
    ''' <value>le nouveau nom du client</value>
    ''' <returns>Le nom du client</returns>
    ''' <remarks>Lance une exception si non valide</remarks>
    Public Property Nom As String
        Get
            Return _nom
        End Get
        Set(value As String)
            If (String.IsNullOrWhiteSpace(value)) Then
                Throw New ArgumentException("Le nom est obligatoire")
            End If
            _nom = value
        End Set
    End Property
    ''' <summary>
    ''' Numéro de téléphone du client
    ''' </summary>
    ''' <value>Le nouveau numéro de téléphone</value>
    ''' <returns>Le numéro de téléphone</returns>
    ''' <remarks>Lance une exception si non valide</remarks>
    Public Property Telephone As String
        Get
            Return _telephone
        End Get
        Set(value As String)
            If (String.IsNullOrWhiteSpace(value)) Then
                Throw New ArgumentException("Numéro de téléphone est obligatoire")
            End If
            _telephone = value
        End Set
    End Property
    ''' <summary>
    ''' Note sur le client
    ''' </summary>
    ''' <value>La nouvelle note</value>
    ''' <returns>La note sur le client</returns>
    ''' <remarks></remarks>
    Public Property Note As String
        Get
            Return _note
        End Get
        Set(value As String)
            _note = value
        End Set
    End Property
#End Region

#Region "Méthodes"
    ''' <summary>
    ''' Réécriture de la fonction ToString() de classe Chambre 
    ''' pour l'affichage graphique
    ''' </summary>
    ''' <returns>Le nom du client</returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return String.Format(_nom)
    End Function
    ''' <summary>
    ''' Méthode qui recherche si un mot de la recherche est contenu dans la BD
    ''' </summary>
    ''' <param name="tabMots">Les mots clés de la recherche</param>
    ''' <returns>Vrai si la banque de mots est trouvée, false dans le cas contraire</returns>
    ''' <remarks></remarks>
    Public Function Contient(tabMots As String()) As Boolean

        For Each element As String In tabMots
            element = element.ToLower()
            If (_nom.ToLower().Contains(element) OrElse _telephone.Contains(element) OrElse
                _note.ToLower().Contains(element)) Then
            Else
                Return False
            End If
        Next
        Return True
    End Function
#End Region
End Class
