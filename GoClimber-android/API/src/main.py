# coding: utf-8

import json, webapp2, logging, traceback
import os
import hashlib, uuid
from google.appengine.ext import ndb, db
from usager import Usager
from demandePartenaire import DemandePartenaire
from difficulte import Difficulte
from datetime import datetime
from parcours import Parcours
from critique import Critique
from gym import Gym


def genSalt():
    monSalt = uuid.uuid4().hex
    return monSalt

def saltPassword(password, salt):
    return hashlib.sha512(password + salt).hexdigest()

#Sérialisation d'un objet date en json
def serial_pour_json(object):
    if isinstance(object, datetime):
        # Pour une date et heure, on retourne une chaîne
        # au format ISO (sans les millisecondes).
        return object.replace(second=0).isoformat()
    else:
        return object



#Test fonctionnel du service Web
class MainPageHandler(webapp2.RequestHandler):

    def get(self):
        self.response.headers['Content-type'] = 'text/plain; charset=utf-8'
        self.response.out.write('TP Android Youssef Ouyous Mehdi Laribi')

class ChargementHandler(webapp2.RequestHandler):
        def post(self):
            json_file = open('usagers.json')
            usager_dict = json.load(json_file)
            mesUsagers = usager_dict['Data']['Usager']

            for usager in mesUsagers:
                usagerRetour = Usager()


                usagerRetour.nomUsager = usager['nomUsager']
                usagerRetour.prenom = usager['prenom']
                usagerRetour.nom = usager['nom']
                usagerRetour.courriel = usager['courriel']
                usagerRetour.typeUtil = usager['typeUtil']
                usagerRetour.adresse = usager['adresse']
                usagerRetour.noTel = usager['noTel']
                usagerRetour.digest = str(genSalt())
                usagerRetour.mdp = saltPassword(usager['mdp'], usagerRetour.digest)
                usagerRetour.token = str(genSalt())

                usagerRetour.put()

            self.response.set_status(201)

class LoginHandler(webapp2.RequestHandler):
    def post(self):
        try:
            item_dict = json.loads(self.request.body)
            qry = Usager.query(Usager.nomUsager == item_dict['nomUsager'])

            user = qry.get()

            if(user is None):
                self.error(403)
                return

            if(user.mdp == saltPassword(item_dict['mdp'], user.digest)):
                status = 201
                user_dict = user.to_dict()
                user_dict['id'] = user.key.id()
                del user_dict['mdp']
                del user_dict['digest']
                json_data = json.dumps(user_dict, default=serial_pour_json)
                self.response.headers['Content-Type'] = ('application/json;' + ' charset=utf-8')
                self.response.out.write(json_data)
            else:
                status = 403

            self.response.set_status(status)
        except (db.BadValueError, ValueError, KeyError):
            self.error(400)

        except Exception:
            self.error(500)

