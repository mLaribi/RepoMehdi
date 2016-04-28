using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Reflection;

namespace Cours_420_216
{
	/// <summary>
	/// Classe utilitaire pour les énumérations.
	/// Fournit des méthodes permettant d'obtenir les descriptions associées aux constantes des énumérations lorsque celles-ci sont disponibles.
	/// NOTE POUR LES ÉTUDIANTS : N'essayez pas de comprendre le code suivant; voir plutôt l'exemple d'utilisation.
	/// </summary>
	public static class UtilEnum
	{
		/// <summary>
		/// Extension permettant d'obtenir la description pour une constante d'une énumération, si disponible.
		/// S'il n'y a pas de description associée à la constante de l'énumération, permet d'obtenir la valeur de celle-ci.
		/// Source : https://msmvps.com/blogs/deborahk/archive/2009/07/10/enum-binding-to-the-description-attribute.aspx
		/// </summary>
		/// <param name="currentEnum"></param>
		/// <returns>Description associée à la constante de l'énumération ou bien la valeur s'il n'y a pas de description.</returns>
		public static string GetDescription(this Enum currentEnum)
		{
			string description = String.Empty;
			DescriptionAttribute da;

			FieldInfo fi = currentEnum.GetType().GetField(currentEnum.ToString());
			da = (DescriptionAttribute) Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
			if (da != null)
				description = da.Description;
			else
				description = currentEnum.ToString();

			return description;
		}

		/// <summary>
		/// Permet d'obtenir toutes les descriptions associées aux constantes d'une énumération, si disponible.
		/// S'il n'y a pas de description associée à une constante de l'énumération, permet d'obtenir la valeur de celle-ci.
		/// </summary>
		/// <returns>Les descriptions associées aux constantes de l'énumération ou bien les valeurs s'il n'y a pas de description.</returns>
		public static List<String> GetAllDescriptions<T>()
		{
			Type enumType = typeof(T);
			List<String> lesDescriptions = new List<String>();
			foreach (Enum valeur in Enum.GetValues(enumType))
			{
				lesDescriptions.Add( valeur.GetDescription() );
			}
			return lesDescriptions;
		}
	}
}
