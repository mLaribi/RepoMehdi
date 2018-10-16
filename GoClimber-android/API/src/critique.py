# coding in UTF-8

from google.appengine.ext import ndb

# Model de classe critique

class Critique(ndb.Model):

    idParcours=ndb.KeyProperty(required=True)
    idUtilisateur=ndb.KeyProperty(required=True)
    nbEtoiles=ndb.FloatProperty(required=True)
    styleVoie=ndb.StringProperty()
    typeReussite=ndb.StringProperty(required=True)
    diffSuggestion=ndb.StringProperty(required=True)
    