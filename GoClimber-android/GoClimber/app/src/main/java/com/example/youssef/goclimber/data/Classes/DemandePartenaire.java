package com.example.youssef.goclimber.data.Classes;

import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.Calendar;

/**
 * Classe demande de partenaire
 */
public class DemandePartenaire implements Serializable {

    /*
 * Date actuelle
 */
    public static final  Calendar Date_Actuelle = null;

    /*
    Identifiant inconnu
     */
    public static final int ID_NONDEF = -1;

    /*
    Identifiant de la demande
     */
    private int m_idDemande;

    /*
     Type de la demande
     */
    private String m_typeParcours;

    /*
     Lieu de sortie
     */
    private String m_adresse;

    /*
    Date et heure de la sortie
     */
    private Calendar m_dateTime;

    /*
    Commentaire sur la sortie
     */
    private String m_commentaire;

    public DemandePartenaire() { this(ID_NONDEF, "", "", Date_Actuelle, "");}


    public DemandePartenaire(int p_idDemande, String p_typeParcours, String p_adresse, Calendar p_dateTime, String p_commentaire) {
        this.setM_idDemande(p_idDemande);
        this.setM_typeParcours(p_typeParcours);
        this.setM_adresse(p_adresse);
        this.setM_dateTime(p_dateTime);
        this.setM_commentaire(p_commentaire);
    }

    public int getM_idDemande() {
        return m_idDemande;
    }

    public void setM_idDemande(int m_idDemande) {
        this.m_idDemande = m_idDemande;
    }

    public String getM_typeParcours() {
        return m_typeParcours;
    }

    public void setM_typeParcours(String m_typeParcours) {
        this.m_typeParcours = m_typeParcours;
    }

    public String getM_adresse() {
        return m_adresse;
    }

    public void setM_adresse(String m_adresse) {
        this.m_adresse = m_adresse;
    }

    public Calendar getM_dateTime() {
        return m_dateTime;
    }

    public void setM_dateTime(Calendar m_dateTime) {
        this.m_dateTime = m_dateTime;
    }

    public String getM_commentaire() {
        return m_commentaire;
    }

    public void setM_commentaire(String m_commentaire) {
        this.m_commentaire = m_commentaire;
    }


    @Override
    public String toString() {

       String spdf =  new SimpleDateFormat("yyyy-MM-dd").format(getM_dateTime().getInstance().getTime());
    String retour = this.getM_typeParcours() + " - " + spdf;

        return retour;

    }
}
