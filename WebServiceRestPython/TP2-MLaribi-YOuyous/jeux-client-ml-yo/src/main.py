# -*- coding: utf-8 -*-

import webapp2, datetime, json
import requests

def serialiser_pour_json(objet):
    
    """ Permet de sérialiser les dates et heures pour transformer
    un objet en JSON.

    Args:
        objet (obj): L'objet à sérialiser.

    Returns:
        obj : Si c'est une date et heure, retourne une version sérialisée
              selon le format ISO (str); autrement, retourne l'objet
              original non modifié.
    """
        
    if isinstance(objet, datetime.datetime):
        #pour une date et heure, on retoure une chaine au format ISO (Sans milisecondes
        return objet.replace(microsecond=0).isoformat()
    elif isinstance(objet, datetime.date):
        #pour une date on retourne une chaine au format ISO
        return objet.isoformat()
    else:
        return objet


class MainPageHandler(webapp2.RequestHandler):
    
    def afficher_infos_requete(self, url, methode, en_tetes, contenu_json):
        self.response.out.write('\n<h3>Informations sur la requête HTTP' +
                                '</h3>\n')
        self.response.out.write('<p>URL = <span class="url">' + url +
                                '</span></p>\n')
        self.response.out.write('<p>méthode = <span class="methode-http">'
                                + methode + '</span></p>\n')
        self.response.out.write('<p>En-têtes = ' + str(en_tetes) + '</p>\n')
        if contenu_json is not None:
            self.response.out.write('<p>Contenu = ' + contenu_json + '</p>\n')

    def afficher_msg_success_erreur(self, reponse, bon_codes_statut):
        self.response.out.write('\n<h3>Résultat</h3>\n')
        if reponse.status_code in bon_codes_statut:
            self.response.out.write('<p class="msg-succes">Complétée' +
                                    ' avec succès</p>\n')
        else:
            self.response.out.write('<p class="msg-erreur">Échec :' +
                                    ' Code de statut = ' +
                                    str(reponse.status_code) + '</p>\n')

    def afficher_infos_reponse(self, reponse):
        self.response.out.write('\n<h3>Informations sur la réponse HTTP' +
                                '</h3>\n')
        self.response.out.write('<p>Code de statut =' +
                                ' <span class="statut-http">' +
                                str(reponse.status_code) + '</span></p>\n')
        if reponse.content is not None and reponse.content != '':
            self.response.out.write('<p>Contenu = ' + reponse.content
                                    + '</p>\n')
            
    def get(self):
        
        # URL de la racine du service web
        #Version hébergée
        url_base = 'http://tp2-ws-ml-yo.appspot.com/'
        
        self.response.headers['Content-Type'] = 'text/html; charset=utf-8'
        self.response.out.write('<!DOCTYPE html>\n')
        self.response.out.write('<html xmlns="http://www.w3.org/1999/xhtml"' +
                                ' lang="fr-ca" xml:lang="fr-ca">\n')
        self.response.out.write('<head>\n')
        self.response.out.write('\t<meta charset="utf-8" />\n')
        self.response.out.write('\t<title>Tp2 Mehdi Laribi et Youssef Ouyous' +
                                ' - Service Client</title>\n')
        self.response.out.write('\t<link rel="stylesheet"' +
                                ' href="/css/styles.css" />\n')
        self.response.out.write('</head>\n')
        self.response.out.write('<body>\n\n')
        self.response.out.write('<h1>TP2 Mehdi Laribi et Youssef Ouyous - WS Rest in Python - Client')
        
        
        ###########################################
        # Ré-initialisation de la base de données #
        ###########################################
        self.response.out.write('\n<h2>Ré-initialisation de la base' +
                                ' de données</h2>\n')
        # Informations pour créer la requête.
        uri = '/jeux'
        url = url_base + uri
        methode = 'DELETE'
        en_tetes = {}
        
        #Envoi de la requete DELETE
        reponse = requests.delete(url, headers=en_tetes)
        
        #Affichage  des informations sur le test
        self.afficher_infos_requete(url, methode, en_tetes, None)
        self.afficher_msg_success_erreur(reponse, [204, 200])
        self.afficher_infos_reponse(reponse)
        
        
        
        ###########################################
        #       Initialisation du datastore       #
        ###########################################
        
        self.response.out.write('\n<h2>TEST-0 : Remplissage du datastore</h2>\n')
        
        # Informations pour créer la requete
        uri = '/Chargement'
        url = url_base + uri
        methode = 'PUT'
        #Header
        en_tetes = {'Content-Type': 'application/json; charset=utf-8',
                    'Accept': 'application/json'}
        #Envoi de la requete
        reponse = requests.put(url, headers=en_tetes)
        
        #Affichage des informations sur le test
        self.afficher_infos_requete(url, methode, en_tetes, None)
        self.afficher_msg_success_erreur(reponse, [200])
        self.afficher_infos_reponse(reponse)
        
        ###########################################
        # TEST-1 : Ajouter un nouveau jeu         #
        ###########################################
        self.response.out.write("\n<h2>Test 1: Ajout d'un jeu</h2>\n")
        
        #Informations pour créer la requete
        uri = '/jeux/00001'
        url = url_base + uri
        methode = 'PUT'
        #Nouveau contenu
        contenu_dic = {'gameTitle': 'Legacy of Karine', 'platform': 'PC', 'releaseDate' : "01/01/2001", 'lstHero' : ['Mehdi', 'Youssef'] }
        #Conversion en JSON
        contenu_json = json.dumps(contenu_dic, default=serialiser_pour_json)
        
        en_tetes = {'Content-Type': 'application/json; charset=utf-8',
                    'Accept': 'application/json'}
        
        #Envoi de la requête PUT
        reponse = requests.put(url, headers=en_tetes, data=contenu_json)
        
        # Affichage des informations sur le test.
        self.afficher_infos_requete(url, methode, en_tetes, contenu_json)
        self.afficher_msg_success_erreur(reponse, [201])
        self.afficher_infos_reponse(reponse)
        
        ###########################################
        # TEST-2 : Consulter un jeu ajouté        #
        ###########################################
        
        self.response.out.write('\n<h2>TEST-2 : Consulter un jeu ajouté</h2>\n')
        
        # Informations pour créer la requete
        uri = '/jeux/00001'
        url = url_base + uri
        methode = 'GET'
        en_tetes = {'Accept': 'application/json'}


        # Envoi de la requête
        reponse = requests.get(url, headers=en_tetes)
        
        # Affichage des informations sur le test
        self.afficher_infos_requete(url, methode, en_tetes, None)
        self.afficher_msg_success_erreur(reponse, [200])
        self.afficher_infos_reponse(reponse)
        
        
        ###########################################
        #     TEST-3 : Modifier un jeu            #
        ###########################################
        
        self.response.out.write('\n<h2>TEST-3 : Modifier un jeux</h2>\n')
        
        #Information pour créer la requete
        uri = '/jeux/20802'
        url = url_base + uri
        methode = 'PUT'
        # On doit créer un dictionary avant tout.
        contenu_dict = {'gameTitle': 'Arabic Conception', 'platform': 'Algeria', 'releaseDate' : "09/11/1996", 'lstHero' : ['Mehdi'] }
        # Conversion du dictionary en chaîne JSON.
        contenu_json = json.dumps(contenu_dict,
                                  default=serialiser_pour_json)
        en_tetes = {'Content-Type': 'application/json; charset=utf-8',
                    'Accept': 'application/json'}

        # Envoi de la requête PUT.
        reponse = requests.put(url, headers=en_tetes, data=contenu_json)

        # Affichage des informations sur le test.
        self.afficher_infos_requete(url, methode, en_tetes, contenu_json)
        self.afficher_msg_success_erreur(reponse, [200])
        self.afficher_infos_reponse(reponse)
        
        
        ############################################
        # TEST-4 : Consulter un jeu modifiée       #
        ############################################
        
        self.response.out.write('\n<h2>TEST-4 : Consulter un jeu modifié</h2>\n')
        
        # Informations pour créer la requete
        uri = '/jeux/00001'
        url = url_base + uri
        methode = 'GET'
        en_tetes = {'Accept': 'application/json'}


        # Envoi de la requête
        reponse = requests.get(url, headers=en_tetes)
        
        # Affichage des informations sur le test
        self.afficher_infos_requete(url, methode, en_tetes, None)
        self.afficher_msg_success_erreur(reponse, [200])
        self.afficher_infos_reponse(reponse)
        
        ###################################
        # TEST-5 : Supprimer un jeu       #
        ###################################
        self.response.out.write('\n<h2>TEST-5 : Supprimer un jeu</h2>\n')

        # Informations pour créer la requête.
        uri = '/jeux/00001'
        url = url_base + uri
        methode = 'DELETE'
        en_tetes = {}

        # Envoi de la requête DELETE.
        reponse = requests.delete(url, headers=en_tetes)

        # Affichage des informations sur le test.
        self.afficher_infos_requete(url, methode, en_tetes, None)
        self.afficher_msg_success_erreur(reponse, [204, 200])
        self.afficher_infos_reponse(reponse)
        
        #############################################
        # TEST-6 : Consulter un jeu supprimé        #
        #############################################
        self.response.out.write('\n<h2>TEST-6 : Consulter un jeu' +
                                ' supprimé</h2>\n')

        # Informations pour créer la requête.
        uri = '/jeux/00001'
        url = url_base + uri
        methode = 'GET'
        en_tetes = {'Accept': 'application/json'}

        # Envoi de la requête GET.
        reponse = requests.get(url, headers=en_tetes)

        # Affichage des informations sur le test.
        self.afficher_infos_requete(url, methode, en_tetes, None)
        # On devrait obtenir 404 car la ressource n'existe plus.
        self.afficher_msg_success_erreur(reponse, [404])
        self.afficher_infos_reponse(reponse)
        
        #############################################
        # TEST-7 : Consulter les heros d'un jeu     #
        #############################################
        self.response.out.write('\n<h2>TEST-7 : Consulter des heros' +
                                ' d un jeu</h2>\n')

        # Informations pour créer la requête.
        # Ninjas turtles
        uri = '/jeux/19711/hero'
        url = url_base + uri
        methode = 'GET'
        en_tetes = {'Accept': 'application/json'}

        # Envoi de la requête Get
        reponse = requests.get(url, headers=en_tetes)
        
        # Affichage des informations sur le test
        self.afficher_infos_requete(url, methode, en_tetes, None)
        self.afficher_msg_success_erreur(reponse, [200])
        self.afficher_infos_reponse(reponse)

        ###########################################
        # TEST-8 :Consulter un jeu avec           #
        # contrainte : mots_cle                   #
        ###########################################
        
        self.response.out.write('\n<h2>TEST-8 : Consulter un jeu avec mot cles</h2>\n')
        
        # Informations pour créer la requete
        uri = '/jeux?mots_cle="Simpsons"'
        url = url_base + uri
        methode = 'GET'
        en_tetes = {'Accept': 'application/json'}


        # Envoi de la requête
        reponse = requests.get(url, headers=en_tetes)
        
        # Affichage des informations sur le test
        self.afficher_infos_requete(url, methode, en_tetes, None)
        self.afficher_msg_success_erreur(reponse, [200])
        self.afficher_infos_reponse(reponse)
        
        
        ###########################################
        # TEST-9 :Consulter un jeu avec           #
        # contrainte : hero                       #
        ###########################################
        
        self.response.out.write('\n<h2>TEST-9 : Consulter un jeu avec contrainte Hero</h2>\n')
        
        # Informations pour créer la requete
        uri = '/jeux?hero="Bart"'
        url = url_base + uri
        methode = 'GET'
        en_tetes = {'Accept': 'application/json'}


        # Envoi de la requête
        reponse = requests.get(url, headers=en_tetes)
        
        # Affichage des informations sur le test
        self.afficher_infos_requete(url, methode, en_tetes, None)
        self.afficher_msg_success_erreur(reponse, [200])
        self.afficher_infos_reponse(reponse)
        
        
        ###########################################
        # TEST-10 :Consulter un jeu avec          #
        # contrainte : date_min                   #
        ###########################################
        
        self.response.out.write('\n<h2>TEST-10 : Consulter un jeu avec contrainte Hero</h2>\n')
        
        uri = '/jeux?date_min="01/01/1990"'
        url = url_base + uri
        methode = 'GET'
        en_tetes = {'Accept': 'application/json'}


        # Envoi de la requête
        reponse = requests.get(url, headers=en_tetes)
        
        # Affichage des informations sur le test
        self.afficher_infos_requete(url, methode, en_tetes, None)
        self.afficher_msg_success_erreur(reponse, [200])
        self.afficher_infos_reponse(reponse)
        
        
        ###########################################
        # TEST-10 :Consulter un jeu avec          #
        # contrainte : date_max                   #
        ###########################################
        
        self.response.out.write('\n<h2>TEST-11 : Consulter un jeu avec contrainte Hero</h2>\n')
        
        uri = '/jeux?date_max="01/01/2008"'
        url = url_base + uri
        methode = 'GET'
        en_tetes = {'Accept': 'application/json'}


        # Envoi de la requête
        reponse = requests.get(url, headers=en_tetes)
        
        # Affichage des informations sur le test
        self.afficher_infos_requete(url, methode, en_tetes, None)
        self.afficher_msg_success_erreur(reponse, [200])
        self.afficher_infos_reponse(reponse)
        
        ###########################################
        # TEST-11 :Consulter un jeu avec          #
        # contrainte : date_min et date_max       #
        ###########################################
        
        self.response.out.write('\n<h2>TEST-12 : Consulter un jeu avec contrainte Hero</h2>\n')
        
        uri = '/jeux?date_min="01/01/1990"&date_max="01/01/2005"'
        url = url_base + uri
        methode = 'GET'
        en_tetes = {'Accept': 'application/json'}


        # Envoi de la requête
        reponse = requests.get(url, headers=en_tetes)
        
        # Affichage des informations sur le test
        self.afficher_infos_requete(url, methode, en_tetes, None)
        self.afficher_msg_success_erreur(reponse, [200])
        self.afficher_infos_reponse(reponse)
 
        
app = webapp2.WSGIApplication(
    [
        webapp2.Route(r'/', handler=MainPageHandler,
                      methods=['GET']),
       ],                        
                              debug=True)
