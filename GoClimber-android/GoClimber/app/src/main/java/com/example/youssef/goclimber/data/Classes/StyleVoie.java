package com.example.youssef.goclimber.data.Classes;

/**
 * Created by Mehdi on 2016-03-25.
 */
public enum StyleVoie {

    Moulinette ("Moulinette"),
    Aucun ("Aucun"),
    PremierDeCordée ("Premier de cordée");



    private final String name;

    private StyleVoie(String s) {
        name = s;
    }

    public boolean equalsName(String otherName) {
        return (otherName == null) ? false : name.equals(otherName);
    }

    public String toString() {
        return this.name;
    }
}
