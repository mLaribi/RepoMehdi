package com.example.youssef.goclimber;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.provider.SyncStateContract;
import android.util.Log;
import android.view.View;
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

public class Login extends Activity {

    private final static String WEB_SERVICE_URL = "tp4-ws-ml-yo.appspot.com";
    private final static String REST_LOGIN = "/login";
    private final static int CONNECTION_TIMEOUT = 5000;
    private final String TAG = this.getClass().getSimpleName();

    private HttpURLConnection mHttpURLConnection = null;
    private EditText nomCompte;
    private EditText motPasse;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_login);

        nomCompte = (EditText) findViewById(R.id.txtNomDeCompte);
        motPasse = (EditText) findViewById(R.id.txtPassword);


    }

    public void lblInscriptionClick (View v) {
        Intent i = new Intent(this, Inscription.class);
        startActivity(i);
    }

    public void lblOublierMdpClick (View v) {
        Toast.makeText(this, "Un email à été envoyé", Toast.LENGTH_LONG).show();
    }

    public void btnConnexionClick (View v) {
        ArrayList<String> mesParms = new ArrayList<>();
        mesParms.add(nomCompte.getText().toString());
        mesParms.add(motPasse.getText().toString());
        new getUserTask(this).execute(mesParms);
    }

    class getUserTask extends AsyncTask<ArrayList<String>, Void, Utilisateur> {

        Exception mException;
        Utilisateur monUser;
        private Context context;

        public getUserTask(Context context){
            this.context = context;
        }

        @Override
        protected Utilisateur doInBackground(ArrayList<String>... params) {
            Utilisateur user = null;
            BufferedWriter bw = null;
            OutputStreamWriter osw = null;

            try{
                String nomCompte = params[0].get(0);
                String motPasse = params[0].get(1);

                URL url = new URL("http", WEB_SERVICE_URL, REST_LOGIN);
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
                httpURLConnection.setConnectTimeout(CONNECTION_TIMEOUT);


                httpURLConnection.setRequestMethod("POST");


                httpURLConnection.setDoOutput(true);
                httpURLConnection.setRequestProperty("Content-Type", "application/json");
                httpURLConnection.setRequestProperty("Accept", "application/json");

                JSONObject json = jsonParser.serialJsonLogin(nomCompte, motPasse);


                osw = new OutputStreamWriter(httpURLConnection.getOutputStream(),"UTF-8");
                osw.write(json.toString());
                osw.flush();
                String body = readStream(httpURLConnection.getInputStream());
                osw.close();




                Log.i(TAG, "Reçu : " + body);

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
                monUser = utilisateur;
                Utilitaire.user = monUser;

                Intent i = new Intent(context, MainActivity.class);
                context.startActivity(i);
                ((Activity)context).finish();
            }
            else{
                Toast.makeText(Login.this, "Mauvais identifiants", Toast.LENGTH_LONG).show();
            }

        }
    }

}