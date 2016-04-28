/******************************************************************************
Fichier:	fonctions.h

Auteur:		Mehdi Laribi et Alexis C�t�

Utilit�:	Biblioth�que contenant des fonctions destin�es au traitement de
l'application de recherche index�e
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
Constante contenant le nom du fichier avec les cartes index�es
******************************************************************************/
const string strNomFichierIndex = "nom_carte.index";




/******************************************************************************
M�thode qui permet de v�rifier si le fichier index existe
Retourne True si oui, false dans le cas contraire
******************************************************************************/
bool VerifierIndexExiste();

/******************************************************************************
M�thode qui permet de v�rifier si le fichier primaire contenant les cartes
existe. retourne True si oui, false dans le cas contraire
******************************************************************************/
bool FichierTextExistant();

/******************************************************************************
M�thode qui permet de calculer le nombre de lignes dans le fichier de d�part
Donc le nombre de carte. Retourne le nombre de lignes - 1, ce qui va permettre
d'exclure la ligne de description
******************************************************************************/
const unsigned int GetNombreCartes();

/******************************************************************************
M�thode qui permet de lire le fichier de d�part contenant toutes les cartes
du jeu MTG "Magic The Gathering", d'aller chercher le nom de la carte ainsi que 
sa position dans le fichier et retourne un vecteur d'objet de type 
CCarteIndex.
******************************************************************************/
CCarteIndex* LectureFichier(int iNbCartes);

/******************************************************************************
M�thode qui, apr�s v�rification de l'existence du fichier index et triage des
cartes selon le nom, permet d'�crire toutes les cartes index�s pour faciliter
la recherche. Cr�e le fichier dans le cas ou le fichier est inexistant.
Ne retourne rien
******************************************************************************/
int CreerIndex();

/******************************************************************************
M�thode qui permet de comparer deux nom re�us en param�tre. Retourne True dans
le cas ou les deux sont pareilles, false dans le cas contraire.
******************************************************************************/
bool NomPareille(string strNomCarteVoulu, string strNomCarteComparee);

/******************************************************************************
M�thode qui permet de faire la recherche du fichier index qui re�ois en
param�tre le nom recherch� (insensible � la casse) et le nombre de cartes.
Retourne un pointeur sur vecteur de pointeur de type CCarte.
******************************************************************************/
CCarte ** Rechercher(string strNom, int * iNbCartes);

/******************************************************************************
M�thode qui permet de cr�er un carte gr�ce � son identifiant unique. Re�ois en
param�tre la position dans le fichier de d�part et retourne un pointeur sur une 
objet de type carte
******************************************************************************/
CCarte * CreerCarteParID(int iPosition);

/******************************************************************************
Permet de lib�rer la m�moire allou�e dynamiquement � un vecteur de pointeurs
de type CCarteIndex. Re�ois en param�tre un pointeur du vecteur et le nombre de
cartes.
******************************************************************************/
void LibererCartesIndex(CCarteIndex ** pLesCartes, unsigned int uiNbCartes);

/******************************************************************************
Permet de lib�rer la m�moire allou�e dynamiquement � un vecteur de pointeurs
de type CCarte. Re�ois en param�tre un pointeur du vecteur et le nombre de
cartes.
******************************************************************************/
void LibererCartes(CCarte ** pLesCartes, unsigned int uiNbCartes);


#endif