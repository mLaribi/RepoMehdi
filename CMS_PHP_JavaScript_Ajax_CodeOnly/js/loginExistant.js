//Au lancement
window.addEventListener('load', init, false);


//Variables globales

// Objet XMLHttpRequest
var xhr;

//Flag de l'existance de l'usager
var usagerExistant = false;


//Au lancement de la page
function init()
{
    //A chaque saisie d'un seul caractere
    document.getElementById('nomCompte').addEventListener('keyup', UsagerExistant, false);

}

//Tentative de recherche du login donné en AJAX
function UsagerExistant()
{
//3 caracteres minimum
if(document.getElementById('nomCompte').value.length > 2)
{
    // Création de l'objet XMLHttpRequest.
    xhr = new XMLHttpRequest();

    //Exécution apres le changement du status de la requête
    xhr.addEventListener('readystatechange', UsagerExistantCallBack, false);

    var url = "validationJSON.php";
    var contenuPost = 'nomCompte=' + encodeURIComponent(document.getElementById('nomCompte').value.trim());
    // Contenu de la requête avec la méthode POST.
    xhr.open('POST', url, true);
//Type de contenu de la requête
    xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
//Envoi de la requête au serveur
    xhr.send(contenuPost);


}
//FIN FUNCTION
}


//Demande et affichage du résultat (existant ou non)
function UsagerExistantCallBack() {

    //Si requete completee
  if (xhr.readyState == 4) {
      //Plus de 3 caracteres
    if (document.getElementById('nomCompte').value.length > 2)
    {
        //Mise à defaut du champ du resultat recherche
        document.getElementById('loginExi').textContent = "";

      var erreur = false;

        // La requête AJAX est-elle complétée avec echec
      if (xhr.status != 200) {
        var msgErreur = 'Erreur (code=' + xhr.status + '): La requête HTTP à plantée';
        document.getElementById('loginExi').textContent = msgErreur;
        erreur = true;
      }

        //Succès
      else {

          // Création de l'objet JavaScript à partir de l'expression JSON.
        try {
        var unUsager = JSON.parse(xhr.responseText);
        } catch (e) {
          alert ('ERREUR: La réponse AJAX n\'est pas une expression JSON valide.');
          erreur = true;
        }
          var msgErreur;
        if (!erreur) {

            //Login disponible pour utilisation
          if (unUsager.erreur) {
            msgErreur = 'Le login est disponible pour utilisation';
            document.getElementById('loginExi').textContent = msgErreur;
            document.getElementById("btnAjout").disabled = false;
          }

            //Non disponible
          else {
             msgErreur = 'Le login suivant est déja pris. Choisissez un autre login';
             document.getElementById('loginExi').textContent = msgErreur;
             document.getElementById("btnAjout").disabled = true;
            }
          }
        }
      }
    }
  }
