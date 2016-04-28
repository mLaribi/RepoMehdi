/******************************************************************************
Fichier:	carte.h

Classe:		CCarte

Auteur:		Stéphane Lapointe

Utilité:	Déclaration de la classe CCarte représentant une carte
			du jeu MTG "Magic The Gathering".
******************************************************************************/

#ifndef __CARTE_H
#define __CARTE_H

#include <string>

using namespace std;

class CCarte
{
	public:
		// Constructeur paramétré.
		CCarte(	int iId, const string & strNom, const string & strCost,
				const string & strType, const string & strPower,
				const string & strToughness, const string & strSet,
				const string & strRarity, const string & strOracle);

		// Getters.
		int GetId() const;
		const string & GetNom() const;
		const string & GetCost() const;
		const string & GetType() const;
		const string & GetPower() const;
		const string & GetToughness() const;
		const string & GetSet() const;
		const string & GetRarity() const;
		const string & GetOracle() const;

	private:
		// Quelques informations utiles sur la carte.
		int    m_iId;
		string m_strNom;
		string m_strCost;
		string m_strType;
		string m_strPower;
		string m_strToughness;
		string m_strSet;
		string m_strRarity;
		string m_strOracle;
};

#endif