//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP3_Youyous_MLaribi
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetailsCommandes
    {
        public int no { get; set; }
        public int noCommande { get; set; }
        public int idSki { get; set; }
        public int qte { get; set; }
    
        public virtual Commandes Commandes { get; set; }
        public virtual Skis Skis { get; set; }
    }
}