class UsagerHandler(webapp2.RequestHandler):
    def post(self):
            usager_add = json.loads(self.request.body)
            usagerAjouter = Usager()

            usagerAjouter.nomUsager = usager_add['nomUsager']
            usagerAjouter.prenom = usager_add['prenom']
            usagerAjouter.nom = usager_add['nom']
            usagerAjouter.courriel = usager_add['courriel']
            usagerAjouter.typeUtil = usager_add['typeUtil']
            usagerAjouter.adresse = usager_add['adresse']
            usagerAjouter.noTel = usager_add['noTel']
            usagerAjouter.digest = str(genSalt())
            usagerAjouter.mdp = saltPassword(usager_add['mdp'], usagerAjouter.digest)
            usagerAjouter.token = str(genSalt())
            usagerAjouter.ptsBloc = usager_add['ptsBloc']
            usagerAjouter.ptsVoie = usager_add['ptsVoie']


            usagerAjouter.put()
            
            user_dict_retour = usagerAjouter.to_dict()
            user_dict_retour['id'] = usagerAjouter.key.id()
            del user_dict_retour['digest']
            del user_dict_retour['mdp']
            json_data = json.dumps(user_dict_retour, default=serial_pour_json)
            self.response.headers['Content-Type'] = ('application/json;' + ' charset=utf-8')
            self.response.out.write(json_data)
            
            self.response.set_status(201)

            

    def get(self, id=None):
        try:
            if(id is not None):
                user = Usager.get_by_id(int(id))

                if user is None:
                    self.error(404)
                    return

                usager_dict = user.to_dict()
                usager_dict['id'] = user.key.id()
                del usager_dict['mdp']
                del usager_dict['digest']
                del usager_dict['token']
                json_data = json.dumps(usager_dict, default=serial_pour_json)
            else:
                lstUsager = []
                req = Usager.query()

                reqContenu = req.fetch()

                for user in reqContenu:
                    usager_dict = user.to_dict()
                    usager_dict['id'] = user.key.id()
                    del usager_dict['mdp']
                    del usager_dict['digest']
                    del usager_dict['token']
                    lstUsager.append(usager_dict)

                json_data = json.dumps(lstUsager, default=serial_pour_json)

            self.response.set_status(200)
            self.response.headers['Content-type'] = ('application/json;' + 'charset=utf-8')
            self.response.out.write(json_data)

        except (db.BadValueError, ValueError, KeyError):
            self.error(400)

        except Exception:
            self.error(500)

    def put(self, id):
        try:
            user = Usager.get_by_id(int(id))

            if user is None:
                self.error(404)
                return

            usager_in = json.loads(self.request.body)

            user.courriel = usager_in['courriel']
            user.adresse = usager_in['adresse']
            user.noTel = usager_in['noTel']
            user.mdp = saltPassword(usager_in['mdp'], user.digest)
            user.ptsVoie = usager_in['ptsVoie']
            user.ptsBloc = usager_in['ptsBloc']

            user.put()
            self.response.set_status(200)

        except (db.BadValueError, ValueError, KeyError):
            self.error(400)

        except Exception:
            self.error(500)

class demandePartenaireHandler(webapp2.RequestHandler):
    def get(self, id=None):
        if id is not None:
            maDemande = DemandePartenaire.get_by_id(int(id))

            if maDemande is None:
                self.error(404)
                return

            demande_dict = maDemande.to_dict()
            demande_dict['id'] = maDemande.key.id()
            strformat = str(demande_dict['idUsager']).split(",")[1][:-1]
            demande_dict['idUsager'] = strformat.strip()
            json_data = json.dumps(demande_dict, default=serial_pour_json)
        else:
            lstDemande = []
            req = DemandePartenaire.query()

            reqContenu = req.fetch()

            for demande in reqContenu:
                demande_dict = demande.to_dict()
                demande_dict['id'] = demande.key.id()
                strformat = str(demande_dict['idUsager']).split(",")[1][:-1]
                demande_dict['idUsager'] = strformat.strip()
                lstDemande.append(demande_dict)

            json_data = json.dumps(lstDemande, default=serial_pour_json)


        self.response.set_status(200)
        self.response.headers['Content-type'] = ('application/json;' + 'charset=utf-8')
        self.response.out.write(json_data)

    def post(self,idUsager):
        user = Usager.get_by_id(int(idUsager))

        if user is None:
            self.error(404)
            return

        demande = DemandePartenaire()
        demande_dict_in = json.loads(self.request.body)

        demande.idUsager = user.key
        demande.adresseParcours = demande_dict_in['adresse']
        demande.typeParcours = demande_dict_in['type']
        demande.dateHeure = datetime.strptime(demande_dict_in['dateHeure'], "%d/%m/%Y %H:%M")
        demande.put()

        self.response.set_status(201)

    def put(self, id):
        demande = DemandePartenaire.get_by_id(int(id))

        if demande is None:
            self.error(404)
            return

        demande_in = json.loads(self.request.body)
        demande.adresseParcours = demande_in['adresseParcours']
        demande.typeParcours = demande_in['typeParcours']
        demande.dateHeure = datetime.strptime(demande_in['dateHeure'],  "%d/%m/%Y %H:%M")

        demande.put()
        self.response.set_status(200)

    def delete(self, id):
        maDemande = DemandePartenaire.get_by_id(int(id))

        if maDemande is None:
            self.error(404)
            return

        maDemande.key.delete()
        self.response.set_status(204)

