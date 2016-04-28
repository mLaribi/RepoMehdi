/******************************************************************************
Fichier:	fonctions.cpp

Auteur:		Mehdi Laribi et Alexis Côté

Utilité:	Implémentation de la bibliothèque contenant des fonctions destinées
au traitement de l'application de recherche indexée
******************************************************************************/
#include "Fonctions.h"
#include <algorithm>




/******************************************************************************
Méthode qui permet de vérifier si le fichier index existe
Retourne True si oui, false dans le cas contraire
******************************************************************************/
bool VerifierIndexExiste()
{

	fstream fsFicIndex;
	//Ouverture du fichier index
	fsFicIndex.open(strNomFichierIndex, ios::in | ios::binary);
	if (!fsFicIndex.fail())
	{
		//Si l'ouverture est réussie, le flux est fermé et retourne true
		fsFicIndex.close();
		return true;
	}
	//Retourne false si l'ouverture a échoué
	return false;
}


/******************************************************************************
Méthode qui permet de vérifier si le fichier primaire contenant les cartes
existe. retourne True si oui, false dans le cas contraire
******************************************************************************/
bool FichierTextExistant()
{
	fstream fsFicPrimaire;
	//Ouverture du fichier contenant toutes les cartes
	fsFicPrimaire.open(strNomFichierCartes, ios::in | ios::binary);
	if (!fsFicPrimaire.fail())
	{
		//Si l'ouverture est réussie, le flux est fermé et retourne true
		fsFicPrimaire.close();
		return true;
	}
	//Retourne false si l'ouverture a échoué
	return false;
}


/******************************************************************************
Méthode qui permet de calculer le nombre de lignes dans le fichier de départ
Donc le nombre de carte. Retourne le nombre de lignes - 1, ce qui va permettre
d'exclure la ligne de description
******************************************************************************/
const unsigned int GetNombreCartes()
{
	unsigned int uiNbCartes = 0;
	string ligne;
	if (FichierTextExistant())
	{
		fstream fsFicPrimaire;

		fsFicPrimaire.open(strNomFichierCartes, ios::in | ios::binary);
		if (!fsFicPrimaire.fail())
		{
			for (uiNbCartes; getline(fsFicPrimaire, ligne); uiNbCartes++);
		}
		fsFicPrimaire.close();
	}
	return uiNbCartes - 1;
}


/******************************************************************************
Méthode qui permet de lire le fichier de départ contenant toutes les cartes
du jeu MTG "Magic The Gathering", d'aller chercher le nom de la carte ainsi que
sa position dans le fichier et retourne un vecteur d'objet de type
CCarteIndex. Lance une exception dans le cas où le fichier est introuvable.
******************************************************************************/
CCarteIndex* LectureFichier(unsigned int uiNbCartes)
{

	if (FichierTextExistant())
	{

		fstream fsFichPrimaire;
		unsigned int uiCpt = 0;
		string strNom;
		string ligne;
		int iPosition;
		CCarteIndex* lesCartesIndex = new CCarteIndex[uiNbCartes];
		fsFichPrimaire.open(strNomFichierCartes, ios::in | ios::binary);
		getline(fsFichPrimaire, ligne);

		//Parcours toutes les lignes du fichiers jusqu'à la fin du fichier
		//Récupère la position de la carte ainsi que son nom, si la ligne
		//n'est pas vide
		while (!fsFichPrimaire.eof())
		{
			
			iPosition = (int)fsFichPrimaire.tellg();
			getline(fsFichPrimaire, ligne);
			if (ligne != "")
			{
				int iposCar = ligne.find('|');
				ligne = ligne.erase(iposCar, 1);
				int iPosCarFin = ligne.find('|');
				strNom = ligne.substr(iposCar, iPosCarFin - iposCar);


				//Ajout de la carte indexée dans le vecteur d'objet.
				lesCartesIndex[uiCpt].NomCarte() = strNom;
				lesCartesIndex[uiCpt].PositionCarte() = iPosition;
				uiCpt++;
			}
		}

		//Ferme le fichier et retourne le vecteur d'objet
		fsFichPrimaire.close();
		return lesCartesIndex;

	}
	else
	{
		throw "ERREUR: VERIFIER LA PRESENCE DU FICHIER DE DONNEES ""mtg.txt""";
	}
	
}


