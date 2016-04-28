<?php
	require("param_bd.inc");
	
	try{
      	$bdd = new PDO("mysql:host=$dbHote; dbname=$dbNom",
      	$dbUtilisateur,
      	$dbMotPasse,
      	array(PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES utf8'));
		
		
    }
    catch (PDOException $e){
      	exit("Erreur lors de la connexion à la BD ".$e->getMessage());
    }
?>