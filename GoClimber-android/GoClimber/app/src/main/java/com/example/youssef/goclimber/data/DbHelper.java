package com.example.youssef.goclimber.data;

import android.content.ContentValues;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.example.youssef.goclimber.data.Classes.Couleur;
import com.example.youssef.goclimber.data.Classes.Critique;
import com.example.youssef.goclimber.data.Classes.DemandePartenaire;
import com.example.youssef.goclimber.data.Classes.Difficulte;
import com.example.youssef.goclimber.data.Classes.Parcours;
import com.example.youssef.goclimber.data.Classes.StyleVoie;
import com.example.youssef.goclimber.data.Classes.TypeRéussite;
import com.example.youssef.goclimber.data.Classes.Utilisateur;

import java.sql.Date;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

// Classe de DbHelper Source
// ==================================

/**
 * Classe pour gérer l’ouverture, la création et la mise à jour d’un fichier de BD.
 */
public class DbHelper extends SQLiteOpenHelper{
    //Date quelquonc
    private Calendar calendar = Calendar.getInstance();

    //Version et nom de la base de donnée
    private static final int DB_VERSION = 11;
    private static final String DB_NAME ="dbClimber.sqlite";

    //Table tblCritique
    private final static String TABLE_CRITIQUE = "tblCritique";
    //Requete création de la table critique
    private final static String CREATE_CRITIQUE = "create table " + TABLE_CRITIQUE
            + "(idCritique integer primary key autoincrement, "
            + "idParcours integer, "
            + "idUtilisateur integer, "
            + "nbEtoiles text, "
            + "styleVoie real, typeReussite text, diffSuggestion text, "
            + "foreign key (idParcours) references _idParcours, "
            + "foreign key (idUtilisateur) references _idUtilisateur)";
    //Data source des critique
    private CritiqueDataSource m_CritiqueData;

    //Liste des enregistrement des critiques
    Critique[] lstEnrCritiques = new Critique[]{
            new Critique(1,6,1,3,StyleVoie.Moulinette, TypeRéussite.flash, "5.12B"),
            new Critique(2,7,1,4,StyleVoie.PremierDeCordée, TypeRéussite.apresTravail, "5.12c"),
            new Critique(3,8,1,4,StyleVoie.Moulinette, TypeRéussite.aVue, "5.12d"),
            new Critique(4,9,2,1,StyleVoie.Moulinette, TypeRéussite.aVue, "5.14a"),
            new Critique(5,10,1,2.5f,StyleVoie.Moulinette, TypeRéussite.flash, "5.13a"),
            new Critique(6,1,1,3,StyleVoie.Aucun, TypeRéussite.flash, "V1"),
            new Critique(7,2,1,3.5f,StyleVoie.Aucun, TypeRéussite.apresTravail, "V2"),
            new Critique(8,3,2,4,StyleVoie.Aucun, TypeRéussite.aVue, "V3"),
            new Critique(9,4,1,5,StyleVoie.Aucun, TypeRéussite.aVue, "V4"),

    };


    //Table demande de Sortie
    private final static String TABLE_DEMANDEPART = "tblDemandes";
    //Requete création de la table critique
    private final static String CREATE_DEMANDEPART = "create table " + TABLE_DEMANDEPART
            + "(idDemande integer primary key autoincrement, "
            + " typeParcours text, lieu text, dateHeure text, commentaire text)";
    //Data source des Demandes
    private DemandeDataSource m_demandeData;

    //Liste des enregistrements des demandes
    DemandePartenaire[] lstEnrPartenaires = new DemandePartenaire[]{

            new DemandePartenaire(1, "Bloc", "950 Avenue St Jean Baptiste #150, Ville de Québec, QC G2E 5E9", calendar, "Pluvieux"),
            new DemandePartenaire(2, "Voie", "950 Avenue St Jean Baptiste #150, Ville de Québec, QC G2E 5E9", calendar, "Très nice"),
            new DemandePartenaire(3, "Voie", "950 Avenue St Jean Baptiste #150, Ville de Québec, QC G2E 5E9", calendar, "Much wow")
    };

