/******************************************************************************
Fichier:	carte.cpp

Classe:		CCarte

Auteur:		Stéphane Lapointe

Utilité:	Implémentation des méthodes de la classe CCarte représentant
			une carte du jeu "Magic The Gathering".
******************************************************************************/

#include "carte.h"

CCarte::CCarte(	int iId, const string & strNom, const string & strCost,
				const string & strType, const string & strPower,
				const string & strToughness, const string & strSet,
				const string & strRarity, const string & strOracle)
	:	m_iId(iId), m_strNom(strNom), m_strCost(strCost), m_strType(strType),
		m_strPower(strPower), m_strToughness(strToughness), m_strSet(strSet),
		m_strRarity(strRarity), m_strOracle(strOracle)
{}

int CCarte :: GetId() const
{
	return this->m_iId;
}
const string & CCarte :: GetNom() const
{
	return this->m_strNom;
}
const string & CCarte :: GetCost() const
{
	return this->m_strCost;
}
const string & CCarte :: GetType() const
{
	return this->m_strType;
}
const string & CCarte :: GetPower() const
{
	return this->m_strPower;
}
const string & CCarte :: GetToughness() const
{
	return this->m_strToughness;
}
const string & CCarte :: GetSet() const
{
	return this->m_strSet;
}
const string & CCarte :: GetRarity() const
{
	return this->m_strRarity;
}
const string & CCarte :: GetOracle() const
{
	return this->m_strOracle;
}
