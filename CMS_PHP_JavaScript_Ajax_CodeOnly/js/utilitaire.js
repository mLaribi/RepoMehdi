
//Enleve les espaces blanc d'une chaine donnée
function enleverBlancs(chaine)
{
	// La chaîne est vide ou contient un seul espace.
	if ( chaine == ""  || chaine == " "  || chaine == "\t"  || chaine == "\n" )
		return ""
	else
	{
		// Position du premier caractère qui n'est pas un espace vierge
		// ou bien du dernier caractère de la chaîne.
		var posPremierCar = 0
		while (  posPremierCar < (chaine.length-1)  &&  
				 ( chaine.charAt(posPremierCar) == " "
				 ||  chaine.charAt(posPremierCar) == "\t"
				 ||  chaine.charAt(posPremierCar) == "\n" )  )
		{
			posPremierCar++
		}

		// Position du dernier caractère qui n'est pas un espace vierge
		// ou bien du premier caractère de la chaîne.
		var posDernierCar = (chaine.length-1)
		while (  posDernierCar > 0  &&  
				 ( chaine.charAt(posDernierCar) == " "
				 ||  chaine.charAt(posDernierCar) == "\t"
				 ||  chaine.charAt(posDernierCar) == "\n" )  )
		{
			posDernierCar--
		}

		// Est-ce que la chaîne contient seulement des espaces vierges ?
		if ( posPremierCar > posDernierCar)
			return ""
		else
		{
			// Retourne la partie de la chaîne sans les espaces à gauche et à droite.
			return  chaine.substring( posPremierCar, posDernierCar+1 )
		}
	}
}