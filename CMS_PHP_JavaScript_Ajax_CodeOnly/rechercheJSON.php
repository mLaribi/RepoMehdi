<?php
header("Content-type: application/json; charset=utf-8");
header("Expires: Thu, 19 Nov 1981 08:52:00 GMT");
header("Cache-Control: no-store, no-cache, must-revalidate, post-check=0, pre-check=0");
header("Pragma: no-cache");

$msgErreur = null;

if (! isset($_POST["recherche"]))
  $msgErreur = "Le paramètre de recherche n'a pas été fourni avec la requête.";
  else {

    $recherche = $_POST["recherche"];

    try {
      include('includes/connexion.php');
      //REQUETE
      $req = "SELECT * FROM usagers WHERE login LIKE :champRecherche OR nom LIKE :champRecherche ORDER BY idCategories, nom";
      $prepReq = $bdd -> prepare($req);
      $prepReq -> execute(array("champRecherche" => '%'.$recherche.'%'));
      $prepReq -> setFetchMode(PDO::FETCH_OBJ);
    } catch (PDOException $e) {
      exit("Erreur lors de l'exécution de la requête SQL" . $e -> getMessage());
    }

    //Si la requête ne contient aucun usagé
    if ($prepReq->rowCount() == 0)
      $msgErreur = "L'usager n'existe pas.";
    else {

        $lstUsagers = "[\n";
        //Écriture en format JSON
        while($info = $prepReq -> fetch())
        {
          $login = $info -> login;
          $categorie = $info -> idCategories;
          $prenom = $info -> prenom;
          $nom = $info -> nom;


          $lstUsagers .= "\t{\n";
          $lstUsagers .= "\t\t\"idCategories\": \"$categorie\",\n";
          $lstUsagers .= "\t\t\"prenom\": \"$prenom\",\n";
          $lstUsagers .= "\t\t\"nom\": \"$nom\",\n";
          $lstUsagers .= "\t\t\"login\": \"$login\"\n";
          $lstUsagers .= "\t},\n";
        }

        $lstUsagers .= "]";
        $posDernVirg = strrpos($lstUsagers, ",");
        $lstUsagers = substr_replace($lstUsagers,"",$posDernVirg,1);


        echo $lstUsagers;
    }
    $prepReq -> closeCursor();
    $bdd = null;
  }

  //Format JSON s'il y a une erreur
  if ( $msgErreur != null )
  {
  		echo "{\n";
  		echo "\t\"erreur\":\n";
  		echo "\t{\n";
  			echo "\t\t\"message\": \"" . str_replace("\"", "\\\"", $msgErreur) . "\"\n";
  		echo "\t}\n";
  		echo "}\n";
  }

  sleep(2);
 ?>
