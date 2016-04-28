# -*- coding: utf-8 -*-


#Importation des librarires  
import webapp2, logging, traceback, json
from datetime import datetime
from google.appengine.ext import ndb, db
from models import Jeux, Hero

#Sérialisation d'un objet (date) en format json
def serialiser_pour_json(objet):
    
    
    #Pour date et heure, on retourne une chaine
    # au format ISO (sans les millisecondes).
    if isinstance(objet, datetime):
            return objet.replace(microsecond=0).isoformat()
    #Pour une date, on retourne une chîane au format ISO
    elif isinstance(objet, datetime.date): 
        return objet.isoformat()
    #Sinon objet tel quel
    else:
        return objet;
    


class MainPageHandler(webapp2.RequestHandler):
    
#Test fonctionnel du service web
    def get(self):
        self.response.headers['Content-Type'] = 'text/plain; charset=utf-8'
        self.response.out.write('TP 2  Mehdi Laribi et Youssef Ouyous')
                   
class ChargementHandler(webapp2.RequestHandler):
           
    def put(self):       
                  
        
    #     with open('jeux.json') as file:
    #         jeux_dict = json.load(file)
    #         json.dumps(jeux_dict)
    
    
    #Ouverture du fichier jeux.json présent dans le même repertoire
        json_file = open('jeux.json')
        jeux_dict = json.load(json_file)
         
        lstJeux = jeux_dict['Data']['Game']
    
    #Boucle sur les jeux
        for game in lstJeux:
            
            cle = ndb.Key('Jeux', game['id'])
            jeuxRetour = Jeux(key=cle)
            
            jeuxRetour.gameTitle = game['GameTitle']
            #formats de date differents
            try:
                jeuxRetour.releaseDate = datetime.strptime((game['ReleaseDate']), '%m/%d/%Y')
            except ValueError:
                pass
            
            jeuxRetour.platform = game['Platform']
            
            
            if(game.has_key('Hero')):
                lstHeros = game['Hero']
                heroTemp = Hero()
                if(isinstance(lstHeros, basestring)):
                    lstTemp = []
                    lstTemp.append(lstHeros)
                    heroTemp.nom = lstTemp
                    jeuxRetour.lstHero = lstTemp
                else:
                    heroTemp.nom = lstHeros
                    jeuxRetour.lstHero = lstHeros
                heroTemp.put()
                
                jeuxRetour.lstHero = heroTemp.nom
            #Push le jeu dans le datastore
            jeuxRetour.put()

        self.response.set_status(201)
            
            #Suppression de toute les entités
    def delete(self):
        """ Permet de supprimer tous ce qui est présent sur la dataStore.

        Entités jeux et Hero
        """
        # Suppression de tous les heros.
        ndb.delete_multi(Hero.query().fetch(keys_only=True))
        # Suppression de tous les jeux.
        ndb.delete_multi(Jeux.query().fetch(keys_only=True))  
        
        self.response.set_status(204)
        
