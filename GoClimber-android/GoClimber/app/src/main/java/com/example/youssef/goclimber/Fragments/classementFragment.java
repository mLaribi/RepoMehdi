package com.example.youssef.goclimber.Fragments;

import android.os.AsyncTask;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.example.youssef.goclimber.R;
import com.example.youssef.goclimber.Util.jsonParser;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

public class classementFragment extends Fragment {

    private final static String WEB_SERVICE_URL = "tp4-ws-ml-yo.appspot.com";
    private final static String REST_CLASSEMENT = "/classement";
    private final static int CONNECTION_TIMEOUT = 5000;
    private HttpURLConnection mHttpURLConnection = null;

    private ListView lstBloc;
    private ListView lstVoie;

    private ArrayAdapter mAdapterBloc;
    private ArrayAdapter mAdapterVoie;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View maView = inflater.inflate(R.layout.activity_classement_fragment, container, false);
        lstBloc = (ListView) maView.findViewById(R.id.lstAffClassementBloc);
        lstVoie = (ListView) maView.findViewById(R.id.lstAffClassementVoie);

        new GetClassementBlocTask().execute();
        new GetClassementVoieTask().execute();

        return maView;
    }

    private class GetClassementBlocTask extends AsyncTask<Void, Void, ArrayList<String>> {
        Exception mException;

        @Override
        protected ArrayList<String> doInBackground(Void... params) {
            ArrayList<String> classementBloc = new ArrayList<>();
            try{

                URL url = new URL("http", WEB_SERVICE_URL, REST_CLASSEMENT + "/Bloc");
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
                httpURLConnection.setConnectTimeout(CONNECTION_TIMEOUT);


                httpURLConnection.setRequestMethod("GET");
                String body = readStream(httpURLConnection.getInputStream());

                classementBloc = jsonParser.deserializeJsonClassementBloc(body);
            }catch (Exception e) {
                mException = e;
            }finally {
                if (mHttpURLConnection != null) {
                    mHttpURLConnection.disconnect();
                }
            }
            return classementBloc;
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
                lstBloc.setAdapter(new ArrayAdapter<String>(getContext(), android.R.layout.simple_list_item_1, strings));
            }
            else{
                Toast.makeText(getContext(), "Problème au chargement", Toast.LENGTH_LONG).show();
            }
        }
    }

    private class GetClassementVoieTask extends AsyncTask<Void, Void, ArrayList<String>> {
        Exception mException;

        @Override
        protected ArrayList<String> doInBackground(Void... params) {
            ArrayList<String> classementBloc = new ArrayList<>();
            try{

                URL url = new URL("http", WEB_SERVICE_URL, REST_CLASSEMENT + "/Voie");
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
                httpURLConnection.setConnectTimeout(CONNECTION_TIMEOUT);


                httpURLConnection.setRequestMethod("GET");
                String body = readStream(httpURLConnection.getInputStream());

                classementBloc = jsonParser.deserializeJsonClassementVoie(body);
            }catch (Exception e) {
                mException = e;
            }finally {
                if (mHttpURLConnection != null) {
                    mHttpURLConnection.disconnect();
                }
            }
            return classementBloc;
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
                lstVoie.setAdapter(new ArrayAdapter<String>(getContext(), android.R.layout.simple_list_item_1, strings));
            }
            else{
                Toast.makeText(getContext(), "Problème au chargement", Toast.LENGTH_LONG).show();
            }
        }
    }
}