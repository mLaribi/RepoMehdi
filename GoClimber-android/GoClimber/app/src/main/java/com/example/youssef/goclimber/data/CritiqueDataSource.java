package com.example.youssef.goclimber.data;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.example.youssef.goclimber.data.Classes.Critique;
import com.example.youssef.goclimber.data.Classes.StyleVoie;
import com.example.youssef.goclimber.data.Classes.TypeRéussite;

import java.util.ArrayList;
import java.util.List;

/**
 * Classe de gestion de la table tblCritique
 */
public class CritiqueDataSource {
    //Nom de la base sqlite
    private static final String DB_NAME ="dbClimber.sqlite";

    // Constantes pour le nom de la table et la version de la BD.
    private final static int DB_VERSION = 11;
    private final static String TABLE_NAME = "tblCritique";

    // Constantes pour le noms des champs dans la BD.
    private static final String COL_IDCRITIQUE = "idCritique";
    private static final String COL_IDPARCOURS = "idParcours";
    private static final String COL_IDUTILISATEUR = "idUtilisateur";
    private static final String COL_DIFFSUGGESTION= "diffSuggestion";
    private static final String COL_NBETOILES = "nbEtoiles";
    private static final String COL_STYLEVOIE = "styleVoie";
    private static final String COL_TYPEREUSSITE = "typeReussite";

    private DbHelper m_Helper;
    private SQLiteDatabase m_Db;

    public CritiqueDataSource(Context context) {
    m_Helper = new DbHelper(context, DB_NAME, DB_VERSION);
}


    /**
     * Ouverture de la connexion à la BD.
     */
    public void open() { m_Db = this.m_Helper.getWritableDatabase(); }

    /**
     * Fermeture de la connexion à la BD.
     */
    public void close() {
        m_Db.close();
    }

    /**
     * Insertion d'un objet Critique dans la BD.
     */

    public int insert(Critique critique){
        ContentValues ligne = EnregistrementCritique(critique);
        int newId = (int) m_Db.insert(TABLE_NAME, null, ligne);
        // Conservation de l'identification dans l'objet Critique
        critique.setM_idParcours(newId);
        return newId;
    }

    /**
     * Conversion d'un objet Critique en ContentValues.
     */
    public static ContentValues EnregistrementCritique(Critique critique){
        ContentValues row = new ContentValues();
        row.put(COL_IDPARCOURS, critique.getM_idParcours());
        row.put(COL_IDUTILISATEUR, critique.getM_idUtilisateur());
        row.put(COL_DIFFSUGGESTION, critique.getM_diffSuggestion());
        row.put(COL_NBETOILES, critique.getM_nbEtoile());
       // row.put(COL_STYLEVOIE, critique.getM_styleVoie().name());
        row.put(COL_TYPEREUSSITE, critique.getM_typeReussite().name());

        return row;
    }


    /*
    Mise a jour d'un objet Critique dans la BD
     */

    /*public void update(Critique critique){
        ContentValues row = EnregistrementCritique(critique);
        String[] args = new String[]{String.valueOf(critique.getM_idCritique())};
    m_Db.update(TABLE_NAME, row, COL_IDCRITIQUE + "=?", args);
    }*/


    /*
    Suppression d'un objet Critique dans la BD
     */
    public void delete(int id) {m_Db.delete(TABLE_NAME, COL_IDCRITIQUE + "=" + id, null);}



    /**
     * Permet d'obtenir un objet Critique dans la BD.
     */
    public Critique getCritique(int id) {
        Critique cr = null;
        String[] args = new String[]{String.valueOf(id)};
        Cursor c = m_Db.query(
                TABLE_NAME, null, COL_IDCRITIQUE + "=?",args, null, null, null);
        c.moveToFirst();
        if (!c.isAfterLast()) {
            cr = getCritiqueById(c);
        }
        return cr;
    }

    /**
     * Permet d'obtenir tous les objets Critique dans la BD.
     */
    public ArrayList<Critique> getAllCritiques() {
        ArrayList<Critique> list = new ArrayList<Critique>();
        Cursor c = m_Db.query(
                TABLE_NAME, null, null, null, null, null, null);
        c.moveToFirst();
        while (!c.isAfterLast()) {
            Critique crit = getCritiqueById(c);
            list.add(crit);
            c.moveToNext();
        }
        return list;
    }

    public ArrayList<Critique> getCritiqueByUser(int id) {
        ArrayList<Critique> list = new ArrayList<Critique>();
        String[] args = new String[] {String.valueOf(id)};
        Cursor c = m_Db.query(
                TABLE_NAME, null, COL_IDUTILISATEUR + "=?", args, null, null, null);
        c.moveToFirst();
        while (!c.isAfterLast()) {
            Critique crit = getCritiqueById(c);
            list.add(crit);
            c.moveToNext();
        }
        return list;
    }


    public ArrayList<Critique> getCritiqueByParcours(int id) {
        ArrayList<Critique> list = new ArrayList<Critique>();
        String[] args = new String[] {String.valueOf(id)};
        Cursor c = m_Db.query(
                TABLE_NAME, null, COL_IDPARCOURS + "=?", args, null, null, null);
        c.moveToFirst();
        while (!c.isAfterLast()) {
            Critique crit = getCritiqueById(c);
            list.add(crit);
            c.moveToNext();
        }
        return list;
    }




    /*
        Convertion d'une ligne de la BD en objet Critique
     */

    private static Critique getCritiqueById(Cursor c){
        Critique crit = new Critique();

        crit.setM_idCritique(c.getInt(c.getColumnIndex(COL_IDCRITIQUE)));
        crit.setM_idParcours(c.getInt(c.getColumnIndex(COL_IDPARCOURS)));
        crit.setM_idUtilisateur(c.getInt(c.getColumnIndex(COL_IDUTILISATEUR)));
        crit.setM_diffSuggestion(c.getString(c.getColumnIndex(COL_DIFFSUGGESTION)));
        crit.setM_nbEtoile(c.getFloat(c.getColumnIndex(COL_NBETOILES)));

        crit.setM_styleVoie(StyleVoie.valueOf(c.getString(c.getColumnIndex(COL_STYLEVOIE))));
        crit.setM_typeReussite(TypeRéussite.valueOf(c.getString(c.getColumnIndex(COL_TYPEREUSSITE))));

        return crit;
    }

}
