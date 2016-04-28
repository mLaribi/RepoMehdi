<?php
//*********************************************************
// Description :
//  Ce fichier contient la d�clarations de la classe usagerManager
//
//*********************************************************

require_once "Usager.php";

class UsagerManager {

    private $_db;

	public function __construct($db)
	{
		$this->setDb($db);
	}


    //Accesseur en �criture
    public function setDb(PDO $db)
  {
    $this->_db = $db;
  }

    //Accesseur en lecture
  private function getDb()
  {
    return $this->_db;
  }


    //Ajouter un usager
    public function ajouter($usager) {
    try
    {
        $req = $this->getDb()->prepare('INSERT INTO usagers(login, enc_password, idCategories, nom, prenom) VALUES(:login, :password, :idCategories, :nom, :prenom)');
        $req->bindValue(':login', $usager->getLogin());
        $req->bindValue(':password', sha1($usager->getPass()));
        $req->bindValue(':idCategories', $usager->getAcces());
        $req->bindValue(':nom', $usager->getNom());
        $req->bindValue(':prenom', $usager->getPrenom());
        $req->execute();
        $req->closeCursor();
    }
        catch (PDOException $e){
    	exit( "Erreur lors de l'ex�cution de la requ�te SQL :<br />\n" .  $e -> getMessage() . "<br />\nREQU�TE = INSERT");
        }
    }




    //Supprimer un usager
    public function Supprimer($id) {

        $req = $this->getDb()->prepare('DELETE FROM usagers WHERE id = :id');

        $req->execute(array('id' => $id));
        $req->closeCursor();

    }


    //Modifier un usager
    public function Modifier($usager){

    $req = $this->getDb()->prepare('UPDATE usagers SET enc_password = :password, idCategories = :idCategories, nom= :nom, prenom= :prenom WHERE id = :id');
    $req->bindValue(':password', $usager->getPass());
    $req->bindValue(':idCategories', $usager->getAcces());
    $req->bindValue(':id', $usager->getId());
    $req->bindValue(':nom', $usager->getNom());
    $req->bindValue(':prenom', $usager->getPrenom());
    $req->execute();
    $req->closeCursor();
    }


    //Liste des usagers

    public function UsagerId($login, $psw){

        try{
            $req = $this->getDb()->prepare('SELECT id, login, enc_password, idCategories, nom, prenom FROM usagers WHERE login = :login AND enc_password = :psw');
            $req->execute(array(':login'=>$login,
                                ':psw'=>$psw));
            $usBd = $req->fetch(PDO::FETCH_ASSOC);
            $usagerRetour = new Usager($usBd['id'],$usBd['login'], $usBd['enc_password'], $usBd['idCategories'], $usBd['nom'], $usBd['prenom']);
            $req->closeCursor();
            return $usagerRetour;
        }
        catch(Exception $e)
        {
           echo "Erreur BD:". $e->getMessage();
					 return null;
        }

    }

    public function sortirUnUsager($id){

        try{
            $req = $this->getDb()->prepare('SELECT id, login, enc_password, idCategories, nom, prenom FROM usagers WHERE id = :id');
            $req->execute(array(':id'=>$id));
            $usBd = $req->fetch(PDO::FETCH_ASSOC);
            $usagerRetour = new Usager($usBd['id'],$usBd['login'], $usBd['enc_password'], $usBd['idCategories'], $usBd['nom'], $usBd['prenom']);
            $req->closeCursor();
        }
        catch(Exception $e)
        {
           echo "Erreur BD:". $e->getMessage();
        }
        return $usagerRetour;
    }

    public function listerUsager(){
        $lstUsager = array();
        $req = $this->getDb()->query('SELECT id, login, enc_password, idCategories, nom, prenom FROM usagers');
        while($donnees = $req->fetch(PDO::FETCH_ASSOC))
        {
            $lstUsager[] = new Usager($donnees['id'], $donnees['login'], $donnees['enc_password'], $donnees['idCategories'], $donnees['nom'], $donnees['prenom']);
        }

        $req->closeCursor();

        return $lstUsager;
    }

}


?>
