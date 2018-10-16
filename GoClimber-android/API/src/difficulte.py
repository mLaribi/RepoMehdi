from google.appengine.ext import ndb

class Difficulte(ndb.Model):
    typeDiff = ndb.StringProperty(required=True)
    nomDiff = ndb.StringProperty(required=True)
    points = ndb.IntegerProperty(required=True)