class UsagerDemandeHandler(webapp2.RequestHandler):
    def get(self, idUsager):
        lstDemande = []
        user = Usager.get_by_id(int(idUsager))

        if user is None:
            self.error(404)
            return

        req = DemandePartenaire.query(DemandePartenaire.idUsager == user.key)

        reqContenu = req.fetch()

        for demande in reqContenu:
            demande_dict = demande.to_dict()
            demande_dict['id'] = demande.key.id()
            strformat = str(demande_dict['idUsager']).split(",")[1][:-1]
            demande_dict['idUsager'] = strformat.strip()
            lstDemande.append(demande_dict)

        json_data = json.dumps(lstDemande, default=serial_pour_json)

        self.response.set_status(200)
        self.response.headers['Content-type'] = ('application/json;' + 'charset=utf-8')
        self.response.out.write(json_data)


class difficulteHandler(webapp2.RequestHandler):
    def post(self):
        json_file = open('difficulte.json')
        diff_dict = json.load(json_file)
        mesDiffs = diff_dict['Data']['Difficulte']

        for diff in mesDiffs:
            diffRetour = Difficulte()
            diffRetour.typeDiff = diff['typeDiff']
            diffRetour.nomDiff = diff['nomDiff']
            diffRetour.points = diff['points']
            diffRetour.put()

        self.response.set_status(201)

    def get(self, type):
        lstDiff = []
        req = Difficulte.query(Difficulte.typeDiff == type).order(Difficulte.points)

        if req.count() == 0:
            self.error(404)
            return

        reqContenu = req.fetch()

        for diff in reqContenu:
            diff_dict = diff.to_dict()
            lstDiff.append(diff_dict)


        json_data = json.dumps(lstDiff, default=serial_pour_json)
        self.response.set_status(200)
        self.response.headers['Content-type'] = ('application/json;' + 'charset=utf-8')
        self.response.out.write(json_data)

