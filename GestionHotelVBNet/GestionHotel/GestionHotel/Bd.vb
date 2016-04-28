Imports System.Data.SqlClient
''' <summary>
''' Constantes reliées à la BD
''' </summary>
Public Class Bd

    ''' <summary>
    ''' Source à utiliser pour ouvrir la connexion à la BD
    ''' </summary>
    Public Shared ReadOnly Source As String = "Server=(localdb)\v11.0;Integrated Security=true;AttachDbFileName=" & Application.StartupPath & "\BdHotel.mdf;"

    ''' <summary>
    ''' Les requêtes pour la table Usager
    ''' </summary>
    Public Class Usager

        ''' <summary>
        ''' Avoir tous les usagers 
        ''' </summary>
        Public Const SelectTout = "SELECT * FROM Usager"

        ''' <summary>
        ''' Avoir un usager à partir de son Id 
        ''' </summary>
        Public Const SelectParId = "SELECT * FROM Usager WHERE Id=@id"

        ''' <summary>
        ''' Avoir un usager à partir de son code d’accès
        ''' </summary>
        Public Const SelectParCode = "SELECT * FROM Usager WHERE CodeAcces=@code"

        ''' <summary>
        ''' Ajouter un usager 
        ''' </summary>
        Public Const Inserer = "INSERT INTO Usager (Nom, CodeAcces, EstActif, EstGerant) output INSERTED.ID VALUES (@nom, @code, @estActif, @estGerant)"

        ''' <summary>
        ''' Mettre à jour un usager
        ''' </summary>
        Public Const MAJ = "UPDATE Usager SET Nom=@nom, CodeAcces=@code, EstActif=@estActif, EstGerant=@estGerant WHERE Id=@id"

        ''' <summary>
        ''' Modifier le statut actif/inactif d’un usager
        ''' </summary>
        Public Const MAJEstActif = "UPDATE Usager SET EstActif=@estActif WHERE Id=@id"
    End Class

    ''' <summary>
    ''' Requêtes pour la table Chambre
    ''' </summary>
    Public Class Chambre

        ''' <summary>
        ''' Avoir toutes les chambres 
        ''' </summary>
        Public Const SelectTout = "SELECT * FROM Chambre"

        ''' <summary>
        ''' Avoir une chambre à partir de son numéro
        ''' </summary>
        Public Const SelectParNum = "SELECT * FROM Chambre WHERE Numero=@numero"

        ''' <summary>
        ''' Ajouter une nouvelle chambre
        ''' </summary>
        Public Const Inserer = "INSERT INTO Chambre (Numero, Type, AUneCuisine, NbPlaces) VALUES (@numero, @type, @aUneCuisine, @nbPlaces)"

        ''' <summary>
        ''' Mettre à jour une chambre
        ''' </summary>
        Public Const MAJ = "UPDATE Chambre SET Type=@type, AUneCuisine=@aUneCuisine, NbPlaces=@nbPlaces WHERE Numero=@numero"
    End Class

    ''' <summary>
    ''' Requêtes pour la table Client
    ''' </summary>
    Public Class Client

        ''' <summary>
        ''' Avoir tous les clients
        ''' </summary>
        Public Const SelectTout = "SELECT * FROM Client"

        ''' <summary>
        ''' Avoir un client à partir de son numéro 
        ''' </summary>
        Public Const SelectParId = "SELECT * FROM Client WHERE Id=@id"

        ''' <summary>
        ''' Ajouter un nouveau client 
        ''' </summary>
        Public Const Inserer = "INSERT INTO Client (Nom, Telephone, Note) output INSERTED.ID VALUES (@nom, @telephone, @note)"

        ''' <summary>
        ''' Mettre à jour un client
        ''' </summary>
        Public Const MAJ = "UPDATE Client SET Nom=@nom, Telephone=@telephone, Note=@note WHERE Id=@id"
    End Class

    ''' <summary>
    ''' Requêtes pour la table Reservation
    ''' </summary>
    Public Class Reservation

        ''' <summary>
        ''' Avoir toutes les réservations 
        ''' </summary>
        Public Const SelectTout = "SELECT * FROM Reservation"

        ''' <summary>
        ''' Avoir toutes les réservations d’une chambre 
        ''' </summary>
        Public Const SelectParChambre = "SELECT * FROM Reservation Where NumChambre=@numChambre"

        ''' <summary>
        ''' Avoir toutes les réservations d’un client 
        ''' </summary>
        Public Const SelectParClient = "SELECT * FROM Reservation Where IdClient=@idClient"

        ''' <summary>
        ''' Ajouter une nouvelle réservation 
        ''' </summary>
        Public Const Inserer = "INSERT INTO Reservation (NumChambre, Debut, NbNuits, IdClient, IdUsager) VALUES (@numChambre, @debut, @nbNuits, @idClient, @idUsager)"

        ''' <summary>
        ''' Supprimer une réservation 
        ''' </summary>
        Public Const Supprimer = "DELETE FROM Reservation WHERE NumChambre=@numChambre AND Debut=@debut"
    End Class
End Class