    //Table difficulté
    private final static String TABLE_DIFFICULTE = "tblDifficulte";
    //Requete création de la table difficutlé
    private final static String CREATE_DIFFICULTE = "create table " + TABLE_DIFFICULTE
                        + " (difficulte text primary key," +
                        "typeParcours text, pointage integer)";
    //Data source des difficultés
    private DifficulteDataSource m_DiffData;

    //Liste des différentes difficultés

    Difficulte[] lstEnrDiff = new Difficulte[] {
            new Difficulte("5.10a","Voie", 50),
            new Difficulte("5.10b","Voie", 50),
            new Difficulte("5.10c","Voie", 50),
            new Difficulte("5.10d","Voie", 50),
            new Difficulte("5.11a","Voie", 50),
            new Difficulte("5.11b","Voie", 50),
            new Difficulte("5.11c","Voie", 50),
            new Difficulte("5.11d","Voie", 50),
            new Difficulte("5.12a","Voie", 50),
            new Difficulte("5.12b","Voie", 50),
            new Difficulte("5.12c","Voie", 50),
            new Difficulte("5.12d","Voie", 50),
            new Difficulte("5.13a","Voie", 50),
            new Difficulte("5.13b","Voie", 50),
            new Difficulte("5.13c","Voie", 50),
            new Difficulte("5.13d","Voie", 50),
            new Difficulte("5.14a","Voie", 50),
            new Difficulte("5.14b","Voie", 50),
            new Difficulte("5.14c","Voie", 50),
            new Difficulte("5.14d","Voie", 50),
            new Difficulte("5.15a","Voie", 50),
            new Difficulte("5.15b","Voie", 50),
            new Difficulte("V0","Bloc", 50),
            new Difficulte("V1","Bloc", 50),
            new Difficulte("V2","Bloc", 50),
            new Difficulte("V3","Bloc", 50),
            new Difficulte("V4","Bloc", 50),
            new Difficulte("V5","Bloc", 50),
            new Difficulte("V6","Bloc", 50),
            new Difficulte("V7","Bloc", 50),
            new Difficulte("V8","Bloc", 50),
            new Difficulte("V9","Bloc", 50),
            new Difficulte("V10","Bloc", 50),
            new Difficulte("V11","Bloc", 50),
            new Difficulte("V12","Bloc", 50),
            new Difficulte("V13","Bloc", 50),
            new Difficulte("V14","Bloc", 50),
            new Difficulte("V15","Bloc", 50)
    };


    //Table Parcours
    private final static String TABLE_PARCOURS = "tblParcours";
    //Requete création de la table Parcours
    private final static String CREATE_PARCOURS = "create table " + TABLE_PARCOURS
            + "(idParcours integer primary key autoincrement, "
            + " nomParcours text, typevoie text, difficulte text, couleurPrise integer, " +
            "dateOuverture text, idUsagerOuverture integer, idCritique integer, archive integer default 0, " +
            "foreign key (idUsagerOuverture) references _idUtilisateur, " +
            "foreign key (difficulte) references _idDifficulte, " +
            "foreign key (idCritique) references _idCritique)";
    //Data source des Parcours
    private ParcoursDataSource m_ParcoursData;



    /*//Liste des enregistrements des parcours
    Parcours[] lstEnrParcours = new Parcours[] {
            //Blocs
            new Parcours(1, "Parcours impossible", "Bloc", "V1", Couleur.Mauve, calendar, 1,false),
            new Parcours(2, "Parcours impossible 2 ", "Bloc", "V2", Couleur.Blanc, calendar, 2,false),
            new Parcours(3, "Parcours impossible 3 ", "Bloc", "V3", Couleur.Bleu, calendar, 1,false),
            new Parcours(4, "Parcours possible", "Bloc", "V8", Couleur.Vert, calendar, 2,false),
            new Parcours(5, "Parcours possible 2", "Bloc", "V5", Couleur.Jaune, calendar, 3,false),

            //Voies
            new Parcours(6, " ", "Voie", "5.8", Couleur.Mauve, calendar, 1, false),
            new Parcours(7, " ", "Voie", "5.12c", Couleur.Bleu, calendar, 2,false),
            new Parcours(8, " ", "Voie", "5.12b", Couleur.Vert, calendar, 1,false),
            new Parcours(9, " ", "Voie", "5.13c", Couleur.Jaune, calendar, 2, false),
            new Parcours(10, " ", "Voie", "5.12d", Couleur.Jaune, calendar, 3,false),


    };
*/