/******************************************************************************
Méthode qui, après vérification de l'existence du fichier index et triage des
cartes selon le nom, permet d'écrire toutes les cartes indexés pour faciliter
la recherche. Crée le fichier dans le cas ou le fichier est inexistant.
Retourne le nombre de cartes écrit dans le fichier.
******************************************************************************/
int CreerIndex()
{
	fstream fsFicIndex;
	unsigned int uiNbCartes = GetNombreCartes();
	unsigned int uiCpt = 0;


	CCarteIndex* plesCartesIndex = LectureFichier(uiNbCartes);
	
	sort(plesCartesIndex, plesCartesIndex + uiNbCartes);


	//Ouverture du fichier index, si l'ouverture échoue,lance une exception
	//sinon les cartes(nom et position) sont écrite dans le fichier
	fsFicIndex.open(strNomFichierIndex, ios::out | ios::binary);
	if (!fsFicIndex.fail())
	{
		char szEnregistrement[41];
		int iDiffMajMin = ('Z' - 'z');

		for (uiCpt = 0; uiCpt < uiNbCartes; uiCpt++)
		{
			sprintf_s(szEnregistrement, "%-30s%010d",
				plesCartesIndex[uiCpt].NomCarte().c_str(),
				to_string(plesCartesIndex[uiCpt].PositionCarte()).c_str());
			
			for (unsigned int i = 0; i < 41; i++)
			{
				if (isupper(szEnregistrement[i]))
				{
					szEnregistrement[i] = szEnregistrement[i] - iDiffMajMin;
				}
			}
			fsFicIndex.write(szEnregistrement, 40);
		}
	}
	else
	{
		throw "Une erreur s'est produite lors de l'ouverture du fichier!";
	}
	fsFicIndex.close();

	delete[] plesCartesIndex;
	plesCartesIndex = NULL;

	return uiCpt;
}


/******************************************************************************
Méthode qui permet de faire la recherche du fichier index qui reçois en
paramètre le nom recherché (insensible à la casse) et le nombre de cartes.
Retourne un pointeur sur vecteur de pointeur de type CCarte.
******************************************************************************/
CCarte ** Rechercher(string strNom,  int * iNbCartes)
{
	fstream lectureIndex;
	lectureIndex.open("./" + strNomFichierIndex, ios_base::in);
	CCarte ** pplesCartes = NULL;
	if (!lectureIndex.fail())
	{
		lectureIndex.seekg(0, lectureIndex.end);
		int ipos = (int)lectureIndex.tellg() / 80;
		int inbCarteRestanteAVerifier = ipos;
		char szCarte[31] = "";
		string strCarteActive;
		bool bTrouve = false;
		do
		{
			lectureIndex.seekg(ipos*40, lectureIndex.beg);
			lectureIndex.read(szCarte, 30);
			strCarteActive = szCarte;
			if (inbCarteRestanteAVerifier % 2 == 0)
			{
				inbCarteRestanteAVerifier /= 2;
			}
			else
			{
				inbCarteRestanteAVerifier /= 2;
				inbCarteRestanteAVerifier++;
			}

			if (NomPareille(strCarteActive, strNom))
			{
				bTrouve = true;
			}
			else if (strCarteActive > strNom)
			{
				ipos -= inbCarteRestanteAVerifier;
			}
			else
			{
				ipos += inbCarteRestanteAVerifier;
			}

		} while (!bTrouve && inbCarteRestanteAVerifier > 0);

		if (bTrouve)
		{
			int inbCarte = 1;

			lectureIndex.seekg((ipos - 1) * 40, lectureIndex.beg);
			lectureIndex.read(szCarte, 30);
			strCarteActive = szCarte;

			while (NomPareille(strCarteActive, strNom))
			{
				ipos--;
				inbCarte++;
				lectureIndex.seekg((ipos-1) * 40, lectureIndex.beg);
				lectureIndex.read(szCarte, 30);
				strCarteActive = szCarte;
			}

			ipos += inbCarte - 1;

			lectureIndex.seekg((ipos+1) * 40, lectureIndex.beg);
			lectureIndex.read(szCarte, 30);
			strCarteActive = szCarte;

			while (NomPareille(strCarteActive, strNom))
			{
				ipos++;
				inbCarte++;
				lectureIndex.seekg((ipos + 1) * 40, lectureIndex.beg);
				lectureIndex.read(szCarte, 30);
				strCarteActive = szCarte;
			}

			ipos -= inbCarte - 1;

			(*iNbCartes) = inbCarte;
			pplesCartes = new CCarte * [inbCarte];
			char szID[11] = "";
			lectureIndex.seekg(((ipos) * 40) + 30, lectureIndex.beg);
			for (int i = 0; i < inbCarte; i++)
			{			
				lectureIndex.read(szID, 10);
				lectureIndex.seekg(30, ios::cur);
				pplesCartes[i] = CreerCarteParID(atoi(szID));
			}
		}

	}

	lectureIndex.close();

	return pplesCartes;
}