class ParcoursHandler(webapp2.RequestHandler):

    def put(self, idParcours):

        """ Permet de modifier un Parcours ayant un certain ID

        args :
            idParcours : represente l'identifiant dans la datastore du parcours

        """

        try:
            #crée la clé à partir du nom du model
            parcours = Parcours.get_by_id(int(idParcours))

            #récupère la clé :
            if(parcours is None):
                self.error(404)
                return

            parc_dic_in = json.loads(self.request.body)

            parcours.nomParcours = parc_dic_in['nomParcours']
            parcours.typeVoie = parc_dic_in['typeVoie']
            parcours.difficulte = parc_dic_in['difficulte']
            parcours.couleur = parc_dic_in['couleur']
            parcours.dateOuverture = datetime.strptime(parc_dic_in['dateOuverture'], '%d/%m/%Y')
            parcours.estArchive = parc_dic_in['estArchive']

            #Création de l'entité parcours
            parcours.put()

            #Configuration du code de sttus http (Created ou OK)
            self.response.set_status(200)


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

    def post(self, idGym):

            """Permet d'ajouter un Parcours.
            L'ID sera généré.

            """

            try:

                #cle_gym = ndb.Key('Gym', id)
                gym = Gym.get_by_id(int(idGym))
                #Si le gym existe
                if(gym is None):
                    self.error(404)
                    return
                parcAj = Parcours()
                parc_dict_in = json.loads(self.request.body)

                usager = Usager.get_by_id(int(parc_dict_in['idUsager']))

                if 'idCritique' in parc_dict_in:
                    critique = Critique.get_by_id(int(parc_dict_in['idCritique']))
                    parcAj.idCritique = critique.key

                parcAj.idUsager = usager.key
                parcAj.idGym = gym.key
                parcAj.nomParcours = parc_dict_in['nomParcours'].title()
                parcAj.typeVoie = parc_dict_in['typeVoie'].title()
                parcAj.difficulte = parc_dict_in['difficulte']
                parcAj.couleur = parc_dict_in['couleur'].title()
                parcAj.dateOuverture = datetime.strptime(parc_dict_in['dateOuverture'], '%d/%m/%Y')
                parcAj.estArchive = parc_dict_in['estArchive']

                cle_parc =  parcAj.put()

                # Configuration du code de statut HTTP (201 Created).
                self.response.set_status(201)

                self.response.headers['Location'] = (self.request.url + '/' +
                                                 str(cle_parc.id()))

            except (db.BadValueError, ValueError, KeyError):
                logging.error('%s', traceback.format_exc())
                self.error(400)

            except Exception:
                logging.error('%s', traceback.format_exc())
                self.error(500)


    def get(self, idParcours=None):

            """Permet d'obtenir une représentation d'un parcours ayant un certain
                id ou bien tous les parcours si l'id n'est pas spécifié

            args :

                idParcours : l'id d'un certain parcours sinon "None" pour tous les
                parcours
            """

            try:

                if(idParcours is not None):
                    #un parcours
                    parcours = Parcours.get_by_id(int(idParcours))

                    #Si innexistant
                    if(parcours is None):
                        self.error(404)
                        return

                    parc_dict = parcours.to_dict()
                    strformat = str(parc_dict['idGym']).split(",")[1][:-1]
                    parc_dict['idGym'] = strformat.strip()
                    strFormat2 = str(parc_dict['idUsager']).split(",")[1][:-1]
                    parc_dict['idUsager'] = strFormat2.strip()
                    json_data = json.dumps(parc_dict, default=serial_pour_json)
                else:
                    #tous les parcours
                    lstParcours = []
                    requete = Parcours.query()

                    reqContenu = requete.fetch()

                    for parc in reqContenu:
                        parc_dict = parc.to_dict()
                        parc_dict['idParcours'] = parc.key.id()
                        strformat = str(parc_dict['idGym']).split(",")[1][:-1]
                        parc_dict['idGym'] = strformat.strip()
                        strFormat2 = str(parc_dict['idUsager']).split(",")[1][:-1]
                        parc_dict['idUsager'] = strFormat2.strip()
                        lstParcours.append(parc_dict)

                    json_data = json.dumps(lstParcours, default=serial_pour_json)

                self.response.set_status(200)
                self.response.headers['Content-Type'] = ('application/json;' +
                                                     ' charset=utf-8')
                self.response.out.write(json_data)

            except (db.BadValueError, ValueError, KeyError):
                logging.error('%s', traceback.format_exc())
                self.error(400)

            except Exception:
                logging.error('%s', traceback.format_exc())
                self.error(500)

    def delete(self, idParcours):

        """
            permet de supprimer un parcours selon son ID sinon si ID=NONE
            Supprime tous les parcours
        """
        try:
            parcours = Parcours.get_by_id(int(idParcours))

            if parcours is None:
                self.error(404)
                return

                parcours.key.delete()

            self.response.set_status(204)
        except (db.BadValueError, ValueError, KeyError):
            logging.error('$s', traceback.format_exc())
            self.error(400)

        except Exception:
            logging.error('$s', traceback.format_exc())
            self.error(500)




