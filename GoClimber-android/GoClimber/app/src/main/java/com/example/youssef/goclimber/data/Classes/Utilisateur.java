package com.example.youssef.goclimber.data.Classes;

import java.io.Serializable;

/**
 * Classe représentant un utilisateur
 */
public class Utilisateur implements Serializable {

    /*
     Identifiant non précisé
     */
    public static final int ID_NONDEF = -1;

    /*
     Identifiant de l'utilisateur
     */
    private long m_idUtilisateur;

    /**
     * Nom du compte
     */
    private String m_nomUtilisateur;

    /**
     * Mot de passe de l'usager
     */
    private String m_mdp;

    /**
     * Type Utilisateur
     */
    private String m_typeUtil;

    /**
     * Nom de l'utilisateur
     */
    private String m_nom;

    /**
     *Prenom
     */
    private String m_prenom;

    /**
     *Adresse de l'utilisateur
     */
    private String m_adresse;

    /**
     * Courriel
     */
    private String m_courriel;

    /**
     *Numéro de téléphone
     */
    private String m_noTel;

    /**
     * Token
     */
    private String m_token;

    /**
     * Points bloc
     */
    private int m_ptsBloc;

    /**
     * Points voie
     */
    private int m_ptsVoie;


    /*
     * Constructeur par défaut
     */



    public Utilisateur() {this(ID_NONDEF,"", "", "", "", "", "", "", "",0,0);}


    /*
    Constructeur d'initialisation
     */
    public Utilisateur(long p_idUtil, String p_nomUtilisateur, String p_typeUtil, String p_nom, String p_prenom, String p_adresse, String p_courriel, String p_noTel, String p_token, int p_ptsBloc, int p_ptsVoie) {

        this.setM_idUtilisateur(p_idUtil);
        this.setM_nomUtilisateur(p_nomUtilisateur);
        this.setM_typeUtil(p_typeUtil);
        this.setM_nom(p_nom);
        this.setM_prenom(p_prenom);
        this.setM_adresse(p_adresse);
        this.setM_courriel(p_courriel);
        this.setM_noTel(p_noTel);
        this.setM_token(p_token);
        this.setM_ptsBloc(p_ptsBloc);
        this.setM_ptsVoie(p_ptsVoie);
    }

    public Utilisateur(long p_idUtil, String p_nomUtilisateur, String p_mdp, String p_typeUtil, String p_nom, String p_prenom, String p_adresse, String p_courriel, String p_noTel, String p_token, int p_ptsBloc, int p_ptsVoie) {

        this.setM_idUtilisateur(p_idUtil);
        this.setM_nomUtilisateur(p_nomUtilisateur);
        this.setM_mdp(p_mdp);
        this.setM_typeUtil(p_typeUtil);
        this.setM_nom(p_nom);
        this.setM_prenom(p_prenom);
        this.setM_adresse(p_adresse);
        this.setM_courriel(p_courriel);
        this.setM_noTel(p_noTel);
        this.setM_token(p_token);
        this.setM_ptsBloc(p_ptsBloc);
        this.setM_ptsVoie(p_ptsVoie);
    }

    /*
         * Les get pour chaque donnée membre
         */
    public String getM_nomUtilisateur() {
        return m_nomUtilisateur;
    }

    public long getM_idUtilisateur() {
        return m_idUtilisateur;
    }

    public String getM_mdp() {
        return m_mdp;
    }

    public String getM_typeUtil() {
        return m_typeUtil;
    }

    public String getM_nom() {
        return m_nom;
    }

    public String getM_prenom() {
        return m_prenom;
    }

    public String getM_adresse() {
        return m_adresse;
    }

    public String getM_courriel() {
        return m_courriel;
    }

    public String getM_noTel() {
        return m_noTel;
    }

    public String getM_token() { return m_token;}

    public int getM_ptsBloc() {return m_ptsBloc;}

    public int getM_ptsVoie() {return m_ptsVoie;}

    /*
     * Les accesseurs en ecriture pour chaque donnée membre
     */
    public void setM_nomUtilisateur(String m_nomUsager) {
        this.m_nomUtilisateur = m_nomUsager;
    }

    public void setM_idUtilisateur(long m_idUtilisateur) {
        this.m_idUtilisateur = m_idUtilisateur;
    }
    public void setM_mdp(String m_mdp) {
        this.m_mdp = m_mdp;
    }

    public void setM_typeUtil(String m_typeUtil) {
        this.m_typeUtil = m_typeUtil;
    }

    public void setM_nom(String m_nom) {
        this.m_nom = m_nom;
    }

    public void setM_prenom(String m_prenom) {
        this.m_prenom = m_prenom;
    }

    public void setM_adresse(String m_adresse) {
        this.m_adresse = m_adresse;
    }

    public void setM_courriel(String m_courriel) {
        this.m_courriel = m_courriel;
    }

    public void setM_noTel(String m_noTel) {
        this.m_noTel = m_noTel;
    }

    public void setM_token(String m_token) {this.m_token = m_token;}

    public void setM_ptsBloc(int m_ptsBloc) {this.m_ptsBloc = m_ptsBloc;}

    public void setM_ptsVoie(int m_ptsVoie) {this.m_ptsVoie = m_ptsVoie;}
    /*
     * Compare le nom d'usager (supposé être unique), le mot de passe et le numéro de téléphone.
     */
    @Override
    public boolean equals(Object o) {
        boolean egaux = false;

        if(o instanceof Utilisateur) {

            Utilisateur u = (Utilisateur) o;

            egaux = (this.getM_nomUtilisateur().equals(u.getM_nomUtilisateur()) &&
                    this.getM_idUtilisateur() == u.getM_idUtilisateur() &&
                    this.getM_mdp().equals(u.getM_mdp()));
        }
        return egaux;
    }
}