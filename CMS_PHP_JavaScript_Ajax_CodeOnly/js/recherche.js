var xhr;

var unUsager;

window.addEventListener('DOMContentLoaded', init, false);

function init() {
  document.getElementById('recherche').addEventListener('keyup', afficherInfoUsager, false);
  document.getElementById('recherche').addEventListener('click', afficherListeUsager, false);
  document.getElementById('lstUsager').className = "afficher";
}

function afficherListeUsager() {
  document.getElementById('lstUsager').className = "afficher";
  document.getElementById('resultatClickRecherche').className = "afficher";
}

function afficherInfoUsager() {
  if (document.getElementById('recherche').value.length > 2)
  {

    xhr = new XMLHttpRequest();

    xhr.addEventListener('readystatechange', afficherInfoUsagerCallback, false);

    var URL = 'rechercheJSON.php';
    var contenuPost = 'recherche=' + encodeURIComponent(document.getElementById('recherche').value.trim());

    xhr.open('POST', URL, true);

    xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');

    xhr.send(contenuPost);

  }
}

function afficherInfoUsagerCallback() {
  if (xhr.readyState == 4) {
    //si le nombres de caractère est de 3 et plus
    if (document.getElementById('recherche').value.length > 2)
    {
      document.getElementById('msgErreur').textContent = "";

      var erreur = false;

      if (xhr.status != 200) {
        var msgErreur = 'Erreur (code=' + xhr.status + '): La requête HTTP à plantée';
        document.getElementById('msgErreur').textContent = msgErreur;
        erreur = true;
      }
      else {
        try {
          unUsager = JSON.parse(xhr.responseText);
        } catch (e) {
          alert ('ERREUR: La réponse AJAX n\'est pas une expression JSON valide.');
          erreur = true;
        }

        if (!erreur) {
          if (unUsager.erreur) {
            var msgErreur = 'Erreur: ' + unUsager.erreur.message;
            document.getElementById('msgErreur').textContent = msgErreur;

            //Vide la liste
            while(document.getElementById('lstUsager').firstChild) document.getElementById('lstUsager').removeChild(document.getElementById('lstUsager').firstChild);
          } else {

            var divLst = document.getElementById('lstUsager');
            while (divLst.firstChild) divLst.removeChild(divLst.firstChild);

            var element = document.createElement('ul');
            divLst.appendChild(element);

            //On boucle sur tous les usagers retourner par le JSON
            for (i=0; i < unUsager.length; i++) {
              var elem = document.createElement('li');
              var catego;
              //Donne un nom significatif aux catégories
              switch (unUsager[i].idCategories) {
                case '1':
                catego = "admin";
                  break;
                case '2':
                catego = "membre";
                default:
              }

              //Chaine de caractère affichée
              elem.textContent = catego + ', ' + unUsager[i].prenom + ' ' + unUsager[i].nom + ', ' + unUsager[i].login;

              elem.setAttribute('id', 'no'+i);
              elem.addEventListener('click',selectionneItem,false);
              element.appendChild(elem);
            }
          }
        }
      }
    }
    else {
      document.getElementById('btnRecherche').disabled = true;
    }
  }
}

function selectionneItem(e) {
  //Ouvre la partie de modif dans la page
  document.getElementById('collapse2').className = 'panel-collapse collapse in';
  document.getElementById('collapse1').className = 'panel-collapse collapse';

  //L'usager selectionné dans la liste
  var usagerSelect = e.target.textContent;

  //Split sur les virgules pour le login
  var arrayUsager = usagerSelect.split(', ');
  //Split sur les espaces pour le nom et prénom
  var arrayNoms = arrayUsager[1].split(' ');
  var valeurLogin = arrayUsager[2];
  //On recherche dans la liste pour pré-sélectionner le bon index avec le bon login
  for(var i =0; i < document.getElementById('selectUsagerModif').options.length; i++) {
    if(document.getElementById('selectUsagerModif').options[i].innerHTML == valeurLogin) {
      document.getElementById('selectUsagerModif').selectedIndex = i;
    }
  }
  //Affectation des valeurs dans les champs pour le bon utilisateurs à modifier
  document.getElementById('modifPrenom').value = arrayNoms[0];
  document.getElementById('modifNom').value = arrayNoms[1];
  document.getElementById('lstUsager').className = 'masquer';

}
