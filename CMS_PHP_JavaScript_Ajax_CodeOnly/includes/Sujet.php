<?php 
//*********************************************************
// Description : 
//  Ce fichier contient la déclarations de la classe Sujet
//
//*********************************************************

class Sujet {

	private $_id;
	private $_nom_menu;
	private $_position;
	private $_visible;

//Constructeur
    public function __construct($pId, $pNom, $pPos, $pVisible){
        $this->setId($pId);
        $this->setNomMenu($pNom);
        $this->setPosition($pPos);
        $this->setVisible($pVisible);
    }
    
    //Acesseur en écriture:
    public function setId($valeur){
    
        $this->_id = $valeur;
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
    
    
    //Accesseur en lecture
    
    public function getId(){
        
    return $this->_id;
    }
    
    public function getNomMenu(){

    return $this->_nom_menu;
    }
    
     public function getPosition(){
        
    return $this->_position;
    }
    
     public function getVisible(){
        
    return $this->_visible;
    }
    
    
    
}
?>