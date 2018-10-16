#Coding : utf-8

from google.appengine.ext import ndb

#Modele de classe Gym
class Gym(ndb.Model):
    nom = ndb.StringProperty(required=True)
    adresse= ndb.StringProperty(required=True)
    codePostal= ndb.StringProperty(required=True)