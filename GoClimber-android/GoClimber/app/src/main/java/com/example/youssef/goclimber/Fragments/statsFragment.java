package com.example.youssef.goclimber.Fragments;

import android.app.Activity;
import android.content.Intent;
import android.os.AsyncTask;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import com.example.youssef.goclimber.MainActivity;
import com.example.youssef.goclimber.R;
import com.example.youssef.goclimber.Util.Utilitaire;
import com.example.youssef.goclimber.Util.jsonParser;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

public class statsFragment extends Fragment {

    private final static String WEB_SERVICE_URL = "tp4-ws-ml-yo.appspot.com";
    private final static String REST_USAGERS = "/usagers";
    private final static int CONNECTION_TIMEOUT = 5000;
    private HttpURLConnection mHttpURLConnection = null;

    private TextView affAvue;
    private TextView affTravail;
    private TextView affFlash;


    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View maView = inflater.inflate(R.layout.activity_stats_fragment, container, false);
        affAvue = (TextView) maView.findViewById(R.id.txtAffAVue);
        affFlash = (TextView) maView.findViewById(R.id.txtAffFlash);
        affTravail = (TextView) maView.findViewById(R.id.txtAffApresTravail);

        new GetStatsTask().execute();
        return maView;
    }

    private class GetStatsTask extends AsyncTask<Void, Void, ArrayList<String>> {
        Exception mException;

        @Override
        protected ArrayList<String> doInBackground(Void... params) {
            ArrayList<String> mesStats = new ArrayList<>();
            try{

                URL url = new URL("http", WEB_SERVICE_URL, REST_USAGERS + "/" + Utilitaire.user.getM_idUtilisateur() + "/statistique");
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
                httpURLConnection.setConnectTimeout(CONNECTION_TIMEOUT);


                httpURLConnection.setRequestMethod("GET");
                String body = readStream(httpURLConnection.getInputStream());

                mesStats = jsonParser.deserializeJsonStats(body);
            }catch (Exception e) {
                mException = e;
            }finally {
                if (mHttpURLConnection != null) {
                    mHttpURLConnection.disconnect();
                }
            }
            return mesStats;
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
        protected void onPostExecute(ArrayList<String> strings) {
            if(mException == null) {
                affAvue.setText(strings.get(2));
                affTravail.setText(strings.get(0));
                affFlash.setText(strings.get(1));
            }
            else{
                Toast.makeText(getContext(), "Problème au chargement", Toast.LENGTH_LONG).show();
            }
        }
    }
}