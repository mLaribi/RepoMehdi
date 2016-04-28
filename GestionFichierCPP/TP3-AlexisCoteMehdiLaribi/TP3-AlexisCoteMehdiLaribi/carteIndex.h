/******************************************************************************
Fichier:	carteIndex.h

Classe:		CCarteIndex

Auteur:		Mehdi Laribi et Alexis C�t�

Utilit�:	D�claration de la classe CCarteIndex repr�sentant une carte
index�es dans le fichier index du jeu "Magic The Gathering".
******************************************************************************/

#ifndef __CARTEINDEX_H
#define __CARTEINDEX_H

#include <string>

using namespace std;

class CCarteIndex
{

public:
	//Constructeur par d�faut
	CCarteIndex();
	//Constructeur param�tr� qui re�oit un nom et la position de la carte dans 
	//fichier index
	CCarteIndex(const string & strNom, int iPos);

	//Permet d'obtenir le nom de la carte
	string & NomCarte();
	//Permet d'obtenir la position de la carte
	int & PositionCarte();
	//Red�finition de l'op�rateur <
	bool operator < (const CCarteIndex & CCarte) const;
//Attributs de la classe
private:

	//Position
	int m_iPos;
	//Nom de la carte
	string m_strNom;
};

#endif