    //Table Utilisateur
    private final static String TABLE_UTILISATEUR = "tblUtilisateur";
    //Requete création de la table Utilisateur
    private final static String CREATE_UTILISATEUR = "create table " + TABLE_UTILISATEUR
            + "(idUtilisateur integer primary key autoincrement, "
            + "pseudo text, motDePasse text, typeUtil text, "
            + "nom text, prenom text, adresse text, courriel text, telephone text)";
    //Data source des Utilisateurs
    private UtilisateurDataSource m_utilisateurData;

    //Liste d'enregistrements des utilisateurs
    /*Utilisateur[] lstEnrUtilisateurs= new Utilisateur[]{
        new Utilisateur(1, "youYouDiamond", "qc123", "Ouvreur", "Ouyous", "Youssef", "3026 Rue Rhéaume G1W1W1", "youyou@gmail.com", "581-989-2406"),
        new Utilisateur(2, "wolfiprinx22", "SAsaS56", "Grimpeur", "Alexis", "Cote", "3081 Rue Ormiere G1W1W5", "aCote@gmail.com", "581-889-8806"),
        new Utilisateur(3, "avenged", "algerie123", "Ouvreur", "Bran", "Poulard", "882 Rue Forest G5W5A4", "branPole@gmail.com", "581-999-9111"),
        new Utilisateur(4, "comptonStreet", "garneau123", "Grimpeur", "Jean-Samuel", "Dumond", "402 Rue Lechasseur G1W1W1", "jsDumont@gmail.com", "581-989-5848"),
        new Utilisateur(5, "mop850", "marco456", "Ouvreur", "Mehdi", "Laribi", "802 Rue Richard-Turner G1W1W1", "mlaribi@gmail.com", "581-882-2871")
    };*/

    //Table Gym
   /* private final static String TABLE_GYM = "tblGym";
    private final static String CREATE_GYM = "create table " + TABLE_GYM
            + "(idGym integer primary key autoincrement, " +
            "nomGym text, adresseGym text, codePostal text)";
    //Data source des gyms
    private GymDataSource m_gymData;*/



    public DbHelper(Context context, String name, int version) {
        super(context, name, null, version);


    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(CREATE_CRITIQUE);
        db.execSQL(CREATE_DEMANDEPART);
        db.execSQL(CREATE_DIFFICULTE);
        db.execSQL(CREATE_PARCOURS);
        db.execSQL(CREATE_UTILISATEUR);
        //db.execSQL(CREATE_GYM);
        //Ajout des enregistrements des Critiques
        for(Critique cri: lstEnrCritiques){
           ContentValues temp =  CritiqueDataSource.EnregistrementCritique(cri);
            db.insert(TABLE_CRITIQUE, null, temp);
        }
        //Ajout des enregistrements des Parcours
       /* for (Parcours p: lstEnrParcours){
            ContentValues tPar = ParcoursDataSource.EnregistrementParcours(p);
            db.insert(TABLE_PARCOURS, null, tPar);
        }*/
        //Ajout des enregistrements des Difficulté
        for(Difficulte diff: lstEnrDiff){
            ContentValues tDiff = DifficulteDataSource.EnregistrementDiff(diff);
            db.insert(TABLE_DIFFICULTE, null, tDiff);
        }
        //Ajout des enregistrements des utilisateurs
     /*   for(Utilisateur util : lstEnrUtilisateurs){
            ContentValues tUtil = UtilisateurDataSource.EnregistrementUtil(util);
            db.insert(TABLE_UTILISATEUR, null, tUtil);
        }*/

        //Ajout des enregistrements des partenaires
        for(DemandePartenaire dem: lstEnrPartenaires){
            ContentValues tDem = DemandeDataSource.EnregistrementDemande(dem);
            db.insert(TABLE_DEMANDEPART, null, tDem);
        }
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

        //Durant la mise à jour supprime les anciennes tables
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_CRITIQUE);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_DEMANDEPART);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_DIFFICULTE);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_PARCOURS);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_UTILISATEUR);
        //db.execSQL("DROP TABLE IF EXISTS " + TABLE_GYM);

        //Crée de nouvelles tables
        onCreate(db);

    }
}
