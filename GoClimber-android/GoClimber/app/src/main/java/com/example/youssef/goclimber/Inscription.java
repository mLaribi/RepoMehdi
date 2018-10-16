package com.example.youssef.goclimber;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.widget.EditText;
import android.widget.Toast;

import com.example.youssef.goclimber.Util.Utilitaire;
import com.example.youssef.goclimber.Util.jsonParser;
import com.example.youssef.goclimber.data.Classes.Utilisateur;

import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

public class Inscription extends AppCompatActivity {

    private final static String WEB_SERVICE_URL = "tp4-ws-ml-yo.appspot.com";
    private final static String REST_USAGER = "/usagers";
    private final static int CONNECTION_TIMEOUT = 5000;
    private HttpURLConnection mHttpURLConnection = null;

    private EditText nom;
    private EditText prenom;
    private EditText nomCompte;
    private EditText courriel;
    private EditText mdp;
    private EditText confirmMdp;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_inscription);

        nom = (EditText) findViewById(R.id.txtNomFamilleInscription);
        prenom = (EditText) findViewById(R.id.txtNomInscription);
        nomCompte = (EditText) findViewById(R.id.txtNomCompteInscription);
        courriel = (EditText) findViewById(R.id.txtCourrielInscription);
        mdp = (EditText) findViewById(R.id.txtPasswordInscription);
        confirmMdp = (EditText) findViewById(R.id.txtConfirmPassword);
    }

    public void BtnInscriptionOnClick (View v) {
        if(mdp.getText().toString().equals(confirmMdp.getText().toString())) {
            Utilisateur monUser = new Utilisateur(1, nomCompte.getText().toString(), mdp.getText().toString(), "Grimpeur", nom.getText().toString(), prenom.getText().toString(), "Adresse Bidon !", courriel.getText().toString(), "NoTel Bidon !", "Token Bidon!", 0,0);
            new PostNewUser(this).execute(monUser);
        }else
        {
            Toast.makeText(Inscription.this, "Les mots de passe ne correspondent pas", Toast.LENGTH_LONG).show();
        }
    }

    private class PostNewUser extends AsyncTask<Utilisateur, Void, Utilisateur> {
        Exception mException;
        Utilisateur monUser;

        private Context context;

        public PostNewUser(Context context){
            this.context = context;
        }

        @Override
        protected void onPreExecute() {
        }

        @Override
        protected Utilisateur doInBackground(Utilisateur... params) {
            BufferedWriter bw = null;
            OutputStreamWriter osw = null;
            Utilisateur usagerRetour = null;

            try {

                Utilisateur user = params[0];

                URL url = new URL("http", WEB_SERVICE_URL, REST_USAGER);

                //Connection.
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();

                httpURLConnection.setConnectTimeout(CONNECTION_TIMEOUT);
                //Méthode
                httpURLConnection.setRequestMethod("POST");

                //Indique qu'on va écrire dans le corps de la requête
                httpURLConnection.setDoOutput(true);
                httpURLConnection.setRequestProperty("Content-Type", "application/json");
                httpURLConnection.setRequestProperty("Accept", "application/json");

                JSONObject json = jsonParser.serialJsonUtilisteur(user);

                //Écriture de l'object json dans le flux de données.
                osw = new OutputStreamWriter(httpURLConnection.getOutputStream(),"UTF-8");
                osw.write(json.toString());
                osw.flush();
                String body = readStream(httpURLConnection.getInputStream());
                osw.close();

                usagerRetour = jsonParser.deserializeJsonUser(body);


            } catch (Exception e) {
                mException = e;
            } finally {
                if (osw != null) {
                    try {
                        osw.flush();
                        osw.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }

                if (mHttpURLConnection != null) {
                    mHttpURLConnection.disconnect();
                }

            }
            return usagerRetour;
        }


        private String readStream(InputStream in) {

            StringBuilder sb = new StringBuilder();

            try {

                //Lecture du flux de données
                BufferedReader reader = new BufferedReader(new InputStreamReader(in,"UTF-8"));

                String nextLine = "";
                while ((nextLine = reader.readLine()) != null) {
                    sb.append(nextLine);
                }
            } catch (IOException e) {
                mException = e;
            }


            return sb.toString();
        }


        @Override
        protected void onPostExecute(Utilisateur user) {
            if(mException == null && user != null) {
                Utilitaire.user = user;

                Intent i = new Intent(context, MainActivity.class);
                context.startActivity(i);
                ((Activity)context).finish();
            }else {
                Toast.makeText(Inscription.this, "Erreur lors de l'ajout, veuillez réessayer", Toast.LENGTH_LONG).show();
            }
        }
    }
}