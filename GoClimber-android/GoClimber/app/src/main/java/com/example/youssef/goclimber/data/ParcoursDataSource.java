package com.example.youssef.goclimber.data;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import java.lang.reflect.Array;
import java.sql.Date;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.List;

import com.example.youssef.goclimber.data.Classes.Couleur;
import com.example.youssef.goclimber.data.Classes.Difficulte;
import com.example.youssef.goclimber.data.Classes.Parcours;


/**
 * Classe gestion des requetes sqlite de TblParcours
 */
public class ParcoursDataSource {


   /* private static final String DB_NAME ="dbClimber.sqlite";
    // Constantes pour le nom de la table et la version de la BD.
    private final static int DB_VERSION = 11;
    private final static String TABLE_NAME = "TblParcours";


    // Constantes pour le noms des champs dans la BD.
    private static final String COL_IDPARCOURS = "idParcours";
    private static final String COL_NOMPARCOURS= "nomParcours";
    private static final String COL_TYPEVOIE ="typevoie";
    private static final String COL_DIFFICULTE="difficulte";
    private static final String COL_COULEURPRISE = "couleurPrise";
    private static final String COL_DATEOUVERTURE = "dateOuverture";
    private static final String COL_USAGEROUVERTURE="idUsagerOuverture";
    private static final String COL_CRITIQUE= "idCritique";
    private static final String COL_ESTARCHIVE ="archive";


    private DbHelper m_Helper;
    private SQLiteDatabase m_Db;



    public ParcoursDataSource(Context context){ m_Helper = new DbHelper(context, DB_NAME, DB_VERSION); }

    *//**
     * Ouverture de la connexion à la BD.
     *//*
    public void open() { m_Db = this.m_Helper.getWritableDatabase(); }


    *//**
     * Fermeture de la connexion à la BD.
     *//*
    public void close() {
        m_Db.close();
    }

    *//**
     * Insertion d'un objet Parcours dans la bd
     *//*
    public int insert(Parcours parcours){
        ContentValues ligne = EnregistrementParcours(parcours);
        int newId = (int) m_Db.insert(TABLE_NAME, null, ligne);
        parcours.setM_idParcours(newId);
        return newId;
    }

    *//**
     * Conversion d'un objet Parcours en ContentValues.
     *//*
    public static ContentValues EnregistrementParcours(Parcours parcours){
        ContentValues row = new ContentValues();

        row.put(COL_NOMPARCOURS, parcours.getM_nomParcours());
        row.put(COL_DIFFICULTE, parcours.getM_difficulte());
        row.put(COL_TYPEVOIE, parcours.getM_typeVoie());
        row.put(COL_COULEURPRISE, parcours.getM_couleurPrise().ordinal());
        row.put(COL_DATEOUVERTURE, parcours.getM_dateOuverture().toString());
        row.put(COL_USAGEROUVERTURE, parcours.getM_usagerOuv());
        row.put(COL_CRITIQUE, parcours.getM_critique());
        int estArchive = 0;
        if (parcours.getM_estArchive()) {
            estArchive = 1;
        }else {
            estArchive = 0;
        }
        row.put(COL_ESTARCHIVE, parcours.getM_estArchive());

        return row;
    }

    *//**
     * Mise à jour d'un objet parcours dans la BD.
     *//*
    public void update(Parcours parcours) {
        ContentValues row = EnregistrementParcours(parcours);
        String[] args = new String[]{String.valueOf(parcours.getM_idParcours())};
        m_Db.update(TABLE_NAME, row, COL_IDPARCOURS + "=?", args);
    }


    *//**
     * Destruction d'un objet parcours dans la BD.
     *//*
    public void delete(int id) {
        m_Db.delete(TABLE_NAME, COL_IDPARCOURS + "=" + id, null);
    }

    *//**
     * Permet d'obtenir un objet Parcours dans la BD.
     *//*
    public Parcours getParcours(int id) {
        Parcours p = null;
        String[] args = new String[]{String.valueOf(id)};
        Cursor c = m_Db.query(
                TABLE_NAME, null, COL_IDPARCOURS + "=?",args, null, null, null);
        c.moveToFirst();
        if (!c.isAfterLast()) {
            p = lireLigneParcours(c);
        }
        return p;
    }

    *//**
     * Permet d'obtenir tous les objets Parcours dans la BD.
     *//*
    public ArrayList<Parcours> getAllParcours() {
        ArrayList<Parcours> list = new ArrayList<Parcours>();
        Cursor c = m_Db.query(
                TABLE_NAME, null, null, null, null, null, null);
        c.moveToFirst();
        while (!c.isAfterLast()) {
            Parcours p = lireLigneParcours(c);
            list.add(p);
            c.moveToNext();
        }
        return list;
    }

    *//*
    Extraire les parcours archivés
     *//*
    public ArrayList<Parcours> getParcoursArchive() {
        ArrayList<Parcours> lstArchive = new ArrayList<Parcours>();
        String[] args = new String[]{String.valueOf(1)};
        Cursor c = m_Db.query(
                TABLE_NAME, null, COL_ESTARCHIVE + "=?",args, null, null, null);
        c.moveToFirst();
        while (!c.isAfterLast())
        {
            Parcours temp = lireLigneParcours(c);
            lstArchive.add(temp);
            c.moveToNext();
        }
        return lstArchive;
    }

    *//*
     Extraire les voies des parcours
      *//*

    public ArrayList<Parcours> getAllVoies(){
        ArrayList<Parcours> lstVoie = new ArrayList<Parcours>();
            String[] args = new String[]{String.valueOf("Voie")};
            Cursor c = m_Db.query(
                    TABLE_NAME, null, COL_TYPEVOIE + "=?",args, null, null, null);
            c.moveToFirst();
            while (!c.isAfterLast())
            {
                Parcours temp = lireLigneParcours(c);
                lstVoie.add(temp);
                c.moveToNext();
            }
            return lstVoie;
        }

    *//*
    Extraire les blocs des parcours
     *//*

    public ArrayList<Parcours> getAllBlocs(){
        ArrayList<Parcours> lstBlocs = new ArrayList<Parcours>();
        String[] args = new String[]{String.valueOf("Bloc")};
        Cursor c = m_Db.query(
                TABLE_NAME, null, COL_TYPEVOIE + "=?",args, null, null, null);
        c.moveToFirst();
        while (!c.isAfterLast())
        {
            Parcours temp = lireLigneParcours(c);
            lstBlocs.add(temp);
            c.moveToNext();
        }
        return lstBlocs;
    }

    public ArrayList<Parcours> getAllByUser(int id) {
        ArrayList<Parcours> lstBlocs = new ArrayList<Parcours>();
        String[] args = new String[]{String.valueOf(id)};
        Cursor c = m_Db.query(
                TABLE_NAME, null, COL_USAGEROUVERTURE + "=?",args, null, null, null);
        c.moveToFirst();
        while (!c.isAfterLast())
        {
            Parcours temp = lireLigneParcours(c);
            lstBlocs.add(temp);
            c.moveToNext();
        }
        return lstBlocs;
    }


    *//**
     * Conversion d'un ligne de la BD en objet Parcours.
     *//*
    private static Parcours lireLigneParcours(Cursor cursor) {
        Parcours p = new Parcours();
        p.setM_idParcours(cursor.getInt(cursor.getColumnIndex(COL_IDPARCOURS)));
        p.setM_nomParcours(cursor.getString(cursor.getColumnIndex(COL_NOMPARCOURS)));
        p.setM_typeVoie(cursor.getString(2));
        p.setM_difficulte(cursor.getString(cursor.getColumnIndex(COL_DIFFICULTE)));

        int indiceCouleur = cursor.getInt(cursor.getColumnIndex(COL_COULEURPRISE));
        p.setM_couleurPrise(Couleur.values()[indiceCouleur]);

        Date date = new Date(cursor.getLong(cursor.getColumnIndex(COL_DATEOUVERTURE)));
        Calendar c = new GregorianCalendar();
        c.setTime(date);
        p.setM_dateOuverture(c);

        p.setM_usagerOuv(cursor.getInt(cursor.getColumnIndex(COL_USAGEROUVERTURE)));
        p.setM_critique(cursor.getInt(cursor.getColumnIndex(COL_CRITIQUE)));
        int archive = cursor.getInt(cursor.getColumnIndex(COL_ESTARCHIVE));
        if( archive == 1){
            p.setM_estArchive(true);
        }
        else {
            p.setM_estArchive(false);
        }


        return p;
    }*/
}
