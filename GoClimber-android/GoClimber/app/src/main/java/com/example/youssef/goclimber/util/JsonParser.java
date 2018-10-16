package com.example.youssef.goclimber.Util;


import com.example.youssef.goclimber.data.Classes.Couleur;
import com.example.youssef.goclimber.data.Classes.Gym;
import com.example.youssef.goclimber.data.Classes.Parcours;
import com.example.youssef.goclimber.data.Classes.Utilisateur;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

public class jsonParser {

    //***********************************************Parcours*********************************************************************
    public static final String PARC_ID = "idParcours";
    public static final String PARC_NOM = "nomParcours";
    public static final String PARC_TYPE = "typeVoie";
    public static final String PARC_DIFFICULTE = "difficulte";
    public static final String PARC_COULEUR = "couleur";
    public static final String PARC_DATE = "dateOuverture";
    public static final String PARC_IDUSAGER = "idUsager";
    public static final String PARC_IDGYM = "idGym";
    public static final String PARC_ESTARCHIVE = "estArchive";

    //Permet de désirialiser une expression JSON représentant un tableau de parcours
    //et de produire une liste de personnes

    public static ArrayList<Parcours> deserialiserJsonListeParcours(String parcoursJson) throws JSONException {

        try {
            ArrayList<Parcours> listeParcours = new ArrayList<Parcours>();
            // Désérialisation de l'expression JSON.
            JSONArray array = new JSONArray(parcoursJson);
            String strDate = "";
            DateFormat sdf = new SimpleDateFormat("dd-MM-yyyy'T'HH:mm:ss");
            Calendar dateRetour = Calendar.getInstance();
            int couleurIndice = 0;
            //Ajout des parcours à la liste un à la fois
            for (int i = 0; i < array.length(); i++) {
                JSONObject parcJson = array.getJSONObject(i);
                strDate = parcJson.getString(PARC_DATE);
                dateRetour.setTime(sdf.parse(strDate.toString()));
                couleurIndice = Integer.parseInt(parcJson.getString(PARC_COULEUR));
                Parcours parc = new Parcours(parcJson.getLong(PARC_ID), parcJson.getString(PARC_NOM), parcJson.getString(PARC_TYPE), parcJson.getString(PARC_DIFFICULTE),
                        Couleur.values()[couleurIndice], dateRetour.getTime(), parcJson.getLong(PARC_IDUSAGER), parcJson.getLong(PARC_IDGYM), parcJson.getBoolean(PARC_ESTARCHIVE));

                listeParcours.add(parc);
            }

            return listeParcours;
        } catch (ParseException pe) {
            throw new IllegalArgumentException("Le format de date n'est pas acceptable");
        }
    }


    //Permet de sérialiser en JSON un objet Parcours
    public static JSONObject serialiserJsonParcours(Parcours p) throws JSONException {
        JSONObject jsonObj = new JSONObject();
        SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy");
        Date getDate = p.getM_dateOuverture();
        String reportDate = sdf.format(getDate);
        if (p.getM_nomParcours() != null && !p.getM_nomParcours().isEmpty()) {
            jsonObj.put(PARC_NOM, p.getM_nomParcours());
        }
        jsonObj.put(PARC_TYPE, p.getM_typeVoie());
        jsonObj.put(PARC_DIFFICULTE, p.getM_difficulte());
        jsonObj.put(PARC_COULEUR, String.valueOf(p.getM_couleurPrise().ordinal()));
        jsonObj.put(PARC_DATE, reportDate);
        jsonObj.put(PARC_IDUSAGER, p.getM_usagerOuv());
        jsonObj.put(PARC_IDGYM, p.getM_idGym());
        jsonObj.put(PARC_ESTARCHIVE, p.getM_estArchive());

        return jsonObj;
    }
    //***************************************************************************Fin Parcours********************************************************************************

    public static final String GYM_ID = "idGym";
    public static final String GYM_NOM = "nom";
    public static final String GYM_ADRESSE = "adresse";
    public static final String GYM_CODEPOSTAL = "codePostal";

    // Permet de désérialiser une expression JSON représentant un tableau de gym
    // et de produire une liste de gym.
    public static ArrayList<Gym> deserialiserJsonListeGym(String gymJson) throws JSONException {
        ArrayList<Gym> listeGym = new ArrayList<Gym>();
        // Désérialisation de l'expression JSON.
        JSONArray array = new JSONArray(gymJson);

        // Aout des personnes à la liste une à la fois.
        for (int i = 0; i < array.length(); i++) {
            JSONObject gymJsonOb = array.getJSONObject(i);
            Gym g = new Gym(gymJsonOb.getLong(GYM_ID), gymJsonOb.getString(GYM_NOM), gymJsonOb.getString(GYM_ADRESSE), gymJsonOb.getString(GYM_CODEPOSTAL));
            listeGym.add(g);
        }

        return listeGym;
    }

