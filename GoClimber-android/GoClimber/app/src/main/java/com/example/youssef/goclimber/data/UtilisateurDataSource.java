package com.example.youssef.goclimber.data;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.example.youssef.goclimber.data.Classes.Utilisateur;

import java.util.ArrayList;
import java.util.List;

/**
 * Classe pour abstraire toute la gestion de la BD
 */
public class UtilisateurDataSource {


    //nom de la table, de la bd et sa version
    private static final int DB_Version = 11;
    private static final String Table_Name = "tblUtilisateur";
    private static final String DB_NAME ="dbClimber.sqlite";

    //Nom des colonne de table
    private static final String COL_ID = "idUtilisateur";
    private static final String COL_PSEUDO= "pseudo";
    private static final String COL_MDP= "MotDePasse";
    private static final String COL_TYPEUTIl = "typeUtil";
    private static final String COL_NOM = "nom";
    private static final String COL_PRENOM = "prenom";
    private static final String COL_ADRESSE = "adresse";
    private static final String COL_COURRIEL = "courriel";
    private static final String COL_TEL = "telephone";


    private DbHelper m_Helper;
    private SQLiteDatabase m_Db;

    public UtilisateurDataSource(Context context) { m_Helper = new DbHelper(context, DB_NAME, DB_Version); }

    /*
    Ouverture de la connexion de la BD
     */
    public void open() {m_Db = this.m_Helper.getWritableDatabase(); }

    /*
     Fermeture de la base de donnée
     */

    public void close() {m_Db.close();}

    /*
     Insertion de l'objet utilisateur dans la BD
     */
    public int insert(Utilisateur utilAjout) {
        ContentValues ligne = EnregistrementUtil(utilAjout);
        int newId = (int) m_Db.insert(Table_Name, null, ligne);
        utilAjout.setM_idUtilisateur(newId);

        return newId;
    }


    /**
     * Conversion d'un objet utilisateur en ContentValues.
     */
    public static ContentValues EnregistrementUtil(Utilisateur util)
    {
        ContentValues ligne = new ContentValues();
        ligne.put(COL_PSEUDO, util.getM_nomUtilisateur());
        ligne.put(COL_MDP, util.getM_mdp());
        ligne.put(COL_TYPEUTIl, util.getM_typeUtil());
        ligne.put(COL_NOM, util.getM_nom());
        ligne.put(COL_PRENOM, util.getM_prenom());
        ligne.put(COL_ADRESSE, util.getM_adresse());
        ligne.put(COL_COURRIEL, util.getM_courriel());
        ligne.put(COL_TEL, util.getM_noTel());

        return ligne;

    }


    public void update(Utilisateur utilModif)
    {
        ContentValues row = EnregistrementUtil(utilModif);
        String[] args = new String[]{String.valueOf(utilModif.getM_idUtilisateur())};
        m_Db.update(Table_Name, row, COL_ID + "=?", args);
    }

    /*
    Suppression d'un enregistrement dans la BD selon ID
     */
    public void delete(int id)
    {
        m_Db.delete(Table_Name, COL_ID + "=" + id, null);
    }

    /*
    Retourne un objet utilisateur selon son ID
     */

    public Utilisateur getUtilisateur(int id) {

        Utilisateur utilRetour = null;

        String[] args = new String[]{String.valueOf(id)};
        Cursor c = m_Db.query(
                Table_Name, null, COL_ID + "=?", args, null, null, null);
        c.moveToFirst();
        if(!c.isAfterLast()) {
            utilRetour = lireLigne(c);
        }
        return utilRetour;
    }


    /*
     Conversion d'un enregistrement en objet Utilisateur
     */

    public static Utilisateur lireLigne(Cursor c)
    {
        Utilisateur utilTrouve = new Utilisateur();

        utilTrouve.setM_idUtilisateur(c.getInt(c.getColumnIndex(COL_ID)));
        utilTrouve.setM_nomUtilisateur(c.getString(c.getColumnIndex(COL_PSEUDO)));
        utilTrouve.setM_mdp(c.getString(2));
        utilTrouve.setM_typeUtil(c.getString(c.getColumnIndex(COL_TYPEUTIl)));
        utilTrouve.setM_nom(c.getString(c.getColumnIndex(COL_NOM)));
        utilTrouve.setM_prenom(c.getString(c.getColumnIndex(COL_PRENOM)));
        utilTrouve.setM_adresse(c.getString(c.getColumnIndex(COL_ADRESSE)));
    utilTrouve.setM_courriel(c.getString(c.getColumnIndex(COL_COURRIEL)));
        utilTrouve.setM_noTel(c.getString(c.getColumnIndex(COL_TEL)));

        return utilTrouve;
    }


    /*
    Permet d'obtenir tous les objets de la table
     */
    public List<Utilisateur> getListeUtilisateurs(){
        List<Utilisateur> liste = new ArrayList<Utilisateur>();
        Cursor c = m_Db.query(Table_Name, null, null, null,null,null, null);
        c.moveToFirst();
        while(!c.isAfterLast() ) {
            Utilisateur u = lireLigne(c);
            liste.add(u);
            c.moveToNext();
        }
        return liste;
    }
}