class CritiqueHandler(webapp2.RequestHandler):

    def put(self, idCritique):

        """
            Permet d'obtenir une certaine critique selon l'ID reçu sinon toutes les
            critiques si idCritique = NONE

            args :
                idCritique : Identifiant de la critique

        """

        try:
        
            crit = Critique.get_by_id(int(idCritique))

            if(crit is None):
                self.error(404)
                return
            #Corps de la requête
            crit_dict_in = json.loads(self.request.body)

            #Récupération du JSON dans l'objet courant
            crit.styleVoie = crit_dict_in['styleVoie']
            crit.nbEtoiles = float(crit_dict_in['nbEtoiles'])
            crit.typeReussite = crit_dict_in['typeReussite']
            crit.diffSuggestion = crit_dict_in['diffSuggestion']

            #Création ou modifiation de l'objet dans le datastore
            crit.put()

            #Configuration de code de status
            self.response.set_status(200)

            #Configuration de l'entête HTTP
            self.response.headers['Content-Type'] = 'application/json; charset=utf-8'

        except (db.BadValueError, ValueError, KeyError):
            logging.error('$s', traceback.format_exc())
            self.error(400)

        except Exception:
            logging.error('$s', traceback.format_exc())
            self.error(500)

    def get(self, idCritique=None):

        """
            Permet d'obtenir une critique selon l'id.
            Si ID est absent, retourne la représentation de toutes les critiques

            args:
                idCritique : identifiant de la critique demandée
        """

        try:

            if(idCritique is not None):
                #Une critique
                critique = Critique.get_by_id(int(idCritique))

                #Non existant, retourne erreur 404
                if(critique is None):
                    self.error(404)
                    return
            
                crit_dict = critique.to_dict()
                crit_dict['idCritique'] = critique.key.id()
                strFormat = str(crit_dict['idParcours']).split(",")[1][:-1]
                crit_dict['idParcours'] = strFormat.strip()
                strFormat2 = str(crit_dict['idUtilisateur']).split(",")[1][:-1]
                crit_dict['idUtilisateur'] = strFormat2.strip()
                json_data = json.dumps(crit_dict, default=serial_pour_json)

            #Affichage de toutes les critiques
            else:
                #Toutes les critiques
                list_critique = []
                requete = Critique.query()

                for cr in requete:

                    cr_dict = cr.to_dict()
                    cr_dict['idCritique'] = cr.key.id()
                    strFormat = str(cr_dict['idParcours']).split(",")[1][:-1]
                    cr_dict['idParcours'] = strFormat.strip()
                    strFormat2 = str(cr_dict['idUtilisateur']).split(",")[1][:-1]
                    cr_dict['idUtilisateur'] = strFormat2.strip()
                    list_critique.append(cr_dict)

                json_data = json.dumps(list_critique, default=serial_pour_json)

            self.response.set_status(200)
            self.response.headers['Content-Type'] = 'Application/json; charset=utf-8'

            self.response.out.write(json_data)

        except (db.BadValueError, ValueError, KeyError):
            logging.error('%s', traceback.format_exc())
            self.error(400)

        except Exception:
            logging.error('%s', traceback.format_exc())
            self.error(500)


    def delete(self, idCritique):

        """
            Permet de supprimer un critique selon l'identifiant reçu
            sinon toute la liste de critique

        """
        try:

            critique = Critique.get_by_id(int(idCritique))

            if(critique is None):
                self.error(404)
                return

            critique.key.delete()
                
            # No Content.
            self.response.set_status(204)

        except (db.BadValueError, ValueError, KeyError):
            logging.error('%s', traceback.format_exc())
            self.error(400)

        except Exception:
            logging.error('%s', traceback.format_exc())
            self.error(500)


    def post(self, idParcours):
        """
        Permet d'ajouter un gym avec un ID généré.
        Args:
        id (str) :  l'identification du gym
        """
        try:

            parc = Parcours.get_by_id(int(idParcours))

            if(parc is None):
                self.error(404)
                return

            critiqueAj = Critique()
            crit_dict_in = json.loads(self.request.body)

            user = Usager.get_by_id(int(crit_dict_in['idUtilisateur']))

            critiqueAj.idUtilisateur = user.key
            critiqueAj.idParcours = parc.key
            critiqueAj.nbEtoiles = crit_dict_in['nbEtoiles']
            critiqueAj.styleVoie = crit_dict_in['styleVoie']
            critiqueAj.typeReussite = crit_dict_in['typeReussite']
            critiqueAj.diffSuggestion = crit_dict_in['diffSuggestion']

            critiqueAj.put()

            self.response.set_status(201)

        except (db.BadValueError, ValueError, KeyError):
            logging.error('%s', traceback.format_exc())
            self.error(400)

        except Exception:
            logging.error('%s', traceback.format_exc())
            self.error(500)


