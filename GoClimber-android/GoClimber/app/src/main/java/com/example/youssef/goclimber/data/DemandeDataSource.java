package com.example.youssef.goclimber.data;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.example.youssef.goclimber.data.Classes.DemandePartenaire;
import com.example.youssef.goclimber.data.Classes.Parcours;

import java.sql.Date;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.List;

/**
 * Classe de gestion des requete de la table Demande de partenaire
 */
public class DemandeDataSource {



    // Constantes pour le nom de la table et la version de la BD.
    private final static int DB_VERSION = 11;
    private final static String TABLE_NAME = "TblDemandes";
    private static final String DB_NAME ="dbClimber.sqlite";

    //Constantes pour les noms des champs de la BD
    private static final String COL_IDDemande = "idDemande";
    private static final String COL_TYPEPARCOURS = "typeParcours";
    private static final String COL_LIEU = "lieu";
    private static final String COL_DATETIME = "dateHeure";
    private static final String COL_COMMENTAIRE = "commentaire";

    private DbHelper m_dbHelper;
    private SQLiteDatabase m_Db;

    public DemandeDataSource(Context context) {m_dbHelper = new DbHelper(context, DB_NAME, DB_VERSION);}


    /*
    Ouverture de la connexion vers la BD
     */
    public void open() {m_Db = this.m_dbHelper.getWritableDatabase();}

    /*
    Fermeture de la connexion vers la BD
     */
    public void close() {m_Db.close();}

    /*
    Get all demandes de la BD
     */
    public List<DemandePartenaire> getAllDemandes()
    {
        List<DemandePartenaire> listeDem = new ArrayList<DemandePartenaire>();
        Cursor c = m_Db.query( TABLE_NAME, null, null, null, null, null,null);
        c.moveToFirst();
        while(!c.isAfterLast()){
            DemandePartenaire dp = lireLigneDemande(c);
            listeDem.add(dp);
            c.moveToNext();
        }

        return listeDem;
    }

    public ArrayList<DemandePartenaire> getAllDemandesBloc()
    {
        ArrayList<DemandePartenaire> listeDem = new ArrayList<DemandePartenaire>();
        String[] args = new String[]{String.valueOf("Bloc")};
        Cursor c = m_Db.query( TABLE_NAME, null, COL_TYPEPARCOURS + "=?", args, null, null,null);
        c.moveToFirst();
        while(!c.isAfterLast()){
            DemandePartenaire dp = lireLigneDemande(c);
            listeDem.add(dp);
            c.moveToNext();
        }

        return listeDem;
    }

    public ArrayList<DemandePartenaire> getAllDemandesVoie()
    {
        ArrayList<DemandePartenaire> listeDem = new ArrayList<DemandePartenaire>();
        String[] args = new String[]{String.valueOf("Voie")};
        Cursor c = m_Db.query( TABLE_NAME, null, COL_TYPEPARCOURS + "=?", args, null, null,null);
        c.moveToFirst();
        while(!c.isAfterLast()){
            DemandePartenaire dp = lireLigneDemande(c);
            listeDem.add(dp);
            c.moveToNext();
        }

        return listeDem;
    }


    public static ContentValues EnregistrementDemande(DemandePartenaire demande){
        ContentValues row = new ContentValues();

        row.put(COL_IDDemande, demande.getM_idDemande());
        row.put(COL_TYPEPARCOURS, demande.getM_typeParcours());
        row.put(COL_LIEU, demande.getM_adresse());

        SimpleDateFormat formatter=new SimpleDateFormat("DD-MMM-yyyy");
        String current = formatter.format(demande.getM_dateTime().getTime());

        row.put(COL_DATETIME, current);
        row.put(COL_COMMENTAIRE, demande.getM_commentaire());
        return row;
    }

     /*
     Extraire les voies des parcours
      */

    public List<DemandePartenaire> getAllVoie(List<DemandePartenaire> lstDemandes){
        List<DemandePartenaire> lstVoie = new ArrayList<DemandePartenaire>();
        for (DemandePartenaire v : lstDemandes) {
            if(v.getM_typeParcours() == "Voie"){
                lstVoie.add(v);
            }
        }
        return lstVoie;
    }

    /*
    Extraire les blocs des parcours
     */

    public List<DemandePartenaire> getAllBlocs(List<DemandePartenaire> lstParcours){
        List<DemandePartenaire> lstBlocs = new ArrayList<DemandePartenaire>();
        for (DemandePartenaire b : lstParcours) {
            if(b.getM_typeParcours() == "Bloc"){
                lstBlocs.add(b);
            }
        }
        return lstBlocs;
    }


    /*
    Conversion d'une ligne de la BD en Objet DemandePartenaire
     */
    private static DemandePartenaire lireLigneDemande(Cursor cursor){
        DemandePartenaire dp = new DemandePartenaire();

        dp.setM_idDemande(cursor.getInt(cursor.getColumnIndex(COL_IDDemande)));
        dp.setM_typeParcours(cursor.getString(cursor.getColumnIndex(COL_TYPEPARCOURS)));
        dp.setM_adresse(cursor.getString(cursor.getColumnIndex(COL_LIEU)));

        Date date = new Date(cursor.getLong(cursor.getColumnIndex(COL_DATETIME)));
        Calendar c = new GregorianCalendar();
        c.setTime(date);
        dp.setM_dateTime(c);

        dp.setM_commentaire(cursor.getString(cursor.getColumnIndex(COL_COMMENTAIRE)));

        return dp;
    }

}
