package com.example.youssef.goclimber.data;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.example.youssef.goclimber.data.Classes.Difficulte;

import java.util.ArrayList;
import java.util.List;

/**
 * Classe de gestion des requetes de la table Difficulté de Voie
 */
public class DifficulteDataSource {

    private static final String DB_NAME ="dbClimber.sqlite";
    //Constante pour le nom de la table et la version de la bd
    private final static int DB_VERSION = 11;
    private final static String TABLE_NAME = "tblDifficulte";

    //Constantes pour les noms des champs dans la BD
    private static final String COL_DIFF = "difficulte";
    private static final String COL_TYPEPARCOURS = "typeParcours";
    private static final String COL_POINTAGE = "pointage";

    private DbHelper m_Helper;
    private SQLiteDatabase m_Db;

    public DifficulteDataSource(Context context){ m_Helper = new DbHelper(context, DB_NAME, DB_VERSION); }

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
     * Insertion d'un objet Difficulte dans la bd
     */
    public void insert(Difficulte difficulte){
        ContentValues ligne = EnregistrementDiff(difficulte);
        m_Db.insert(TABLE_NAME, null, ligne);
    }


    public static ContentValues EnregistrementDiff(Difficulte difficulte){
        ContentValues row = new ContentValues();

        row.put(COL_DIFF, difficulte.getM_diff());
        row.put(COL_TYPEPARCOURS, difficulte.getM_typeVoie());
        row.put(COL_POINTAGE, difficulte.getM_pointage());

        return row;
    }

    /*
     * Obtient une difficulté selon son ID
     */
    public Difficulte getDiff(String idDiff){
        Difficulte d = null;
        String[] args = new String[]{String.valueOf(idDiff)};
        Cursor c = m_Db.query(TABLE_NAME, null, COL_DIFF + "=?", args, null, null, null);
        c.moveToNext();
        if(!c.isAfterLast())
        {
            d = lireLigneDifficulte(c);
        }
        return d;
    }

    public ArrayList<Difficulte> getDiffBloc()
    {
        ArrayList<Difficulte> lstDiffBloc = new ArrayList<>();
        String[] args = new String[]{String.valueOf("Bloc")};
        Cursor c = m_Db.query(
                TABLE_NAME, null, COL_TYPEPARCOURS + "=?",args, null, null, null);
        c.moveToFirst();
        while(!c.isAfterLast()) {
            Difficulte temp = lireLigneDifficulte(c);
            lstDiffBloc.add(temp);
            c.moveToNext();
        }
        return lstDiffBloc;
    }

    public ArrayList<Difficulte> getDiffVoie()
    {
        ArrayList<Difficulte> lstDiffVoie = new ArrayList<>();
        String[] args = new String[]{String.valueOf("Voie")};
        Cursor c = m_Db.query(
                TABLE_NAME, null, COL_TYPEPARCOURS + "=?",args, null, null, null);
        c.moveToFirst();
        while(!c.isAfterLast()) {
            Difficulte temp = lireLigneDifficulte(c);
            lstDiffVoie.add(temp);
            c.moveToNext();
        }
        return lstDiffVoie;
    }



    /*
     Conversion d'une ligne de la bd en objet Difficulté
     */
    private static  Difficulte lireLigneDifficulte(Cursor cursor){
        Difficulte d = new Difficulte();

        d.setM_diff(cursor.getString(cursor.getColumnIndex(COL_DIFF)));
        d.setM_typeVoie(cursor.getString(cursor.getColumnIndex(COL_TYPEPARCOURS)));
        d.setM_pointage(cursor.getInt(cursor.getColumnIndex(COL_POINTAGE)));

        return d;
    }

}
