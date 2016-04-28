# Coding : utf-8

from google.appengine.ext import ndb


# Classe Jeux
class Jeux(ndb.Model):
        #idJeu = ndb.IntegerProperty(required=True)
        gameTitle = ndb.StringProperty(required=True)
        releaseDate = ndb.DateTimeProperty()
        platform = ndb.StringProperty(required=True)
        lstHero = ndb.StringProperty(repeated=True)
         
# Son parent est Jeux
class Hero(ndb.Model):
    
        nom = ndb.StringProperty(repeated=True)
