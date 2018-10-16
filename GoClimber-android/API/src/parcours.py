# Coding : utf-8

from google.appengine.ext import ndb

# Model du parcours
class Parcours(ndb.Model):
    nomParcours = ndb.StringProperty()
    typeVoie = ndb.StringProperty(required=True)
    difficulte = ndb.StringProperty(required=True)
    couleur = ndb.StringProperty(required=True)
    dateOuverture = ndb.DateTimeProperty()
    idUsager = ndb.KeyProperty(required=True)
    idGym = ndb.KeyProperty(required=True)
    estArchive = ndb.BooleanProperty(required=True)