'******************************************************************************
'Programmeur : Mehdi Laribi
'Date de remise : 24/11/2014
'Ce même jour, je suis devenu Canadien. À 14h
'******************************************************************************
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports GestionHotel
<TestClass()> Public Class testsListeTriee

    ''' <summary>
    ''' Test pour le nombre d'éléments dans la liste
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod1()
        Dim liste As New ListeTriee(Of Integer)

        liste.Ajouter(-5)
        Assert.AreEqual(1, liste.NbElements)
    End Sub
    ''' <summary>
    ''' Test du constructeur
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestConstructeur()
        Dim liste As New ListeTriee(Of Integer)()
        Assert.AreEqual(0, liste.NbElements)
    End Sub
    ''' <summary>
    ''' Test pour la méthode ajouter
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestAjouter()

        Dim liste As New ListeTriee(Of Integer)

        liste.Ajouter(-5)
        Assert.AreEqual(-5, liste(0))
        Assert.AreEqual(-5, liste.GetPlusPetit())

        Assert.AreEqual(1, liste.NbElements)

        liste.Ajouter(99)
        Assert.AreEqual(-5, liste.GetPlusPetit())

        Assert.AreEqual(2, liste.NbElements)

        liste.Ajouter(25)
        Assert.AreEqual(-5, liste.GetPlusPetit())
        Assert.AreEqual(3, liste.NbElements)

        liste.Vider()

        For i As Integer = 0 To 100
            liste.Ajouter(i)
            Assert.AreEqual(i + 1, liste.NbElements)

            For j As Integer = 0 To i
                Assert.AreEqual(j, liste(j))
            Next
        Next
    End Sub
    ''' <summary>
    ''' Test pour avoir le plus petit élément
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestPetitGetElem()
        Dim liste As New ListeTriee(Of Integer)

        For i As Integer = 0 To 100
            liste.Ajouter(i)
        Next
        Assert.AreEqual(0, liste(0))
    End Sub
    ''' <summary>
    ''' Test pour retirer plus petit, leve une exception
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> <ExpectedException(GetType(InvalidOperationException))> Public Sub TestRetirerPlusPetit()
        Dim liste As New ListeTriee(Of Integer)
        liste.Vider()
        liste.RetirerPlusPetit()
    End Sub
    ''' <summary>
    ''' Test exception pour get plus petit
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> <ExpectedException(GetType(InvalidOperationException))> Public Sub TestGetPlusPetit()
        Dim liste As New ListeTriee(Of Integer)
        liste.GetPlusPetit()
    End Sub
End Class