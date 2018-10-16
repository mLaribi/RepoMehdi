package com.example.youssef.goclimber.data.Classes;

import java.io.Serializable;
import java.util.Calendar;
import java.util.Date;

/**
 * Classe Parcours
 */
public class Parcours implements Serializable{

    /*
     * Date actuelle
     */
    public static final  Date Date_Actuelle = null;

    /**
     * Identifiant inconnu.
     */
    public static final int ID_NON_DEFINI = -1;

    /*
     * ID de la voie
     */
    private long m_idParcours;
    /*
     * Nom de la voie
     */

    private String m_nomParcours;

    /*
     * Type de la voie
     */
    private String m_typeVoie;

    /*
     * Difficulté
     */
    private String m_difficulte;

    /*
     *  Couleur prise
     */
    private Couleur m_couleurPrise;

    /*
     * Date ouverture
     */
    private Date m_dateOuverture;

    /*
     * Usager ouvreur
     */
    private long m_idUsagerOuv;

    /*
     * Critique
     */
    private long m_idGym;

    /*
     Parcours archivé
     */
    private boolean m_estArchive;


    public Parcours() { this(ID_NON_DEFINI, "", "Bloc", "", Couleur.Blanc, Date_Actuelle, ID_NON_DEFINI, ID_NON_DEFINI, false);}


    public Parcours(long p_idParcours, String p_nomParcours, String p_typeVoie, String p_difficulte, Couleur p_couleurPrise, Date p_dateOuverture, long p_idUsagerOuv, long p_idGym, boolean p_estArchive) {
        this.setM_idParcours(p_idParcours);
        this.setM_nomParcours(p_nomParcours);
        this.setM_typeVoie(p_typeVoie);
        this.setM_difficulte(p_difficulte);
        this.setM_couleurPrise(p_couleurPrise);
        this.setM_dateOuverture(p_dateOuverture);
        this.setM_usagerOuv(p_idUsagerOuv);
        this.setM_idGym(p_idGym);
        this.setM_estArchive(p_estArchive);
    }



    /*
        * Accesseurs en lecture des données membres
        */
    public String getM_nomParcours() {return m_nomParcours;}

    public long getM_idParcours() {
        return m_idParcours;
    }

    public String getM_typeVoie() {
        return m_typeVoie;
    }

    public String getM_difficulte() {
        return m_difficulte;
    }

    public Couleur getM_couleurPrise() {
        return m_couleurPrise;
    }

    public Date getM_dateOuverture() {
        return m_dateOuverture;
    }

    public long getM_usagerOuv() {
        return m_idUsagerOuv;
    }

    public long getM_idGym() {
        return m_idGym;
    }

    public boolean getM_estArchive() {
        return m_estArchive;
    }

    /*
     * Accesseurs en ecriture des données membres
     */


    public void setM_idParcours(long m_idParcours) {
        this.m_idParcours = m_idParcours;
    }

    public void setM_nomParcours(String m_nomParcours) {
        this.m_nomParcours = m_nomParcours;
    }

    public void setM_typeVoie(String m_typeVoie) {
        this.m_typeVoie = m_typeVoie;
    }

    public void setM_difficulte(String m_difficulte) {
        this.m_difficulte = m_difficulte;
    }

    public void setM_couleurPrise(Couleur m_couleurPrise) {
        this.m_couleurPrise = m_couleurPrise;
    }

    public void setM_dateOuverture(Date m_dateOuverture) {
        this.m_dateOuverture = m_dateOuverture;
    }

    public void setM_usagerOuv(long m_usagerOuv) {
        this.m_idUsagerOuv = m_usagerOuv;
    }

    public void setM_idGym(long m_idGym) {
        this.m_idGym = m_idGym;
    }


    public void setM_estArchive(boolean m_estArchive) {
        this.m_estArchive = m_estArchive;
    }


    @Override
    public String toString() {
        String retour = this.getM_typeVoie()+ " - " + this.getM_difficulte() + " - " + this.getM_nomParcours();

        return retour;
    }

    @Override
    public boolean equals(Object o) {
        boolean egaux = false;

            if(o instanceof Parcours)
            {
                Parcours p = (Parcours) o;

                egaux = (this.getM_idParcours() == p.getM_idParcours() &&
                        this.getM_nomParcours().equals(p.getM_nomParcours()) &&
                        this.getM_couleurPrise().equals(p.getM_couleurPrise()) &&
                        this.getM_difficulte() ==  p.getM_difficulte());
            }

        return  egaux;
    }
}