class GymHandler(webapp2.RequestHandler):

    def post(self):

        """
        Permet d'ajouter un gym avec un ID généré.
        Args:
        id (str) :  l'identification du gym
        """
        try:

                #Création d'un gym
            gym = Gym()
            gym_dict_in = json.loads(self.request.body)

            gym.nom = gym_dict_in['nom']
            gym.adresse = gym_dict_in['adresse']
            gym.codePostal = gym_dict_in['codePostal']
            #Ajout du gym
            gym.put()
            #Configuration du code de status HTTP (201 created)
            self.response.set_status(201)

            # le corps de la réponse contiendra une représetation JSON
            self.response.headers['Content-Type'] = ('application/json; charset=utf-8')
            #gym_dict = gym.to_dict()
            #cle_gym.id()

            # gym_json = json.dumps(gym_dict, default=serial_pour_json)
            #self.response.out.write(gym_json)

        except (db.BadValueError, ValueError, KeyError):
            logging.error('%s', traceback.format_exc())
            self.error(400)

        except Exception:
            logging.error('%s', traceback.format_exc())
            self.error(500)



    def get(self, idGym=None):

        try:
            if(idGym is not None):
                gym = Gym.get_by_id(int(idGym))

                if(gym is None):
                    self.error(404)
                    return
                gym_dict = gym.to_dict()
                json_data = json.dumps(gym_dict, default=serial_pour_json)

            else:

                liste_gym = []
                requete = Gym.query()

                reqContenu = requete.fetch()

                for g in reqContenu:
                    gym_dict = g.to_dict()
                    gym_dict['idGym'] = g.key.id()
                    liste_gym.append(gym_dict)

                json_data = json.dumps(liste_gym, default=serial_pour_json)

            self.response.set_status(200)
            self.response.headers['Content-Type'] = ('application/json;' +
                                                    ' charset=utf-8')
            self.response.out.write(json_data)

        except (db.BadValueError, ValueError, KeyError):
            logging.error('%s', traceback.format_exc())
            self.error(400)

        except Exception:
            logging.error('%s', traceback.format_exc())
            self.error(500)

class TypeParcoursHandler(webapp2.RequestHandler):

    def get(self, idGym, typeVoie):

        """
            Permet d'obtenir la liste de parcours dépendemment du type de voie
            passé en paramêtre
        """

        try:
            liste_retour = []
            monGym = Gym.get_by_id(int(idGym))
            req = Parcours.query(Parcours.idGym == monGym.key)
            parcGym = req.fetch()

            if('bloc' == typeVoie.lower()):

                for bloc in parcGym:
                    parc_dict = bloc.to_dict()
                    if(parc_dict['typeVoie'] == typeVoie):
                        strIdUsager = str(parc_dict['idUsager']).split(",")[1][:-1]
                        parc_dict['idUsager'] = strIdUsager.strip()
                        strIdGym = str(parc_dict['idGym']).split(",")[1][:-1]
                        parc_dict['idGym'] = strIdGym.strip()
                        liste_retour.append(parc_dict)
            else:
                for voie in parcGym:
                    parc_dict = voie.to_dict()
                    if(parc_dict['typeVoie'] == typeVoie):
                        strIdUsager = str(parc_dict['idUsager']).split(",")[1][:-1]
                        parc_dict['idUsager'] = strIdUsager.strip()
                        strIdGym = str(parc_dict['idGym']).split(",")[1][:-1]
                        parc_dict['idGym'] = strIdGym.strip()
                        liste_retour.append(parc_dict)

            json_data = json.dumps(liste_retour, default=serial_pour_json)

            self.response.set_status(200)
            self.response.headers['Content-Type'] = ('application/json;' +
                                                    ' charset=utf-8')
            self.response.out.write(json_data)


        except (db.BadValueError, ValueError, KeyError):
                logging.error('%s', traceback.format_exc())
                self.error(400)

        except Exception:
            logging.error('%s', traceback.format_exc())
            self.error(500)

