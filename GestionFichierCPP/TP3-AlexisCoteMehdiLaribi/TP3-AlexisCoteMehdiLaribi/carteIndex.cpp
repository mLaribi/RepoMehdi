/******************************************************************************
Fichier:	carteIndex.cpp

Classe:		CCarteIndex

Auteur:		Mehdi Laribi et Alexis C�t� 

Utilit�:	Impl�mentation des m�thodes de la classe CCarteIndex repr�sentant
une carte index�e dans le fichier index du jeu "Magic The Gathering".
******************************************************************************/

#include "carteIndex.h"


/******************************************************************************
Constructeur param�tr� qui re�oit un nom et la position de la carte dans
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
Red�finition de l'op�rateur plus petit pour le tri
******************************************************************************/
bool CCarteIndex::operator< (const CCarteIndex & cCarteComp) const
{
	return (this->m_strNom < cCarteComp.m_strNom);
}