class JeuxHandler(webapp2.RequestHandler):
    
    def put(self, idJeu):
        
        """ Permet d'ajouter ou modifier un jeu vidéo ayant un certain ID.

        Args:
            idJeu (str): l'id du jeux vidéo à ajouter (path parameter):
                       obligatoire.
        """
        try:
            
            #Crée la clé à partir du nom de modèle
            cle = ndb.Key('Jeux', idJeu)
            
            #Permet de récuperer l'entité liée à la clé;
            jeu = cle.get()
            
            # L'entité n'existe pas, elle sera créée (201 Created).
            # sinon OK
            if jeu is None:
                
                #Status création objet
                status = 201
                
                jeu = Jeux(key=cle)
                #Sinon mise à jour de l'entité
            
            else: 
                status = 200
                
            jeux_dic_in = json.loads(self.request.body)
            
            #Récuperation et formatages du nom du jeu, de la date de sortie
            #et la plateforme
            jeu.gameTitle = jeux_dic_in['gameTitle'].title()
            jeu.releaseDate = datetime.strptime(jeux_dic_in['releaseDate'], 
                                                         '%m/%d/%Y')
            jeu.platform = jeux_dic_in['platform'].title()
            
            jeu.lstHero = jeux_dic_in['lstHero']
            
            
            #Création de l'entité jeu
            jeu.put()
            
            #Configuration du code de status HTTP (201 ou 204)
            self.response.set_status(status)
            
            #Création d'un dictionnaire contenant les jeux
            jeu_dict = jeu.to_dict();
            
            #identifiant ajouté manuellement comme propriété
            jeu_dict['id'] = jeu.key.id()
            
            #Création de l'expression JSON à partir du dictionnaire
            jeu_json = json.dumps(jeu_dict, default=serialiser_pour_json)
            
            #Configuration de l'entête HTTP "Content-Type" de la réponse.
            self.response.headers['Content-Type'] = ('application/json;' +
                                                     ' charset=utf-8')
            
            #Réponse qui contiendra la représentation json
            self.response.out.write(jeu_json)
            
        #Exception en lien avec les donnés
        except (db.BadValueError, ValueError, KeyError):
            logging.error('%s', traceback.format_exc())
             
            #Bad request
            self.error(400)
            
        #Exceptions graves lors de l'execution du code
        except Exception:
            logging.error('%s', traceback.format_exc())
            #Internal Server Errorl 
            self.error(500)
            
    def get(self, idJeu=None):
        """ Permet d'obtenir une représentation d'un jeu ayant un certain
            ID ou bien de toutes les jeux si l'id n'est pas spécifié.

        Args:
            idJeu (int): L'ID d'un certain jeu ou bien "None" pour
                       obtenir tous les jeux (path parameter):
                       optionnel.
        """
        
        try:
            if(idJeu is not None):
                #Un jeu
                cle = ndb.Key('Jeux', idJeu)
                jeu = cle.get()
                # SI innexistant
                if(jeu is None):
                    self.error(404)
                    return
                
                jeu_dict = jeu.to_dict()
                jeu_dict['id'] = jeu.key.id()
                json_data = json.dumps(jeu_dict, default=serialiser_pour_json)  
                                       
            else:
                #Tous les jeux
                list_jeu = []
                #Création requete sur le datastore
                requete = Jeux.query().order(Jeux.gameTitle)
                
                
                mots_cles = self.request.get('mots_cles')
                
                hero = self.request.get('hero')
                date_min = self.request.get('date_min')
                date_max = self.request.get('date_max')
                
                
                
                
                lstFiltre = []
                
                #filtres lors de la requete
            
                #Aucun filtre ne semble fonctionner
                 
                if(date_min != ''):
                    dateMin= datetime.strptime(date_min, '%m/%d/%Y %H:%M:%S')
               
                    requete = requete.filter(Jeux.releaseDate >= dateMin)
                if(date_max != ''):    
                    dateMax= datetime.strptime(date_max, '%m/%d/%Y %H:%M:%S')
                    requete = requete.filter(Jeux.releaseDate <= dateMax)
                    
                reqContenu = requete.fetch()
                
                for jeu in reqContenu:
                    if(jeu not in lstFiltre):
                        if (mots_cles != '' and ((mots_cles in jeu.platform )or (mots_cles in jeu.gameTitle))):
                            lstFiltre.append(jeu)
                        
                        if (hero != '' and hero in jeu.lstHero):
                            lstFiltre.append(jeu)
                
                tmp = []
                if(lstFiltre):
                    tmp = lstFiltre
                else:
                    tmp = reqContenu
                
                sorted(tmp, )
                for jeu in tmp[0:20]:
                    jeu_dict = jeu.to_dict()
                    jeu_dict['id'] = jeu.key.id()
                    list_jeu.append(jeu_dict)
                
                    
                json_data = json.dumps(list_jeu, default=serialiser_pour_json)    
                 
                 
            self.response.set_status(200)
            self.response.headers['Content-Type'] = ('application/json;' + ' charset=utf-8') 
   
            self.response.out.write(json_data)
            
            
        except (db.BadValueError, ValueError, KeyError):
            logging.error('%s', traceback.format_exc())
            self.error(400)
 
        except Exception:
            logging.error('%s', traceback.format_exc())
            self.error(500)      
            
            
    def delete (self, idJeu=None):
        """ Supprimer un jeu selon l'id
        """
        try:
            #Si id jeu est précisé
            if idJeu is not None :
                #Un seul jeu
                cle = ndb.Key('Jeux', idJeu)
                #Suppression des ses heros
                ndb.delete_multi(Hero.query(ancestor=cle))
                #Suppression du jeu
                cle.delete()
            else:
                #Suppression de tous les heros
                ndb.delete_multi(Hero.query().fetch(keys_only=True))
                #Suppression de tous les jeux
                ndb.delete_multi(Jeux.query().fetch(keys_only=True))
                
                #No content
            self.response.set_status(204)
            
        except (db.BadValueError, ValueError, KeyError):
            logging.error('%s', traceback.format_exc())
            self.error(400)

        except Exception:
            logging.error('%s', traceback.format_exc())
            self.error(500) 
    
class HeroHandler(webapp2.RequestHandler):

    def get(self, idJeu, nom=None):
        """ Permet d'obtenir les heros d'un jeu précis
        """
        try:
#             if(idJeu is not None):
#                 #Un jeu
#                 cle = ndb.Key('Jeux', idJeu)
#                 jeuH = cle.get()
#                 
#                 if(jeuH is None):
#                     self.error(404)
#                     return
#                 
#                 jeu_dict = jeuH.to_dict()
#                 jeu_dict['id'] = jeuH.key.id()
#                 json_data = json.dumps(jeu_dict, default=serialiser_pour_json)  
#             
            #Clé du jeu
            if(idJeu is not None):
                cle_jeux= ndb.Key('Jeux', idJeu)
                jeuxH = cle_jeux.get()
                
            #
            
            if(jeuxH is None):
                self.error(404)
                return
            
            else:
                
                lstHero = jeuxH.lstHero
                
                json_data = json.dumps(lstHero, default=serialiser_pour_json)
            
            self.response.set_status(200)
            self.response.headers['Content-Type'] = ('application/json;' + ' charset=utf-8')

            self.response.out.write(json_data)
        
        except (db.BadValueError, ValueError, KeyError):
            logging.error('%s', traceback.format_exc())
            self.error(400)

        except Exception:
            logging.error('%s', traceback.format_exc())
            self.error(500)   
            
            
            #Configurations des différentes routes
app = webapp2.WSGIApplication(
    #Test du serveur web
    [webapp2.Route(r'/', handler=MainPageHandler,
                    methods=['GET']),
     
    #Chargement et suppression de des jeux videos ainsi que les heros
    webapp2.Route(r'/jeux', handler=ChargementHandler,
                  methods=['PUT', 'DELETE']),
    
    webapp2.Route(r'/jeux', handler=JeuxHandler,
                  methods=['GET', 'DELETE']),
    
    webapp2.Route(r'/jeux/<idJeu>', handler=JeuxHandler,
                  methods=['GET', 'PUT', 'DELETE']),
     
    
    webapp2.Route(r'/jeux/<idJeu>/hero', handler=HeroHandler, 
                  methods=['GET'])
    ],
                              debug=True)
                 
                
            
            
            
            
            