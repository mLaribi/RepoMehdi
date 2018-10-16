package com.example.youssef.goclimber.data.Classes;

/**
 * Représente les difficultés
 */
public class Difficulte {

    //Donnée membre de la classe difficulté
    private String m_diff;
    private String m_typeVoie;
    private int m_pointage;


    //Constructeur par défaut
    public Difficulte() { this("", "", -1);}

    @Override
    public String toString() {
        return getM_diff();
    }


    //Constructeur d'initialisation
    public Difficulte(String p_diff, String p_typeVoie, int p_pointage) {
        this.setM_diff(p_diff);
        this.setM_typeVoie(p_typeVoie);
        this.setM_pointage(p_pointage);
    }


    //Getter et setter de la classe
    public String getM_diff() {
        return m_diff;
    }

    public void setM_diff(String m_diff) {
        this.m_diff = m_diff;
    }

    public String getM_typeVoie() {
        return m_typeVoie;
    }

    public void setM_typeVoie(String m_typeVoie) {
        this.m_typeVoie = m_typeVoie;
    }

    public int getM_pointage() {
        return m_pointage;
    }

    public void setM_pointage(int m_pointage) {
        this.m_pointage = m_pointage;
    }
}
