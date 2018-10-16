package com.example.youssef.goclimber.data.Classes;

/**
 * Created by Mehdi on 2016-03-25.
 */
public enum TypeRéussite {

    aVue ("À vue"),
    flash ("Flash"),
    apresTravail ("Après travail");


    private final String name;

    private TypeRéussite(String s) {
        name = s;
    }

    public boolean equalsName(String otherName) {
        return (otherName == null) ? false : name.equals(otherName);
    }

    public String toString() {
        return this.name;
    }
}
