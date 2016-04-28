<?php
// Retourne du contenu en format JSON.
header("Content-type: application/json; charset=utf-8");

//Force l'expiration immédiate de la page
header("Expires: Thu, 19 Nov 1981 08:52:00 GMT");
header("Cache-Control: no-store, no-cache, must-revalidate, post-check=0, pre-check=0");
header("Pragma: no-cache");

//Message d'erreur
$msgErreur = null;

//Si le nom de compte a ete fourni
if (!isset($_POST["nomCompte"]))
  $msgErreur = "Entrez votre login pour voir son status de disponibilité";
  else {

    $loginExist = $_POST["nomCompte"];

    try {
        // Paramètres de connexion à la BD.
        // Création d'une connexion à la BD.
      include('includes/connexion.php');
        
        // Préparation et exécution de la requête SQL permettant de trouver l'usage avec un login donné
      $req = "SELECT login FROM usagers WHERE login LIKE :champLogin";
      $prepReq = $bdd -> prepare($req);
      $prepReq -> execute(array("champLogin" => '%'.$loginExist.'%'));
        //Retourne la ligne trouvée
      $prepReq -> setFetchMode(PDO::FETCH_OBJ);
    } catch (PDOException $e) {
      exit("Erreur lors de l'exécution de la requête SQL" . $e -> getMessage());
    }
//Si n'est pas trouvé
    if ($prepReq->rowCount() == 0)
      $msgErreur = "L'usager n'existe pas.";
    else {

        $lstUsagers = "[\n";
        while($info = $prepReq -> fetch())
        {
          

            // Récupération des informations sur l'usagers.
            $login = $info -> login;
            // Production de l'expression JSON à retourner.
          $lstUsagers .= "\t{\n";
          $lstUsagers .= "\t\t\"login\": \"$login\"\n";
          $lstUsagers .= "\t},\n";
        }

        $lstUsagers .= "]";
        $posDernVirg = strrpos($lstUsagers, ",");
        $lstUsagers = substr_replace($lstUsagers,"",$posDernVirg,1);


        echo $lstUsagers;
    }
      // Libération du jeu de résultats.
    $prepReq -> closeCursor();
      // Fermeture de la connexion à la BD.
    $bdd = null;
  }

// S'il y erreur, on retourne un message d'erreur en format JSON.
  if ( $msgErreur != null )
  {
  		echo "{\n";
  		echo "\t\"erreur\":\n";
  		echo "\t{\n";
  			echo "\t\t\"message\": \"" . str_replace("\"", "\\\"", $msgErreur) . "\"\n";
  		echo "\t}\n";
  		echo "}\n";
  }
// Simulation d'un délai avant de fournir la réponse
  sleep(2);
 ?>
