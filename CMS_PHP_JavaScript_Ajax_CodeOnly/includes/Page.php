<?php 
//*********************************************************
// Description : 
//  Ce fichier contient la déclarations de la classe page
//
//*********************************************************

class Page {

	private $_id;
	private $_sujet_id;
	private $_nom_menu;
	private $_position;
	private $_visible;
	private $_contenu;
	private $_secure;

    //Constructeur 
    
    public function __construct($pId, $pSujet, $pNom_menu, $pPos, $pVisible, $pContenu, $pSecure) {
        
        $this->setIdPage($pId);
        $this->setSujet($pSujet);
        $this->setNomMenu($pNom_menu);
        $this->setPosition($pPos);
        $this->setVisible($pVisible);
        $this->setContenu($pContenu);
        $this->setSecure($pSecure);
    }
    
    //Accesseurs en lecture
   
    public function setIdPage($valeur){
        $this->_id = $valeur;
    }

    public function setSujet($valeur){
        $this->_sujet_id = $valeur;
    }
    
    public function setNomMenu($valeur){
    	$this->_nom_menu = $valeur;
    }
  	
    public function setPosition($valeur){
        $this->_position = $valeur;
    }

    public function setVisible($valeur){
        $this->_visible = $valeur;
    }

    public function setContenu($valeur){
        $this->_contenu = $valeur;
    }

    public function setSecure($valeur){
        $this->_secure = $valeur;
    }

    //Accesseur en lecture
    public function getIdPage(){
        return $this->_id;
    }
    
    public function getSujet(){
        return $this->_sujet_id;
    }

    public function getNomMenu(){
    	return $this->_nom_menu;
    }

    public function getPosition(){
        return $this->_position;
    }
    
    public function getContenu(){
        return $this->_contenu;
    }
    
    public function getVisible(){
        return $this->_visible;
    }
    
    public function getSecure(){
        return $this->_secure;
    }
}
?>