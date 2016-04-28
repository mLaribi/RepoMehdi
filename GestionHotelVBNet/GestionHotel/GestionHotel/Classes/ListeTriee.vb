
''' <summary>
''' Représente une liste triée d'éléments implémentant IComparable, donc triés d'après leur CompareTo
''' </summary>
''' <typeparam name="T">Un type implémentant IComparable</typeparam>
Public Class ListeTriee(Of T As IComparable(Of T))
    Implements IListeTriee(Of T)

    Private _liste As List(Of T)
    Public Sub New()
        _liste = New List(Of T)
    End Sub
    ''' <summary>
    ''' Ajoute un élément dans la liste triée. L'élément sera placé d'après le CompareTo.
    ''' </summary>
    ''' <param name="valeur">Valeur à ajouter</param>
    ''' <exception cref="ArgumentNullException">Si valeur est Null</exception>
    Public Sub Ajouter(valeur As T) Implements IListeTriee(Of T).Ajouter
        If (valeur Is Nothing) Then
            Throw New ArgumentNullException("La valeur est invalide")
        End If
        Dim i As Integer = 0
        While (i < NbElements AndAlso _liste(i).CompareTo(valeur) < 0)
            i += 1
        End While

        If (i < NbElements) Then
            _liste.Insert(i, valeur)
        Else
            _liste.Add(valeur)
        End If
    End Sub
    ''' <summary>
    ''' Pour voir quel est l'élément le plus petit.
    ''' </summary>
    ''' <returns>L'élément le plus petit</returns>
    ''' <exception cref="InvalidOperationException">Si la liste est vide</exception>
    ''' <remarks>Cette méthode n'enlève pas l'élément de la liste.</remarks>
    Public Function GetPlusPetit() As T Implements IListeTriee(Of T).GetPlusPetit
        If (_liste.Count = Nothing) Then
            Throw New InvalidOperationException
        End If
        Return _liste(0)
    End Function
    ''' <summary>
    ''' Indique le nombre d'éléments dans la liste
    ''' </summary>
    ''' <remarks>La valeur retournée est plus grande ou égale à zéro</remarks>
    Public ReadOnly Property NbElements As Integer Implements IListeTriee(Of T).NbElements
        Get
            Return _liste.Count
        End Get
    End Property
    ''' <summary>
    ''' Pour récupérer l'élément le plus petit et le retirer de la liste.
    ''' </summary>
    ''' <returns>L'élément le plus petit</returns>
    ''' <exception cref="InvalidOperationException">Si la liste est vide</exception>
    Public Function RetirerPlusPetit() As T Implements IListeTriee(Of T).RetirerPlusPetit
        If (_liste.Count = 0) Then
            Throw New InvalidOperationException("Liste vide!")
        End If
        Dim premier As T = _liste(0)
        _liste.RemoveAt(0)
        Return premier
    End Function
    ''' <summary>
    ''' Efface tous les éléments de la liste.
    ''' </summary>
    ''' <remarks>La taille sera 0</remarks>
    Public Sub Vider() Implements IListeTriee(Of T).Vider
        _liste.Clear()
    End Sub

    ' Ces méthodes sont déjà faites pour vous
    Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
        Return _liste.GetEnumerator()
    End Function

    Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return _liste.GetEnumerator()
    End Function
End Class
