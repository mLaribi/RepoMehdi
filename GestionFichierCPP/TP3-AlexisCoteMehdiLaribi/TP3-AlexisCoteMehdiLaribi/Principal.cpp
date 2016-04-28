/******************************************************************************
Fichier:	principal.cpp

Auteur:		Mehdi Laribi et Alexis Côté

Utilite:	Fichier qui permet d'exécuter toutes les fonctions de
pour l'assignation des tâches du projet
******************************************************************************/
#include "Fonctions.h"
#include <iostream>

#ifdef _WIN32
const char EFFACER_ECRAN[] = "cls";
#else
const char EFFACER_ECRAN[] = "clear";
#endif
int main()
{


	CCarte ** ppLesCartes = NULL;
	int iNbCartes = 0;
	bool bCreationIndex = true;
	string strReponse = "";
	char cCurrent;
	cout << "TRAVAIL REALISE PAR ALEXIS COTE ET MEHDI LARIBI\n\n";
	cout << "Appuyer sur <Entree> ...\n";
	while (cin.get() != '\n');
	system(EFFACER_ECRAN);
	if (VerifierIndexExiste())
	{
		cout << "Le fichier d'index pour les noms des cartes existe deja.\n";
		cout << "Voulez vous le recreer ? ('o' pour oui)\n";
		cCurrent = cin.get();
		while (cCurrent != '\n')
		{
			strReponse += cCurrent;
			cCurrent = cin.get();
		}

		bCreationIndex = strReponse == "o";
		system(EFFACER_ECRAN);
	}
	if(bCreationIndex)
	{
		cout << "CREATION DU FICHIER INDEX POUR LE NOM DE LA CARTE\n";
		cout << "=================================================\n";
		cout << "Generation en cours...\n\n";
		int iNbCartesTotal = GetNombreCartes();
		CreerIndex();
		cout << "FICHIER INDEX \"" << strNomFichierIndex <<
			"\" CREE AVEC SUCCES POUR LES "<<iNbCartesTotal
			<<" CARTES.\n\n";
		
	}
	cout << "Appuyer sur <Entree> ...\n";
	while (cin.get() != '\n');
	system(EFFACER_ECRAN);
	do
	{
		cout << "RECHERCHE DE CARTES\n";
		cout << "===================\n";

		cout << "Entrez le nom complet d'une carte (peu importe la casse) [\""
			<< "exit\" ==> terminer] :\n ";

		strReponse = "";
		while (cCurrent != '\n')
		{
			strReponse += cCurrent;
			cCurrent = cin.get();
		}

		if (strReponse != "exit")
		{
			ppLesCartes = Rechercher(strReponse, &iNbCartes);

			if (ppLesCartes == NULL)
			{
				cout << "\nAucune carte correspondant au nom \""
					<<strReponse<<"\" :\n\n" ;
			}
			else
			{
				cout << "\nVoici les " << iNbCartes << " cartes correspondant"
					<< " au nom \"" << strReponse << "\" : \n\n";

				for (int i = 0; i < iNbCartes; i++)
				{
					cout << "CARTE #" << i << ":\n";
					cout <<"==========\n";
					cout << "Id = " << ppLesCartes[i]->GetId() << "\n";
					cout << "Name = " << ppLesCartes[i]->GetNom() << "\n";
					cout << "Cost = " << ppLesCartes[i]->GetCost() << "\n";
					cout << "Type = " << ppLesCartes[i]->GetType() << "\n";
					cout << "Power = " << ppLesCartes[i]->GetPower() << "\n";
					cout << "Toughness = " << ppLesCartes[i]->GetToughness()
						<< "\n";
					cout << "Set = " << ppLesCartes[i]->GetSet() << "\n";
					cout << "Rarity = " << ppLesCartes[i]->GetRarity() << "\n";
					cout << "Oracle = " << ppLesCartes[i]->GetOracle() 
						<< "\n\n";
					delete ppLesCartes[i];
				}
				delete[] ppLesCartes;
				ppLesCartes = NULL;
			}
		}

		cout << "Appuyer sur <Entree> ...\n";
		while (cin.get() != '\n');
		system(EFFACER_ECRAN);

	} while (strReponse != "exit");
	return 0;
}