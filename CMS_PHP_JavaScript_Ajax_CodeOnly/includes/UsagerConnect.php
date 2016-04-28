<?php
session_start();
require("connexion.php");
require("UsagerManager.php");


if(isset ($_POST["Connexion"]))
{
    $nomUsager = "";
    $pswUsager = "";

    if (isset ( $_POST ['nomUsager'] ))
    {
        $nomUsager = $_POST ['nomUsager'];
    }

    if (isset ( $_POST ['motPasse'] ))
	{
        $pswUsager = sha1($_POST['motPasse']);
    }
}

$managerUsager = new UsagerManager($bdd);

$usagerConnecte = $managerUsager->UsagerId($nomUsager, $pswUsager);

    if ($_POST ["seSouvenir"] == true)
    {
		$valeurCookie = uniqid ( mt_rand (), true );
		$timestamp_expire = time () + (2592000); // Le cookie expirera dans 1 mois
		setcookie ( 'sessionAuto', $valeurCookie, $timestamp_expire );
    }

if($usagerConnecte){
    $_SESSION['logUsager'] = $usagerConnecte->getLogin();
    $_SESSION['mdpUsager'] = $usagerConnecte->getPass();
    $_SESSION['accUsager'] = $usagerConnecte->getAcces();

    header("Location: ../index.php");
    exit;

}
    else{
    header("Location: ../loginform.php?code=1");
    exit;
    }
?>