    // Permet de sérialiser en JSON un objet Gym.
    public static JSONObject serialiserJsonGym(Gym g) throws JSONException {
        JSONObject jsonObj = new JSONObject();

        jsonObj.put(GYM_NOM, g.getM_nomGym());
        jsonObj.put(GYM_ADRESSE, g.getM_adresseGym());
        jsonObj.put(GYM_CODEPOSTAL, g.getM_codePostal());

        return jsonObj;
    }
        public static final String USER_ID = "id";
        public static final String USER_ADRESSE = "adresse";
        public static final String USER_NOM = "nom";
        public static final String USER_TOKEN = "token";
        public static final String USER_COURRIEL = "courriel";
        public static final String USER_NOTEL = "noTel";
        public static final String USER_NOMUSAGER = "nomUsager";
        public static final String USER_PTSVOIE = "ptsVoie";
        public static final String USER_PTSBLOC = "ptsBloc";
        public static final String USER_TYPEUTIL = "typeUtil";
        public static final String USER_PRENOM = "prenom";
        public static final String USER_MDP = "mdp";


        public static Utilisateur deserializeJsonUser(String usagerJson) throws JSONException {
            JSONObject userJson = new JSONObject(usagerJson);
            Utilisateur user = new Utilisateur(userJson.getLong(USER_ID),userJson.getString(USER_NOMUSAGER), userJson.getString(USER_TYPEUTIL), userJson.getString(USER_NOM), userJson.getString(USER_PRENOM), userJson.getString(USER_ADRESSE), userJson.getString(USER_COURRIEL), userJson.getString(USER_NOTEL), userJson.getString(USER_TOKEN), userJson.getInt(USER_PTSBLOC),userJson.getInt(USER_PTSVOIE));
            return user;
        }

        public static ArrayList<String> deserializeJsonStats(String statsJson) throws JSONException {
            ArrayList<String> monRetour = new ArrayList<>();
            JSONObject mesStatsJson = new JSONObject(statsJson);
            int apresTravail = mesStatsJson.getInt("nbApresTravail");
            int flash = mesStatsJson.getInt("nbFlash");
            int vue = mesStatsJson.getInt("nbVue");
            monRetour.add(Integer.toString(apresTravail));
            monRetour.add(Integer.toString(flash));
            monRetour.add(Integer.toString(vue));

            return monRetour;
        }

        public static ArrayList<String> deserializeJsonClassementBloc(String classementJson) throws JSONException {
            ArrayList<String> monRetour = new ArrayList<>();
            JSONArray array = new JSONArray(classementJson);

            for(int i=0; i < array.length(); i++) {
                JSONObject itemClassJson = array.getJSONObject(i);
                monRetour.add(itemClassJson.getString("nomUsager")  + " - " + Integer.toString(itemClassJson.getInt("ptsBloc")) + " Points");
            }
            return monRetour;
        }

        public static ArrayList<String> deserializeJsonClassementVoie(String classementJson) throws JSONException {
            ArrayList<String> monRetour = new ArrayList<>();
            JSONArray array = new JSONArray(classementJson);

            for(int i=0; i < array.length(); i++) {
                JSONObject itemClassJson = array.getJSONObject(i);
                monRetour.add(itemClassJson.getString("nomUsager") + " - " + Integer.toString(itemClassJson.getInt("ptsVoie")) + " Points");
            }
            return monRetour;
        }


        public static JSONObject serialJsonLogin(String compte, String mdp) throws JSONException {
            JSONObject jsonObj = new JSONObject();
            jsonObj.put(USER_NOMUSAGER, compte);
            jsonObj.put(USER_MDP, mdp);
            return jsonObj;
        }

        public static JSONObject serialJsonModifUser(String courriel, String adresse, String noTel, String mdp) throws JSONException {
            JSONObject jsonObj = new JSONObject();
            jsonObj.put(USER_COURRIEL, courriel);
            jsonObj.put(USER_ADRESSE, adresse);
            jsonObj.put(USER_NOTEL, noTel);
            jsonObj.put(USER_MDP, mdp);
            return jsonObj;
        }

        public static JSONObject serialJsonUtilisteur(Utilisateur user) throws JSONException {
            JSONObject jsonObj = new JSONObject();
            jsonObj.put(USER_NOMUSAGER, user.getM_nomUtilisateur());
            jsonObj.put(USER_PRENOM, user.getM_prenom());
            jsonObj.put(USER_NOM, user.getM_nom());
            jsonObj.put(USER_COURRIEL, user.getM_courriel());
            jsonObj.put(USER_TYPEUTIL, user.getM_typeUtil());
            jsonObj.put(USER_ADRESSE, user.getM_adresse());
            jsonObj.put(USER_NOTEL, user.getM_noTel());
            jsonObj.put(USER_MDP, user.getM_mdp());
            jsonObj.put(USER_PTSBLOC, user.getM_ptsBloc());
            jsonObj.put(USER_PTSVOIE, user.getM_ptsVoie());
            return jsonObj;
        }
    }
