package com.example.youssef.goclimber.data;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import com.example.youssef.goclimber.data.Classes.Gym;

import java.util.ArrayList;
import java.util.List;


/**
 * Classe de gestion des requete de la table tblGym
 */
public class GymDataSource {

    /*//Nom de la base sqlite
    private static final String DB_NAME ="dbClimber.sqlite";
    private static final int DB_VERSION = 11;
    private final static String TABLE_NAME = "tblGym";

    //Constantes pour les noms de colonne de table
    private static final String COL_IDGYM = "idGym";
    private static final String COL_NOMGYM = "nomGym";
    private static final String COL_ADRESSEGYM = "adresseGym";
    private static final String COL_CODEPOSTAL= "codePostal";

    private DbHelper m_Helper;
    private SQLiteDatabase m_Db;

    public GymDataSource(Context context){
        m_Helper = new DbHelper(context, DB_NAME, DB_VERSION);
    }

    *//*
    Ouverture de la BD
     *//*
    public void open() { m_Db = this.m_Helper.getWritableDatabase();}

    *//*
      Fermeture de la BD
     *//*
    public void close() {m_Db.close();}


    *//*
    Get gym by id
     *//*
    public Gym getGym(int id){
        Gym g = null;
        String[] args = new String[]{String.valueOf(id)};
        Cursor c = m_Db.query(
                TABLE_NAME, null, COL_IDGYM + "=?",args, null, null, null);
        c.moveToFirst();
        if (!c.isAfterLast()) {
            g = getGymById(c);
        }
        return g;
    }

    public List<Gym> getAllGym(){
        List<Gym> lstGym = new ArrayList<Gym>();
        Cursor c = m_Db.query(
                TABLE_NAME, null, null, null, null, null , null);
        c.moveToFirst();
        while (!c.isAfterLast()) {
            Gym crit = getGymById(c);
            lstGym.add(crit);
            c.moveToNext();
        }
        return lstGym;
    }

    *//*
    Convertion d'une ligne de la table en Objet Gym
     *//*
    private static Gym getGymById(Cursor c)
    {
    Gym g = new Gym();
        g.setM_idGym(c.getInt(c.getColumnIndex(COL_IDGYM)));
        g.setM_nomGym(c.getString(c.getColumnIndex(COL_NOMGYM)));
        g.setM_adresseGym(c.getString(c.getColumnIndex(COL_ADRESSEGYM)));
        g.setM_codePostal(c.getString(c.getColumnIndex(COL_CODEPOSTAL)));

    return g;
    }*/
}
