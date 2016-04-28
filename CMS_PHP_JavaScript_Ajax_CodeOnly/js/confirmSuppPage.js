window.addEventListener('load', init , false);


function init(){

    //Supprimer page
    document.getElementById('supprimer').addEventListener('click', ConfirmSupp, false);

}


function ConfirmSupp(e){

var rep = confirm("Etes-vous vraiment certain de vouloir supprimer cet élément?", "Sérieux?");
    if(!rep){
    e.preventDefault();
    }
}
