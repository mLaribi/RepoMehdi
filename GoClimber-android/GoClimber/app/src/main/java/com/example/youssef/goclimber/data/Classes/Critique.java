package com.example.youssef.goclimber.data.Classes;

import java.io.Serializable;

/**
 * Created by Mehdi on 2016-03-23.
 */
public class Critique implements Serializable {

    /*
    Identifiant non defini
     */
    public static final int ID_NonDef = -1;

    /*
     Identifiant unique de la critique
     */
    private int m_idCritique;

    /*
        Identifiant du parcours critiqué
     */
    private int m_idParcours;

    /*
     * Identifiant de l'auteur (Id Utilisateur)
     */
    private int m_idUtilisateur;

    /*
     Nombre d'étoile
     */
    private float m_nbEtoile;

    /*
     Style de parcours (Moulinette ou premier de corde)
     */
    private StyleVoie m_styleVoie;

    /*
    Type de réussite (à vue, Flash, Apres travail)
     */

    private TypeRéussite m_typeReussite;

    /*
       Critique publiée
     */
    private String m_diffSuggestion;



    public Critique() { this(ID_NonDef, ID_NonDef, ID_NonDef, 0, null, null, ""); }


    public Critique(int p_idCritique, int p_idParcours, int p_idUtilisateur, float p_nbEtoile, StyleVoie p_styleVoie, TypeRéussite p_typeReussite, String p_diffSuggestion) {
        this.setM_idCritique(p_idCritique);
        this.setM_idParcours(p_idParcours);
        this.setM_idUtilisateur(p_idUtilisateur);
        this.setM_diffSuggestion(p_diffSuggestion);
        this.setM_nbEtoile(p_nbEtoile);
        this.setM_styleVoie(p_styleVoie);
        this.setM_typeReussite(p_typeReussite);
    }


    public float getM_nbEtoile() {
        return m_nbEtoile;
    }

    public void setM_nbEtoile(float m_nbEtoile) {
        this.m_nbEtoile = m_nbEtoile;
    }

    public StyleVoie getM_styleVoie() {
        return m_styleVoie;
    }

    public void setM_styleVoie(StyleVoie m_styleVoie) {
        this.m_styleVoie = m_styleVoie;
    }

    public TypeRéussite getM_typeReussite() {
        return m_typeReussite;
    }

    public void setM_typeReussite(TypeRéussite m_typeReussite) {
        this.m_typeReussite = m_typeReussite;
    }

    public int getM_idCritique() {
        return m_idCritique;
    }

    public void setM_idCritique(int m_idCritique) {
        this.m_idCritique = m_idCritique;
    }

    public int getM_idParcours() {
        return m_idParcours;
    }

    public void setM_idParcours(int m_idParcours) {
        this.m_idParcours = m_idParcours;
    }

    public int getM_idUtilisateur() {
        return m_idUtilisateur;
    }

    public void setM_idUtilisateur(int m_idUtilisateur) {
        this.m_idUtilisateur = m_idUtilisateur;
    }

    public String getM_diffSuggestion() {
        return m_diffSuggestion;
    }

    public void setM_diffSuggestion(String m_diffSuggestion) {
        this.m_diffSuggestion = m_diffSuggestion;
    }
}
