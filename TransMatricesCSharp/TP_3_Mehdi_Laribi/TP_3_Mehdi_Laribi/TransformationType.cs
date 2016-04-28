//Programmation objet 2
//Programmeur : Mehdi Laribi
//Date: 2014-05-19 
using System;
using System.ComponentModel;
namespace TP3_Transformations
{
    public enum TransformationType
    {
        [Description("Miroir horizontal")]
        MiroirHorizontal,
        [Description("Miroir vertical")]
        MiroirVertical,
        [Description("Transposition (image carrée)")]
        Transposition,
        [Description("Décalage horizontal vers la droite)")]
        DecalageHorizontal,
        [Description("Décalage en diagonale vers la droite et le bas")]
        DecalageEnDiagonale,
        [Description("En colonnes (dimensions paires)")]
        Colonnes,
        [Description("Photomaton (dimensions paires)")]
        Photomaton,
        [Description("Boulanger (dimensions paires)")]
        Boulanger,
        [Description("Fleur - Bonus 5 points (dimensions paires)")]
        Fleur,
        [Description("Svastika - Bonus 5 points (dimensions paires)")]
        Svastika
    }
}
