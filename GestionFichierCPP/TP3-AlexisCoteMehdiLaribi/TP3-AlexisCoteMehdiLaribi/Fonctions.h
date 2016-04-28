/******************************************************************************
Fichier:	fonctions.h

Auteur:		Mehdi Laribi et Alexis Côté

Utilité:	Bibliothèque contenant des fonctions destinées au traitement de
l'application de recherche indexée
******************************************************************************/
#ifndef __FONCTIONS_H
#define __FONCTIONS_H

#include "carte.h"
#include "carteIndex.h"
#include <vector>
#include <fstream>

/******************************************************************************
Constante contenant le nom du fichier de toutes les cartes 
******************************************************************************/
const string strNomFichierCartes = "mtg.txt";

/******************************************************************************
Constante contenant le nom du fichier avec les cartes indexées
******************************************************************************/
const string strNomFichierIndex = "nom_carte.index";




/******************************************************************************
Méthode qui permet de vérifier si le fichier index existe
Retourne True si oui, false dans le cas contraire
******************************************************************************/
bool VerifierIndexExiste();

/******************************************************************************
Méthode qui permet de vérifier si le fichier primaire contenant les cartes
existe. retourne True si oui, false dans le cas contraire
******************************************************************************/
bool FichierTextExistant();

/******************************************************************************
Méthode qui permet de calculer le nombre de lignes dans le fichier de départ
Donc le nombre de carte. Retourne le nombre de lignes - 1, ce qui va permettre
d'exclure la ligne de description
******************************************************************************/
const unsigned int GetNombreCartes();

/******************************************************************************
Méthode qui permet de lire le fichier de départ contenant toutes les cartes
du jeu MTG "Magic The Gathering", d'aller chercher le nom de la carte ainsi que 
sa position dans le fichier et retourne un vecteur d'objet de type 
CCarteIndex.
******************************************************************************/
CCarteIndex* LectureFichier(int iNbCartes);

/******************************************************************************
Méthode qui, après vérification de l'existence du fichier index et triage des
cartes selon le nom, permet d'écrire toutes les cartes indexés pour faciliter
la recherche. Crée le fichier dans le cas ou le fichier est inexistant.
Ne retourne rien
******************************************************************************/
int CreerIndex();

/******************************************************************************
Méthode qui permet de comparer deux nom reçus en paramètre. Retourne True dans
le cas ou les deux sont pareilles, false dans le cas contraire.
******************************************************************************/
bool NomPareille(string strNomCarteVoulu, string strNomCarteComparee);

/******************************************************************************
Méthode qui permet de faire la recherche du fichier index qui reçois en
paramètre le nom recherché (insensible à la casse) et le nombre de cartes.
Retourne un pointeur sur vecteur de pointeur de type CCarte.
******************************************************************************/
CCarte ** Rechercher(string strNom, int * iNbCartes);

/******************************************************************************
Méthode qui permet de créer un carte grâce à son identifiant unique. Reçois en
paramètre la position dans le fichier de départ et retourne un pointeur sur une 
objet de type carte
******************************************************************************/
CCarte * CreerCarteParID(int iPosition);

/******************************************************************************
Permet de libérer la mémoire allouée dynamiquement à un vecteur de pointeurs
de type CCarteIndex. Reçois en paramètre un pointeur du vecteur et le nombre de
cartes.
******************************************************************************/
void LibererCartesIndex(CCarteIndex ** pLesCartes, unsigned int uiNbCartes);

/******************************************************************************
Permet de libérer la mémoire allouée dynamiquement à un vecteur de pointeurs
de type CCarte. Reçois en paramètre un pointeur du vecteur et le nombre de
cartes.
******************************************************************************/
void LibererCartes(CCarte ** pLesCartes, unsigned int uiNbCartes);


#endif