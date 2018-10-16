package com.example.youssef.goclimber.data.Classes;

/**
 * Classe représentant un gym
 */
public class Gym {


    public static final int ID_NONDEF = -1;

    //Donnée membre de la classe
    private long m_idGym;
    private String m_nomGym;
    private String m_adresseGym;
    private String m_codePostal;


    //Constructeur par défaut

    public Gym() { this(ID_NONDEF, "", "", "");}


    //Constructeur d'initialisation
    public Gym(long p_idGym, String p_nomGym, String p_adresseGym, String p_codePostal) {
        this.setM_idGym(p_idGym);
        this.setM_nomGym(p_nomGym);
        this.setM_adresseGym(p_adresseGym);
        this.setM_codePostal(p_codePostal);
    }


    //Getter et setter de la classe

    public String getM_codePostal() {
        return m_codePostal;
    }

    public void setM_codePostal(String m_codePostal) {
        this.m_codePostal = m_codePostal;
    }

    public String getM_adresseGym() {
        return m_adresseGym;
    }

    public void setM_adresseGym(String m_adresseGym) {
        this.m_adresseGym = m_adresseGym;
    }

    public String getM_nomGym() {
        return m_nomGym;
    }

    public void setM_nomGym(String m_nomGym) {
        this.m_nomGym = m_nomGym;
    }

    public long getM_idGym() {
        return m_idGym;
    }

    public void setM_idGym(long m_idGym) {
        this.m_idGym = m_idGym;
    }

    @Override
    public String toString() {
        return m_nomGym;
    }
}
