using System;

namespace Cours_420_216
{
	/// <summary>
	/// Classe utilitaire.
	/// </summary>
	public static class Utilitaire
	{
		/// <summary>
		/// Permet de faire afficher une boîte de dialogue pour sélectionner un fichier image.
		/// Notez bien l'utilisation du mot "out" devant le type du paramètre.
		/// </summary>
		/// <param name="cheminFichier">Chemin complet du fichier image sélectionné ou bien null si l'opération a été annulée.</param>
		/// <returns>true si un fichier image a été sélectionné; false, autrement.</returns>
		public static bool DemanderSelectionnerFichierImage(out String cheminFichier)
		{
			// Création de la boîte de dialogue permettant de sélectionner un fichier image.
			// Vous pouvez utiliser la directive "System.Windows.Forms;" ci-dessus au lieu de mettre le nom complet de la classe "OpenFileDialog".
			System.Windows.Forms.OpenFileDialog dialogueOuvrirFichier = new System.Windows.Forms.OpenFileDialog();
			// Filtre permettant de restreindre la sélection à des fichiers images.
			dialogueOuvrirFichier.Filter = "Images (*.png, *.jpg, *.gif, *.bmp)|*.png;*.jpg;*.gif;*.bmp";
			// Titre de la boîte de dialogue.
			dialogueOuvrirFichier.Title = "Sélectionnez un fichier image";

			// Ouverture de la boîte de dialogue pour la sélection d'un fichier et traitement en fonction de la réponse.
			if (dialogueOuvrirFichier.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				// Chemin complet du fichier image sélectionné.
				cheminFichier = dialogueOuvrirFichier.FileName;
				return true;
			}
			else
			{
				// Il est obligatoire de mettre une valeur dans le paramètre en sortie "cheminFichier" même si non utilisé.
				cheminFichier = null;
				return false;
			}
		}
	}
}
