<?php 
//*********************************************************
// Description : 
//  Ce fichier contient la déclarations de la classe ContenuManager
//
//*********************************************************

require_once("Page.php");
require_once("Sujet.php");

class ContenuManager {

    private $_db;
   
    //Constructeur 
    
    public function __construct($db) {
        $this->setDb($db);
    }
    
    
    //Accesseur en écriture
     public function setDb(PDO $db)
  {
    $this->_db = $db;
  }
      //Accesseur en lecture
  private function getDb()
  {
    return $this->_db;
  }
   
//*********************************************************
//Section Page manager
//*********************************************************    
    //Ajout dans la bd
    public function AjoutPage($page){
        
    $req = $this->getDb()->prepare('INSERT INTO pages (sujet_id, nom_menu, position, visible, contenu, secure) VALUES (:sujet_id, :nom_menu, :position, :visible, :contenu, :secure)');
 
    $req->bindValue(':sujet_id', $page->getSujet());
    $req->bindValue(':nom_menu', $page->getNomMenu());
    $req->bindValue(':position', $page->getPosition());
    $req->bindValue(':visible', $page->getVisible());
    $req->bindValue(':contenu', $page->getContenu());    
    $req->bindValue(':secure', $page->getSecure());
 
    $req->execute();
	
	$req->closeCursor();
        
    }
    
    //Supprimer page de la bd
    
    public function SupprimerPageBD($id){
    
    $req = $this->getDb()->prepare('DELETE FROM pages WHERE id = :id');
	
	$req->execute(array(':id' => $id));
	
	$req->closeCursor();
    }
    
    
    //Modifier page de la bd
    
    public function ModifierPageBD($page){
    
    $req = $this->getDb()->prepare('UPDATE pages SET sujet_id = :sujet_id, nom_menu = :nom_menu, position = :position, visible=:visible, contenu=:contenu, secure=:secure WHERE id = :id');
 
    $req->bindValue(':sujet_id', $page->getSujet());
    $req->bindValue(':nom_menu', $page->getNomMenu());
    $req->bindValue(':position', $page->getPosition());
    $req->bindValue(':visible', $page->getVisible());
    $req->bindValue(':contenu', $page->getContenu());    
    $req->bindValue(':secure', $page->getSecure());
    $req->bindValue(':id', $page->getIdPage());
 
 
    $req->execute();
	
	$req->closeCursor();
    }
    
    
    public function ListePages($id) {
     try{
		$lstPages = array(); 
        $req = $this->getDb()->prepare('SELECT id, sujet_id, nom_menu, position, visible, contenu, secure FROM pages WHERE sujet_id = :id ORDER BY position');
		$req->execute(array('id'=>$id));
        while ($donnees = $req->fetch(PDO::FETCH_ASSOC)){
        $lstPages[] = new Page($donnees['id'], $donnees['sujet_id'], $donnees['nom_menu'], $donnees['position'], $donnees['visible'], $donnees['contenu'], $donnees['secure']);
        }
        $req->closeCursor();
	 }
	catch(Exception $e){
		 echo 'Exception reçue : ',  $e->getMessage();
	 }
	return $lstPages;
    }

    public function sortirUnePage($id) {
            $req = $this->getDb()->prepare('SELECT id, sujet_id, nom_menu, position, visible, contenu, secure FROM pages WHERE id = :id');
            $req->execute(array('id'=>$id));
            $donnees = $req->fetch(PDO::FETCH_ASSOC);
            $sujet = new Page($donnees['id'], $donnees['sujet_id'], $donnees['nom_menu'], $donnees['position'], $donnees['visible'], $donnees['contenu'], $donnees['secure']);
            $req->closeCursor();

            return $sujet;
    }

  public function ListerToutesLesPages() {
     try{
          $lstPages = array(); 
                $req = $this->getDb()->prepare('SELECT id, sujet_id, nom_menu, position, visible, contenu, secure FROM pages');
          $req->execute();
                while ($donnees = $req->fetch(PDO::FETCH_ASSOC)){
                $lstPages[] = new Page($donnees['id'], $donnees['sujet_id'], $donnees['nom_menu'], $donnees['position'], $donnees['visible'], $donnees['contenu'], $donnees['secure']);
                }
                $req->closeCursor();
  }
 catch(Exception $e){
   echo 'Exception reçue : ',  $e->getMessage();
  }
 return $lstPages;
    }
    
//*********************************************************
//Section Sujet manager    
//*********************************************************
    
    public function AjoutSujet($sujet){
    $req = $this->getDb()->prepare('INSERT INTO sujets(nom_menu, position, visible) VALUES (:nom_menuSujet, :positionSujet, :visibleSujet)');
    
    $req->bindValue(':nom_menuSujet', $sujet->getNomMenu());
    $req->bindValue(':positionSujet', $sujet->getPosition());
    $req->bindValue(':visibleSujet', $sujet->getVisible());
        
    $req->execute();
        
    $req->closeCursor();
    }
    
    public function SupprimerSujet($id) {
        
        $q = $this->getDb()->prepare('DELETE FROM sujets WHERE id = :id');
	
	$q->execute(array('id' => $id));
	
	$q->closeCursor();
    
    }
    
    
    public function ModifierSujet($sujetModif) {
        $req = $this->getDb()->prepare('UPDATE sujets SET nom_menu = :nom_menuSujet, position = :positionSujet, visible = :visibleSujet WHERE id = :id');
    
    $req->bindValue(':nom_menuSujet', $sujetModif->getNomMenu());
    $req->bindValue(':positionSujet', $sujetModif->getPosition());
    $req->bindValue(':visibleSujet', $sujetModif->getVisible());
    $req->bindValue(':id', $sujetModif->getId(), PDO::PARAM_INT);
        
    $req->execute();
        
    $req->closeCursor();
	}
        
    public function listerSujets(){
        
    $lstSujets = array();
 
    $req = $this->getDb()->query('SELECT id, nom_menu, position, visible FROM sujets ORDER BY position');
 
    while ($donnees = $req->fetch(PDO::FETCH_ASSOC))
    {
      $lstSujets[] = new Sujet($donnees['id'] ,$donnees['nom_menu'], $donnees['position'], $donnees['visible']);
    }
	
	$req->closeCursor();
 
    return $lstSujets;
    }

    public function sortirUnSujet($id) {

    $req = $this->getDb()->prepare('SELECT id, nom_menu, position, visible FROM sujets WHERE id = :id');
    $req->bindValue(':id', $id);
    $req->execute();
    $donnees = $req->fetch(PDO::FETCH_ASSOC);
    $sujet = new Sujet($donnees['id'], $donnees['nom_menu'], $donnees['position'], $donnees['visible']);
    $req->closeCursor();

    return $sujet;

    }
  }
?>