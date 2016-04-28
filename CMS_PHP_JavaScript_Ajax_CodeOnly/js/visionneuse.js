//Au lancement de la page
window.addEventListener('load', init, false);

//Le nombre d'images chargés dynamiquement
    var nbImages = (document.getElementById("lstVignettes").getElementsByTagName("li"));
// Variables globales   
    var timer, indiceImage = 1, lastIndice = 1;


function init()
{
//Démarre le timer pour le changement d'images automatique
    timer = window.setInterval(NextImage, 2000);

    
    for(var i = 1; i <= nbImages.length; i++){

        //Pour chaque images : Evenement : Click, souris sur l'image, en dehors de l'image
    document.getElementById("img"+i).addEventListener('click', afficherImage, false);
    document.getElementById("img"+i).addEventListener('mouseover', hoverImage, false);
    document.getElementById("img"+i).addEventListener('mouseout', blurImage, false);
        
        //Met en transparence les images
    document.getElementById("img"+i).style.opacity = "0.4";
    }
    
    //Opacité normale pour la premiere image
    document.getElementById("img1").style.opacity = "1";
    
    //Evenement sur la grande image
    //Click: redirection, Mouseover : pause du timer et l'image, MouseOut: Timer repris
    document.getElementById("imgAff").addEventListener('mouseover', pauseTimer, false);
    document.getElementById("imgAff").addEventListener('mouseout', reprendTimer, false);
    document.getElementById("imgAff").addEventListener('click', RedirectionPage, false);

}

//Affiche l'image séléctionnée dans la liste des images miniatures
function afficherImage(e){

    
    var element = document.getElementById("imgAff").src;
    //Indice de l'image affichée dernierement
    lastIndice = element.substring(element.indexOf("img")+3).replace(".jpg", "");
    //Remet la derniere image plus pâle
    document.getElementById("img"+lastIndice).style.opacity = "0.4";
    //Affiche l'image
    document.getElementById("imgAff").src = "images/Visionneuse/" + e.target.id + ".jpg";
    //Indice de l'image actuelle
    indiceImage = e.target.id.substring(3);
}

//Survol des elements de la liste
function hoverImage(e){
// Mise en evidence de l'image voulue
	document.getElementById(e.target.id).style.border = "3px solid red";
	document.getElementById(e.target.id).style.cursor = "pointer";
    document.getElementById(e.target.id).style.opacity = "1";
}

//Fin du survol
function blurImage(e){

    //L'image n'est plus mise en évidence  (Pas trouvé mieux comme phrase)
    if(e.target.src != document.getElementById("imgAff").src)
    {
    document.getElementById(e.target.id).style.opacity = "0.4";
    }
    document.getElementById(e.target.id).style.border = "none";
    document.getElementById(e.target.id).style.color = "black";
	document.getElementById(e.target.id).style.cursor = "default";
}

//Prochaine image selon le timer
function NextImage(){

    //Si la derniere image de la liste, l'indice est remis a 1
    //Pour recommencer du début
    if(indiceImage > nbImages.length){
    indiceImage = 1;
    }
//Si la premiere image, remet en pâle la derniere image de la liste
    if(indiceImage === 1){
    document.getElementById("img"+indiceImage).style.opacity = "1";
    document.getElementById("img"+nbImages.length).style.opacity = "0.4";
    }
    if(indiceImage !== 1)
    {
    document.getElementById("img"+(indiceImage-1)).style.opacity = "0.4";
    }
    document.getElementById("imgAff").src = "images/Visionneuse/img" + indiceImage + ".jpg";
    document.getElementById("img"+indiceImage).style.opacity = "1";
//Incrémentation de l'indice d'image
    indiceImage++;

}


//Pause sur le timer
function pauseTimer(){
    document.getElementById("imgAff").style.cursor = "pointer";
    clearTimeout(timer);

}

//reprend le timer
function reprendTimer(){
    timer = window.setInterval(NextImage, 2000);
}

//Redirection vers une page avec un indice égale a celle de l'image (Plus simple)
function RedirectionPage()
{
    window.location.href = "http://localhost/Tp2/index.php?$id=" + indiceImage;

}
