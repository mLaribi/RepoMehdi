window.addEventListener('load', init , false);


function init(){

//Supprimer Utilisateur
    document.getElementById('btnSupp').addEventListener('click', ConfirmSupp, false);
}


function ConfirmSupp(e){

var rep = confirm("Etes-vous vraiment certain de vouloir supprimer cet élément?", "Sérieux?");
    if(!rep){
    e.preventDefault();
    }
}
