# Coding: utf-8

from google.appengine.ext import ndb

class DemandePartenaire(ndb.Model):
    idUsager = ndb.KeyProperty(required=True)
    dateHeure = ndb.DateTimeProperty(required=True)
    typeParcours = ndb.StringProperty(required=True)
    adresseParcours = ndb.StringProperty(required=True)
        