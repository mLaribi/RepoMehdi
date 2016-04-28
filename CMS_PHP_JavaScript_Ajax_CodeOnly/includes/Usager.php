<?php 
//*********************************************************
// Description : 
//  Ce fichier contient la déclarations de la classe usager
//
//*********************************************************


class Usager {
	
	private $_id;
	private $_login;
	private $_password;
	private $_idCategorie;
    private $_nom;
    private $_prenom;
	
	public function __construct($pId, $pLogin, $pPassword, $pIdCategorie, $pNom, $pPrenom)
	{
        $this->setId($pId);
		$this->setLogin($pLogin);
		$this->setPass($pPassword);
		$this->setAcces($pIdCategorie);
        $this->setNom($pNom);
        $this->setPrenom($pPrenom);
	}
	
    
    //Accesseur en ecriture
	
	public function setId($valeur) {
        
		if (empty($valeur)) {
			//throw new Exception('Identifiant vide !',E_USER_ERROR);
		}
		$this->_id = $valeur;
	}
    
    
    public function setLogin($valeur) {
    	if (empty($valeur)) {
    		//throw new Exception('Le login est vide!', E_USER_ERROR);
    	}
    	
        $this->_login = $valeur;
    }
    
    public function setPass($valeur) {
    	if (empty($valeur)) {
    		//throw new Exception('Le mot de passe est vide!',E_USER_ERROR);
    	}
        $this->_password = $valeur;
    }
    
    public function setAcces($valeur) {
    
        $this->_idCategorie = $valeur;
    }
    
    public function setNom($valeur){
        $this->_nom = $valeur;
    }
     
    public function setPrenom($valeur){
    
        $this->_prenom = $valeur;
    }
    
    //Accesseur en lecture
    
    public function getId(){
    return $this->_id;
    }
    
    public function getLogin(){
        return $this->_login;
    }
    
    public function getPass(){
    	return $this->_password;
    }
    
    public function getAcces(){
        return $this->_idCategorie;
    }
    
    public function getNom(){
        return $this->_nom;
    }
    
    public function getPrenom(){
        return $this->_prenom;
    }
    
}


?>