class classementHandler(webapp2.RequestHandler):
    def get(self, typeParcours):
        lstUserClassement = []

        if typeParcours == "Bloc":
            req = Usager.query().order(Usager.ptsBloc)
            order = req.orders
            reverse_order = order.reversed()
            newReq = Usager.query().order(reverse_order)
            reqContenu = newReq.fetch()

            for user in reqContenu:
                userDict = user.to_dict()
                del userDict['typeUtil']
                del userDict['noTel']
                del userDict['ptsVoie']
                del userDict['adresse']
                del userDict['prenom']
                del userDict['token']
                del userDict['courriel']
                del userDict['mdp']
                del userDict['nom']
                del userDict['digest']
                lstUserClassement.append(userDict)

            json_data = json.dumps(lstUserClassement, default=serial_pour_json)

        else:
            req = Usager.query().order(Usager.ptsVoie)
            order = req.orders
            reverse_order = order.reversed()
            newReq = Usager.query().order(reverse_order)
            reqContenu = newReq.fetch()

            for user in reqContenu:
                userDict = user.to_dict()
                del userDict['typeUtil']
                del userDict['noTel']
                del userDict['ptsBloc']
                del userDict['adresse']
                del userDict['prenom']
                del userDict['token']
                del userDict['courriel']
                del userDict['mdp']
                del userDict['nom']
                del userDict['digest']
                lstUserClassement.append(userDict)

            json_data = json.dumps(lstUserClassement, default=serial_pour_json)

        self.response.set_status(200)
        self.response.headers['Content-Type'] = ('application/json;' +
                                                    ' charset=utf-8')
        self.response.out.write(json_data)
      
class historiqueUsager(webapp2.RequestHandler):
    def get(self, idUsager):
        lstParcours = []
        user = Usager.get_by_id(int(idUsager))
        req = Critique.query(Critique.idUtilisateur == user.key)
        
        reqContenu = req.fetch()
        
        for critique in reqContenu:
            critiqueDict = critique.to_dict()
            strKeyParcours = str(critiqueDict['idParcours']).split(",")[1][:-1]
            monParcours = Parcours.get_by_id(int(strKeyParcours.strip()))
            parcDict = monParcours.to_dict()   
            parcDict['idParcours'] = monParcours.key.id()
            strFormat = str(parcDict['idUsager']).split(",")[1][:-1]
            parcDict['idUsager'] = strFormat.strip()
            strFormat2 = str(parcDict['idGym']).split(",")[1][:-1]
            parcDict['idGym'] = strFormat2.strip()
            lstParcours.append(parcDict)
            
        json_data = json.dumps(lstParcours, default=serial_pour_json)
        self.response.set_status(200)
        self.response.headers['Content-Type'] = ('application/json;' +
                                                    ' charset=utf-8')
        self.response.out.write(json_data)
        
class CritiqueParcoursHandler(webapp2.RequestHandler):
    def get(self, idParcours):
        
        try:
            liste_retour = []
            
            monParcours = Parcours.get_by_id(int(idParcours))
            req = Critique.query(Critique.idParcours == monParcours.key)
            critParc = req.fetch()
                
            for crit in critParc:
                crit_dict = crit.to_dict()
                strIdUsager = str(crit_dict['idUtilisateur']).split(",")[1][:-1]
                crit_dict['idUtilisateur'] = strIdUsager.strip()
                strIdGym = str(crit_dict['idParcours']).split(",")[1][:-1]
                crit_dict['idParcours'] = strIdGym.strip()
                liste_retour.append(crit_dict)
                
            json_data = json.dumps(liste_retour, default=serial_pour_json)
            
            self.response.set_status(200)
            self.response.headers['Content-Type'] = ('application/json;' +
                                                    ' charset=utf-8')
            self.response.out.write(json_data)
            
        except (db.BadValueError, ValueError, KeyError):
                logging.error('%s', traceback.format_exc())
                self.error(400)
                
                
