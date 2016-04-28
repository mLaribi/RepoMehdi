
''' <summary>
''' 
''' Cette interface représente les opérations que doivent avoir une liste triée.
''' 
''' Une liste triée conserve ses éléments triés d'après le CompareTo. Elle 
''' possède une méthode pour ajouter et une autre pour savoir quel les le plus 
''' petit.
''' </summary>
''' <typeparam name="T">Une type implémentant IComparable, permettant de trier des éléments</typeparam>
Public Interface IListeTriee(Of T As IComparable(Of T))
    Inherits IEnumerable(Of T)

    ''' <summary>
    ''' Ajoute un élément dans la liste triée. L'élément sera placé d'après le CompareTo.
    ''' </summary>
    ''' <param name="valeur">Valeur à ajouter</param>
    ''' <exception cref="ArgumentNullException">Si valeur est Null</exception>
    Sub Ajouter(valeur As T)

    ''' <summary>
    ''' Pour voir quel est l'élément le plus petit.
    ''' </summary>
    ''' <returns>L'élément le plus petit</returns>
    ''' <exception cref="InvalidOperationException">Si la liste est vide</exception>
    ''' <remarks>Cette méthode n'enlève pas l'élément de la liste.</remarks>
    Function GetPlusPetit() As T

    ''' <summary>
    ''' Pour récupérer l'élément le plus petit et le retirer de la liste.
    ''' </summary>
    ''' <returns>L'élément le plus petit</returns>
    ''' <exception cref="InvalidOperationException">Si la liste est vide</exception>
    Function RetirerPlusPetit() As T

    ''' <summary>
    ''' Indique le nombre d'éléments dans la liste
    ''' </summary>
    ''' <remarks>La valeur retournée est plus grande ou égale à zéro</remarks>
    ReadOnly Property NbElements As Integer

    ''' <summary>
    ''' Efface tous les éléments de la liste.
    ''' </summary>
    ''' <remarks>La taille sera 0</remarks>
    Sub Vider()
End Interface
