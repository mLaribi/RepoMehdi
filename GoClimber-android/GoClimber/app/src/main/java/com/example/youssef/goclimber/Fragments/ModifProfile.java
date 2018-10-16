package com.example.youssef.goclimber.Fragments;


import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.youssef.goclimber.MainActivity;
import com.example.youssef.goclimber.R;
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

public class ModifProfile extends Fragment {

    private Button btnModif;
    private final static String WEB_SERVICE_URL = "tp4-ws-ml-yo.appspot.com";
    private final static String REST_USAGER = "/usagers";
    private final static int CONNECTION_TIMEOUT = 5000;

    private EditText courriel;
    private EditText noTel;
    private EditText adresse;
    private EditText mdp;
    private EditText mdpConfirm;

    private HttpURLConnection mHttpURLConnection = null;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        final View maView = inflater.inflate(R.layout.activity_modif_profile, container, false);

        this.btnModif = (Button) maView.findViewById(R.id.btnModifier);
        this.courriel = (EditText) maView.findViewById(R.id.txtCourrielModif);
        this.noTel = (EditText) maView.findViewById(R.id.txtNumTelModif);
        this.adresse = (EditText) maView.findViewById(R.id.txtAdresseModif);
        this.mdp = (EditText) maView.findViewById(R.id.txtPasswordModif);
        this.mdpConfirm = (EditText) maView.findViewById(R.id.txtConfirmPasswordModif);

        this.btnModif.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(mdp.getText().toString().equals(mdpConfirm.getText().toString())) {
                    ArrayList<String> mesParams = new ArrayList<String>();
                    mesParams.add(courriel.getText().toString());
                    mesParams.add(adresse.getText().toString());
                    mesParams.add(noTel.getText().toString());
                    mesParams.add(mdp.getText().toString());

                    new ModifUserTask(getContext()).execute(mesParams);
                }else {
                    Toast.makeText(getContext(), "Les mots de passe ne correspondent pas", Toast.LENGTH_LONG).show();
                }
            }
        });

        return maView;
    }

    private class ModifUserTask extends AsyncTask<ArrayList<String>, Void, Utilisateur> {

        Exception mException;
        Utilisateur monUser;
        private Context context;

        public ModifUserTask(Context context){
            this.context = context;
        }

        @Override
        protected Utilisateur doInBackground(ArrayList<String>... params) {

            Utilisateur user = null;
            BufferedWriter bw = null;
            OutputStreamWriter osw = null;

            try {
                String courriel = params[0].get(0);
                String adresse = params[0].get(1);
                String noTel = params[0].get(2);
                String mdp = params[0].get(3);

                URL url = new URL("http", WEB_SERVICE_URL, REST_USAGER + "/" + Utilitaire.user.getM_idUtilisateur());
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
                httpURLConnection.setConnectTimeout(CONNECTION_TIMEOUT);


                httpURLConnection.setRequestMethod("PUT");

                //Indique qu'on va écrire dans le corps de la requête
                httpURLConnection.setDoOutput(true);
                httpURLConnection.setRequestProperty("Content-Type", "application/json");
                httpURLConnection.setRequestProperty("Accept", "application/json");

                JSONObject json = jsonParser.serialJsonModifUser(courriel,adresse,noTel,mdp);

                //Écriture de l'object json dans le flux de données.
                osw = new OutputStreamWriter(httpURLConnection.getOutputStream(),"UTF-8");
                osw.write(json.toString());
                osw.flush();
                String body = readStream(httpURLConnection.getInputStream());
                osw.close();

                user = jsonParser.deserializeJsonUser(body);


            }catch (Exception e) {
                mException = e;
            }finally {
                if (mHttpURLConnection != null) {
                    mHttpURLConnection.disconnect();
                }
            }
            return user;
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
        protected void onPreExecute() {

        }

        @Override
        protected void onPostExecute(Utilisateur utilisateur) {
            if(mException == null && utilisateur != null) {
                Utilitaire.user = utilisateur;
                Toast.makeText(getContext(), "Modification avec succès", Toast.LENGTH_LONG).show();
                Intent i = new Intent(context, MainActivity.class);
                context.startActivity(i);
                ((Activity)context).finish();
            }
            else{
                Toast.makeText(getContext(), "Problème lors de la modification", Toast.LENGTH_LONG).show();
            }
        }
    }
}