class statistiqueHandler(webapp2.RequestHandler):
    def get(self, idUsager):
        user = Usager.get_by_id(int(idUsager))
        
        req = Critique.query(Critique.idUtilisateur == user.key)
        reqContenu = req.fetch()
        
        nbAVue = 0
        nbFlash = 0
        nbApresTravail = 0
        
        for critique in reqContenu:
            if critique.typeReussite == "vue":
                nbAVue += 1
            elif critique.typeReussite == "flash":
                nbFlash += 1
            else:
                nbApresTravail += 1
                
        dictStats = dict()
        dictStats['nbVue'] = nbAVue
        dictStats['nbFlash'] = nbFlash
        dictStats['nbApresTravail'] = nbApresTravail
        
        json_data = json.dumps(dictStats, default=serial_pour_json)
        self.response.set_status(200)
        self.response.headers['Content-Type'] = ('application/json;' +
                                                    ' charset=utf-8')
        self.response.out.write(json_data)


app = webapp2.WSGIApplication(

    [webapp2.Route(r'/', handler=MainPageHandler, methods=['GET']),
    #webapp2.Route(r'/usagers', handler=ChargementHandler, methods=['POST']),
    webapp2.Route(r'/usagers', handler=UsagerHandler, methods=['GET', 'POST']),
    webapp2.Route(r'/usagers/<id>', handler=UsagerHandler, methods=['GET', 'PUT']),
    webapp2.Route(r'/login', handler=LoginHandler, methods=['POST']),
    webapp2.Route(r'/demandePartenaire', handler=demandePartenaireHandler, methods=['GET']),
    webapp2.Route(r'/demandePartenaire/<id>', handler=demandePartenaireHandler, methods=['GET', 'PUT', 'DELETE']),
    webapp2.Route(r'/usagers/<idUsager>/demandePartenaire', handler=UsagerDemandeHandler, methods=['GET']),
    webapp2.Route(r'/usagers/<idUsager>/demandePartenaire', handler=demandePartenaireHandler, methods=['POST']),
    webapp2.Route(r'/difficulte', handler=difficulteHandler, methods=['POST']),
    webapp2.Route(r'/difficulte/<type>', handler=difficulteHandler, methods=['GET']),

    webapp2.Route(r'/parcours',  handler=ParcoursHandler, methods=['GET', 'DELETE']),
    webapp2.Route(r'/parcours/<idParcours>', handler=ParcoursHandler, methods=['GET', 'DELETE', 'PUT']),
    webapp2.Route(r'/gym/<idGym>/parcours', handler=ParcoursHandler, methods=['POST']),
    webapp2.Route(r'/critique/<idCritique>', handler=CritiqueHandler, methods=['GET', 'DELETE', 'PUT']),
    webapp2.Route(r'/critique', handler=CritiqueHandler, methods=['GET', 'DELETE']),
    webapp2.Route(r'/critique/<idParcours>', handler=CritiqueHandler, methods=['POST']),
    webapp2.Route(r'/gym', handler=GymHandler, methods=['POST', 'GET']),
    webapp2.Route(r'/parcours/<idParcours>/critique', handler=CritiqueParcoursHandler, methods=['GET']),
    webapp2.Route(r'/gym/<idGym>', handler=GymHandler, methods=['GET']),
    webapp2.Route(r'/usagers/<idUsager>/historique', handler=historiqueUsager, methods=['GET']),
    webapp2.Route(r'/gym/<idGym>/Parcours/<typeVoie>', handler=TypeParcoursHandler, methods=['GET']),
    webapp2.Route(r'/classement/<typeParcours>', handler=classementHandler, methods=['GET']),
    webapp2.Route(r'/usagers/<idUsager>/statistique', handler=statistiqueHandler, methods=['GET'])

    ],

                        debug=True)
