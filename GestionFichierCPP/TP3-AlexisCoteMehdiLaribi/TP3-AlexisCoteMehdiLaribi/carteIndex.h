/******************************************************************************
Fichier:	carteIndex.h

Classe:		CCarteIndex

Auteur:		Mehdi Laribi et Alexis Côté

Utilité:	Déclaration de la classe CCarteIndex représentant une carte
indexées dans le fichier index du jeu "Magic The Gathering".
******************************************************************************/

#ifndef __CARTEINDEX_H
#define __CARTEINDEX_H

#include <string>

using namespace std;

class CCarteIndex
{

public:
	//Constructeur par défaut
	CCarteIndex();
	//Constructeur paramétré qui reçoit un nom et la position de la carte dans 
	//fichier index
	CCarteIndex(const string & strNom, int iPos);

	//Permet d'obtenir le nom de la carte
	string & NomCarte();
	//Permet d'obtenir la position de la carte
	int & PositionCarte();
	//Redéfinition de l'opérateur <
	bool operator < (const CCarteIndex & CCarte) const;
//Attributs de la classe
private:

	//Position
	int m_iPos;
	//Nom de la carte
	string m_strNom;
};

#endif