/******************************************************************************
Méthode qui permet de comparer deux nom reçus en paramètre. Retourne True dans
le cas ou les deux sont pareilles, false dans le cas contraire.
******************************************************************************/
bool NomPareille(string strNomCarteVoulu, string strNomCarteCompare)
{
	int iDiffMajMin = ('Z' - 'z');
	for (unsigned int i = 0; i < strNomCarteCompare.length(); i++)
	{
		if ( isupper(strNomCarteCompare[i]))
		{
			strNomCarteCompare[i] = strNomCarteCompare[i] + iDiffMajMin;
		}
	}

	for (unsigned int i = 0; i < strNomCarteVoulu.length(); i++)
	{
		if (isupper(strNomCarteVoulu[i]))
		{
			strNomCarteVoulu[i] = strNomCarteVoulu[i] - iDiffMajMin;
		}
	}
	int icpt = 30;
	string strnomTrime = "";
	do
	{
		icpt--;
	} while (strNomCarteVoulu[icpt] == ' ');

	for (int i = 0; i <= icpt; i++)
	{
		strnomTrime += strNomCarteVoulu[i];
	}
	if (strnomTrime.length() == strNomCarteCompare.length())
	{
			return strnomTrime == strNomCarteCompare;
	}
	return false;
	
}

/******************************************************************************
Méthode qui permet de créer un carte grâce à son identifiant unique. Reçois en
paramètre la position dans le fichier de départ et retourne un pointeur sur une
objet de type carte
******************************************************************************/
CCarte * CreerCarteParID(int iposition)
{

	fstream lectureCartes;
	lectureCartes.open("./" + strNomFichierCartes, ios_base::in);
	CCarte * plaCarte = NULL;

	if (!lectureCartes.fail())
	{
		while (lectureCartes.get() != '\n');

		string strInfosCartes[13];
		int iCompteur = 0;
		char cCurrent = ' ';

		lectureCartes.seekg(iposition, ios::beg);
		if (!lectureCartes.eof())
		{
			while (cCurrent != '\n')
			{
				cCurrent = lectureCartes.get();
				while (cCurrent != '|' && cCurrent != '\n')
				{
					strInfosCartes[iCompteur] += cCurrent;
					cCurrent = lectureCartes.get();
				}
				iCompteur++;
			}

			plaCarte = new CCarte(atoi(strInfosCartes[0].c_str()),
				strInfosCartes[1],
				strInfosCartes[2],
				strInfosCartes[3],
				strInfosCartes[4],
				strInfosCartes[5],
				strInfosCartes[7],
				strInfosCartes[8],
				strInfosCartes[6]);
		}
	}
		
	
	return plaCarte;
}