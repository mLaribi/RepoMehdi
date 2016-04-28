/******************************************************************************
Fichier:	carteIndex.cpp

Classe:		CCarteIndex

Auteur:		Mehdi Laribi et Alexis Côté 

Utilité:	Implémentation des méthodes de la classe CCarteIndex représentant
une carte indexée dans le fichier index du jeu "Magic The Gathering".
******************************************************************************/

#include "carteIndex.h"


/******************************************************************************
Constructeur paramétré qui reçoit un nom et la position de la carte dans
fichier index
******************************************************************************/
CCarteIndex::CCarteIndex()
{
}
CCarteIndex::CCarteIndex(const string & strNom, int iPos)
:m_strNom(strNom), m_iPos(iPos)
{}

/******************************************************************************
Permet d'obtenir le nom de la carte
******************************************************************************/
string & CCarteIndex::NomCarte()
{
	return m_strNom;
}

/******************************************************************************
Permet d'obtenir la position de la carte
******************************************************************************/
int & CCarteIndex::PositionCarte() 
{
	return m_iPos;
}


/******************************************************************************
Redéfinition de l'opérateur plus petit pour le tri
******************************************************************************/
bool CCarteIndex::operator< (const CCarteIndex & cCarteComp) const
{
	return (this->m_strNom < cCarteComp.m_strNom);
}
