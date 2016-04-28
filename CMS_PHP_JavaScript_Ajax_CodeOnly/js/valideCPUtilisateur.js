
//Au chargement de la fenetre
window.addEventListener('load', init, false);

//Variable qui contiendra toutes les erreurs
var message = [];
var frmEnvoi = true;
//Fonction appelée au load
function init()
{
    //Si le fureteur supporte la derniere version de html5
    if(!supporte_validation_html5())
		alert("Votre navigateur ne supporte pas le HTML5!")
	else
	{
        //Lors de la perte de focus par chacun des champs
        document.getElementById("txtNom").addEventListener('blur', EnleverErreur, false);
        document.getElementById("txtPrenom").addEventListener('blur', EnleverErreur, false);
        document.getElementById("nomCompte").addEventListener('blur', EnleverErreur, false);
        document.getElementById("passwordAjoutConf").addEventListener('blur', EnleverErreur, false);
        document.getElementById("passwordAjout").addEventListener('blur', EnleverErreur, false);
        document.getElementById("btnAjout").addEventListener('click',Confirmation, false);

    }
}


function validerTout() {
  if (frmEnvoi)
    document.getElementById("btnAjout").disabled = false;
    else {
      document.getElementById("btnAjout").disabled = true;
    }
}
// Fonction premettant de savoir si le navigateur supporte le html5 en vérifiant
// si la méthode checkValidity existe sur un élément input.
function supporte_validation_html5() {
	return (typeof document.createElement("input").checkValidity == "function");
}


//Assez inutile de changer la couleur de l'étiquette (assez laid)

function champsValides()
{
  
  if (frmEnvoi && message.length == 0)
    document.getElementById("btnAjout").disabled = false;
}

// Fonction qui enlève les espaces blancs et vérifie si le champ est valide
function EnleverErreur(e){
    // on enlève les espaces blancs au début et à la fin de la chaine
    e.currentTarget.value = enleverBlancs(e.currentTarget.value)
    // on efface les erreurs précédentes
	e.currentTarget.setCustomValidity('');
    frmEnvoi = true;

    switch(e.currentTarget.id)
    {
            //Prenom
    case "txtPrenom":
      if (e.currentTarget.value.length === 0)
			{
        //ajoute l'erreur si elle n'est pas déjà dans le tableau
        if(message.indexOf("Veuillez remplir correctement le champ prénom") == -1)
        {
          message.push("Veuillez remplir correctement le champ prénom");
        }
        frmEnvoi = false;
			}
      else {
        //retire l'erreur pour ne pas avoir de doublon dans le tableau
        if (message.indexOf("Veuillez remplir correctement le champ prénom") != -1)
          var index = message.indexOf("Veuillez remplir correctement le champ prénom");
          message.splice(index,1);
      }
			break;

            //nom
    case "txtNom":
      if (e.currentTarget.value.length === 0)
			{
        //ajoute l'erreur si elle n'est pas déjà dans le tableau
        if(message.indexOf("Veuillez remplir correctement le champ nom") == -1)
        {
          message.push("Veuillez remplir correctement le champ nom");
        }
				frmEnvoi = false;
			}
      else {
        //retire l'erreur pour ne pas avoir de doublon dans le tableau
        if (message.indexOf("Veuillez remplir correctement le champ nom") != -1)
          var index = message.indexOf("Veuillez remplir correctement le champ nom");
          message.splice(index,1);
      }
			break;
            // Nom du compte
    case "nomCompte":
      if (e.currentTarget.value.length === 0)
			{
        //ajoute l'erreur si elle n'est pas déjà dans le tableau
        if(message.indexOf("Veuillez remplir correctement le champ identifiant") == -1)
        {
          message.push("Veuillez remplir correctement le champ identifiant");
        }
        frmEnvoi = false;
			}
      else {
        //retire l'erreur pour ne pas avoir de doublon dans le tableau
        if (message.indexOf("Veuillez remplir correctement le champ identifiant") != -1)
          var index = message.indexOf("Veuillez remplir correctement le champ identifiant");
          message.splice(index,1);
      }
			break;

            //mot de passe
    case "passwordAjout":
      if (e.currentTarget.value.length === 0)
			{
        //ajoute l'erreur si elle n'est pas déjà dans le tableau
        if(message.indexOf("Veuillez remplir correctement le champ mot de passe") == -1)
        {
          message.push("Veuillez remplir correctement le champ mot de passe");
        }
        frmEnvoi = false;
			}
      else {
        //retire l'erreur pour ne pas avoir de doublon dans le tableau
        if (message.indexOf("Veuillez remplir correctement le champ mot de passe") != -1)
          var index = message.indexOf("Veuillez remplir correctement le champ mot de passe");
          message.splice(index,1);
      }
			break;

            //Confirmation du mot de passe
    case "passwordAjoutConf":
            var passConf = document.getElementById("passwordAjout");
            var passDeux = document.getElementById("passwordAjoutConf");
      if ((passDeux.value  != passConf.value))
			{
        //ajoute l'erreur si elle n'est pas déjà dans le tableau
        if(message.indexOf("Les deux mots de passes ne correspendent pas") == -1)
        {
          message.push("Les deux mots de passes ne correspendent pas");
        }
        frmEnvoi = false;
			}
      else {
        //retire l'erreur pour ne pas avoir de doublon dans le tableau
        if (message.indexOf("Les deux mots de passes ne correspendent pas") != -1)
          var index = message.indexOf("Les deux mots de passes ne correspendent pas");
          message.splice(index,1);
      }
			break;

     }
    // si le champ cible n'est pas valide
    if (!e.currentTarget.validity.valid || !frmEnvoi)
	{
    //Affichage du message d'erreur.
    var div = document.getElementById("erreurArea");
        if(!frmEnvoi)
            {
              div.innerHTML = "";
              var titre = document.createElement("h4");
              titre.innerHTML = "ERREURS";
                for(i = 0; i < message.length; i++) {
                  var para = document.createElement("p");
                  var node = document.createTextNode(message[i]);

                  para.appendChild(node);
                  div.appendChild(para);
                }
            }
            else
            {
                div.style.display = "none";
            }
    e.currentTarget.style.backgroundColor = "red";
    }
    else
    {
    e.currentTarget.style.backgroundColor = "initial";
    }

    validerTout();
}

//Confirmation avant l'envoi du formulaire
function Confirmation()
{
   //Si valide
if(frmEnvoi){
    var rep = confirm("Voulez-vous ajouter cet utilisateur?", "Ajout");
    //Si reponse "Cancel" empeche la soumission du formulaire
        if(!rep ){
        e.preventDefault();
        }
}
    else
    {
        alert("Remplissez les champs svp!");
    }
}
