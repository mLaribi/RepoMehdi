# Coding : utf-8

from google.appengine.ext import ndb

#Classe Usager
class Usager(ndb.Model):
    nomUsager = ndb.StringProperty(required=True)
    mdp = ndb.StringProperty(required=True)
    prenom = ndb.StringProperty(required=True)
    nom = ndb.StringProperty(required=True)
    courriel = ndb.StringProperty(required=True)
    typeUtil = ndb.StringProperty()
    adresse = ndb.StringProperty()
    noTel = ndb.StringProperty()
    digest = ndb.StringProperty()
    token = ndb.StringProperty()
    ptsVoie = ndb.IntegerProperty()
    ptsBloc = ndb.IntegerProperty()

    